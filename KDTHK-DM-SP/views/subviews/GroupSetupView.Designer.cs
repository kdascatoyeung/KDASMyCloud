namespace KDTHK_DM_SP.views.subviews
{
    partial class GroupSetupView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupSetupView));
            this.pnlGroup = new CustomUtil.controls.panel.CustomPanel();
            this.ckbCheckall = new System.Windows.Forms.CheckBox();
            this.lblSelectedGroup = new System.Windows.Forms.Label();
            this.btnSave = new CustomUtil.controls.button.CustomButton();
            this.customPanel2 = new CustomUtil.controls.panel.CustomPanel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.ckblbGroup = new System.Windows.Forms.CheckedListBox();
            this.bdSearch = new CustomUtil.controls.panel.CustomPanel();
            this.txtSearch = new CustomUtil.controls.textbox.WatermarkTextbox();
            this.dgvUsers = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.pnlMain = new CustomUtil.controls.panel.CustomPanel();
            this.dgvGroup = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.cGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOldGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnHk = new System.Windows.Forms.ToolStripButton();
            this.tsbtnJp = new System.Windows.Forms.ToolStripButton();
            this.tsbtnCn = new System.Windows.Forms.ToolStripButton();
            this.tsbtnVn = new System.Windows.Forms.ToolStripButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbtnNew = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRename = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.cSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDivision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cloc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlGroup.SuspendLayout();
            this.customPanel2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.bdSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGroup
            // 
            this.pnlGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGroup.BackColor = System.Drawing.SystemColors.Window;
            this.pnlGroup.BackColor2 = System.Drawing.SystemColors.Window;
            this.pnlGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGroup.BorderWidth = 1;
            this.pnlGroup.Controls.Add(this.ckbCheckall);
            this.pnlGroup.Controls.Add(this.lblSelectedGroup);
            this.pnlGroup.Controls.Add(this.btnSave);
            this.pnlGroup.Controls.Add(this.customPanel2);
            this.pnlGroup.Controls.Add(this.bdSearch);
            this.pnlGroup.Controls.Add(this.dgvUsers);
            this.pnlGroup.Curvature = 2;
            this.pnlGroup.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.pnlGroup.Enabled = false;
            this.pnlGroup.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.pnlGroup.Location = new System.Drawing.Point(280, 3);
            this.pnlGroup.Name = "pnlGroup";
            this.pnlGroup.Size = new System.Drawing.Size(815, 603);
            this.pnlGroup.TabIndex = 67;
            // 
            // ckbCheckall
            // 
            this.ckbCheckall.AutoSize = true;
            this.ckbCheckall.BackColor = System.Drawing.Color.Gainsboro;
            this.ckbCheckall.Checked = true;
            this.ckbCheckall.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbCheckall.Location = new System.Drawing.Point(5, 25);
            this.ckbCheckall.Name = "ckbCheckall";
            this.ckbCheckall.Size = new System.Drawing.Size(15, 14);
            this.ckbCheckall.TabIndex = 69;
            this.ckbCheckall.UseVisualStyleBackColor = false;
            this.ckbCheckall.CheckedChanged += new System.EventHandler(this.ckbCheckall_CheckedChanged);
            // 
            // lblSelectedGroup
            // 
            this.lblSelectedGroup.AutoSize = true;
            this.lblSelectedGroup.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedGroup.Location = new System.Drawing.Point(3, 6);
            this.lblSelectedGroup.Name = "lblSelectedGroup";
            this.lblSelectedGroup.Size = new System.Drawing.Size(106, 15);
            this.lblSelectedGroup.TabIndex = 68;
            this.lblSelectedGroup.Text = "Group. : Unknown";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.GlowColor = System.Drawing.Color.SkyBlue;
            this.btnSave.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnSave.Location = new System.Drawing.Point(548, 566);
            this.btnSave.Name = "btnSave";
            this.btnSave.OuterBorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.ShineColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.Size = new System.Drawing.Size(264, 32);
            this.btnSave.TabIndex = 67;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // customPanel2
            // 
            this.customPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanel2.BackColor = System.Drawing.SystemColors.Window;
            this.customPanel2.BackColor2 = System.Drawing.SystemColors.Window;
            this.customPanel2.BorderColor = System.Drawing.Color.LightGray;
            this.customPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel2.BorderWidth = 1;
            this.customPanel2.Controls.Add(this.toolStrip2);
            this.customPanel2.Controls.Add(this.ckblbGroup);
            this.customPanel2.Curvature = 3;
            this.customPanel2.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.customPanel2.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.customPanel2.Location = new System.Drawing.Point(548, 28);
            this.customPanel2.Name = "customPanel2";
            this.customPanel2.Size = new System.Drawing.Size(264, 534);
            this.customPanel2.TabIndex = 66;
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnHk,
            this.tsbtnJp,
            this.tsbtnCn,
            this.tsbtnVn});
            this.toolStrip2.Location = new System.Drawing.Point(1, 1);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(262, 28);
            this.toolStrip2.TabIndex = 43;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // ckblbGroup
            // 
            this.ckblbGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ckblbGroup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckblbGroup.CheckOnClick = true;
            this.ckblbGroup.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckblbGroup.FormattingEnabled = true;
            this.ckblbGroup.Location = new System.Drawing.Point(3, 31);
            this.ckblbGroup.Name = "ckblbGroup";
            this.ckblbGroup.Size = new System.Drawing.Size(257, 500);
            this.ckblbGroup.TabIndex = 41;
            this.ckblbGroup.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ckblbGroup_ItemCheck);
            // 
            // bdSearch
            // 
            this.bdSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bdSearch.BackColor = System.Drawing.SystemColors.Window;
            this.bdSearch.BackColor2 = System.Drawing.SystemColors.Window;
            this.bdSearch.BorderColor = System.Drawing.Color.Silver;
            this.bdSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bdSearch.BorderWidth = 1;
            this.bdSearch.Controls.Add(this.btnSearch);
            this.bdSearch.Controls.Add(this.txtSearch);
            this.bdSearch.Curvature = 2;
            this.bdSearch.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.bdSearch.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.bdSearch.Location = new System.Drawing.Point(548, 3);
            this.bdSearch.Name = "bdSearch";
            this.bdSearch.Size = new System.Drawing.Size(264, 22);
            this.bdSearch.TabIndex = 65;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.FocusSelect = true;
            this.txtSearch.Location = new System.Drawing.Point(4, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PromptFont = new System.Drawing.Font("Calibri", 9F);
            this.txtSearch.PromptForeColor = System.Drawing.SystemColors.GrayText;
            this.txtSearch.PromptText = "Search here";
            this.txtSearch.Size = new System.Drawing.Size(234, 16);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowDrop = true;
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToResizeRows = false;
            this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvUsers.ColumnHeaderColor1 = System.Drawing.Color.AliceBlue;
            this.dgvUsers.ColumnHeaderColor2 = System.Drawing.SystemColors.ControlLightLight;
            this.dgvUsers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cSelect,
            this.cName,
            this.cDivision,
            this.cloc});
            this.dgvUsers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvUsers.EnableHeadersVisualStyles = false;
            this.dgvUsers.Location = new System.Drawing.Point(3, 24);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvUsers.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvUsers.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvUsers.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsers.RowTemplate.Height = 20;
            this.dgvUsers.SecondaryLength = 2;
            this.dgvUsers.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvUsers.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvUsers.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvUsers.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvUsers.ShowCellErrors = false;
            this.dgvUsers.ShowCellToolTips = false;
            this.dgvUsers.ShowEditingIcon = false;
            this.dgvUsers.ShowRowErrors = false;
            this.dgvUsers.Size = new System.Drawing.Size(539, 576);
            this.dgvUsers.TabIndex = 64;
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlMain.BackColor = System.Drawing.SystemColors.Window;
            this.pnlMain.BackColor2 = System.Drawing.SystemColors.Window;
            this.pnlMain.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.BorderWidth = 1;
            this.pnlMain.Controls.Add(this.dgvGroup);
            this.pnlMain.Controls.Add(this.toolStrip1);
            this.pnlMain.Curvature = 2;
            this.pnlMain.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.pnlMain.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.pnlMain.Location = new System.Drawing.Point(3, 3);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(274, 603);
            this.pnlMain.TabIndex = 66;
            // 
            // dgvGroup
            // 
            this.dgvGroup.AllowDrop = true;
            this.dgvGroup.AllowUserToAddRows = false;
            this.dgvGroup.AllowUserToDeleteRows = false;
            this.dgvGroup.AllowUserToResizeRows = false;
            this.dgvGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGroup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGroup.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvGroup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvGroup.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvGroup.ColumnHeaderColor1 = System.Drawing.Color.AliceBlue;
            this.dgvGroup.ColumnHeaderColor2 = System.Drawing.SystemColors.ControlLightLight;
            this.dgvGroup.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGroup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cGroup,
            this.cOldGroup});
            this.dgvGroup.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvGroup.EnableHeadersVisualStyles = false;
            this.dgvGroup.Location = new System.Drawing.Point(3, 25);
            this.dgvGroup.MultiSelect = false;
            this.dgvGroup.Name = "dgvGroup";
            this.dgvGroup.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvGroup.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvGroup.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgvGroup.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvGroup.RowTemplate.Height = 20;
            this.dgvGroup.SecondaryLength = 2;
            this.dgvGroup.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvGroup.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvGroup.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvGroup.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroup.ShowCellErrors = false;
            this.dgvGroup.ShowCellToolTips = false;
            this.dgvGroup.ShowEditingIcon = false;
            this.dgvGroup.ShowRowErrors = false;
            this.dgvGroup.Size = new System.Drawing.Size(268, 575);
            this.dgvGroup.TabIndex = 64;
            this.dgvGroup.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroup_CellEndEdit);
            this.dgvGroup.DoubleClick += new System.EventHandler(this.dgvGroup_DoubleClick);
            // 
            // cGroup
            // 
            this.cGroup.HeaderText = "Group";
            this.cGroup.Name = "cGroup";
            this.cGroup.ReadOnly = true;
            // 
            // cOldGroup
            // 
            this.cOldGroup.HeaderText = "oldgroup";
            this.cOldGroup.Name = "cOldGroup";
            this.cOldGroup.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnRefresh,
            this.tsbtnNew,
            this.tsbtnRename,
            this.tsbtnDelete});
            this.toolStrip1.Location = new System.Drawing.Point(1, 1);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(271, 25);
            this.toolStrip1.TabIndex = 63;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnHk
            // 
            this.tsbtnHk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnHk.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnHk.Image")));
            this.tsbtnHk.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnHk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnHk.Name = "tsbtnHk";
            this.tsbtnHk.Size = new System.Drawing.Size(28, 25);
            this.tsbtnHk.Tag = "hk";
            this.tsbtnHk.Text = "btnHk";
            this.tsbtnHk.ToolTipText = "KDTHK";
            this.tsbtnHk.Click += new System.EventHandler(this.ToolStripButtonClicked);
            // 
            // tsbtnJp
            // 
            this.tsbtnJp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnJp.Image = global::KDTHK_DM_SP.Properties.Resources.Japan_gray;
            this.tsbtnJp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnJp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnJp.Name = "tsbtnJp";
            this.tsbtnJp.Size = new System.Drawing.Size(28, 25);
            this.tsbtnJp.Tag = "jp";
            this.tsbtnJp.ToolTipText = "KDC";
            this.tsbtnJp.Click += new System.EventHandler(this.ToolStripButtonClicked);
            // 
            // tsbtnCn
            // 
            this.tsbtnCn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnCn.Image = global::KDTHK_DM_SP.Properties.Resources.China_flat_gray;
            this.tsbtnCn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnCn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCn.Name = "tsbtnCn";
            this.tsbtnCn.Size = new System.Drawing.Size(28, 25);
            this.tsbtnCn.Tag = "cn";
            this.tsbtnCn.Text = "toolStripButton2";
            this.tsbtnCn.ToolTipText = "KDTCN";
            this.tsbtnCn.Click += new System.EventHandler(this.ToolStripButtonClicked);
            // 
            // tsbtnVn
            // 
            this.tsbtnVn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnVn.Image = global::KDTHK_DM_SP.Properties.Resources.Vietnam_flat_gray;
            this.tsbtnVn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnVn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnVn.Name = "tsbtnVn";
            this.tsbtnVn.Size = new System.Drawing.Size(28, 25);
            this.tsbtnVn.Tag = "vn";
            this.tsbtnVn.Text = "toolStripButton2";
            this.tsbtnVn.ToolTipText = "KDTVN";
            this.tsbtnVn.Click += new System.EventHandler(this.ToolStripButtonClicked);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(244, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(16, 16);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tsbtnRefresh
            // 
            this.tsbtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRefresh.Image")));
            this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefresh.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tsbtnRefresh.Name = "tsbtnRefresh";
            this.tsbtnRefresh.Size = new System.Drawing.Size(66, 22);
            this.tsbtnRefresh.Text = "Refresh";
            this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
            // 
            // tsbtnNew
            // 
            this.tsbtnNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnNew.Image")));
            this.tsbtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNew.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tsbtnNew.Name = "tsbtnNew";
            this.tsbtnNew.Size = new System.Drawing.Size(51, 22);
            this.tsbtnNew.Text = "New";
            this.tsbtnNew.Click += new System.EventHandler(this.tsbtnNew_Click);
            // 
            // tsbtnRename
            // 
            this.tsbtnRename.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRename.Image")));
            this.tsbtnRename.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRename.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tsbtnRename.Name = "tsbtnRename";
            this.tsbtnRename.Size = new System.Drawing.Size(70, 22);
            this.tsbtnRename.Text = "Rename";
            this.tsbtnRename.Visible = false;
            this.tsbtnRename.Click += new System.EventHandler(this.tsbtnRename_Click);
            // 
            // tsbtnDelete
            // 
            this.tsbtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDelete.Image")));
            this.tsbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDelete.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tsbtnDelete.Name = "tsbtnDelete";
            this.tsbtnDelete.Size = new System.Drawing.Size(70, 22);
            this.tsbtnDelete.Text = "Remove";
            this.tsbtnDelete.Click += new System.EventHandler(this.tsbtnDelete_Click);
            // 
            // cSelect
            // 
            this.cSelect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cSelect.FillWeight = 10F;
            this.cSelect.HeaderText = "";
            this.cSelect.MinimumWidth = 15;
            this.cSelect.Name = "cSelect";
            this.cSelect.Width = 15;
            // 
            // cName
            // 
            this.cName.FillWeight = 70F;
            this.cName.HeaderText = "Name";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            // 
            // cDivision
            // 
            this.cDivision.FillWeight = 138.5787F;
            this.cDivision.HeaderText = "Division";
            this.cDivision.Name = "cDivision";
            this.cDivision.ReadOnly = true;
            // 
            // cloc
            // 
            this.cloc.HeaderText = "loc";
            this.cloc.Name = "cloc";
            this.cloc.Visible = false;
            // 
            // GroupSetupView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.pnlGroup);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "GroupSetupView";
            this.Size = new System.Drawing.Size(1098, 609);
            this.pnlGroup.ResumeLayout(false);
            this.pnlGroup.PerformLayout();
            this.customPanel2.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.bdSearch.ResumeLayout(false);
            this.bdSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomUtil.controls.panel.CustomPanel pnlMain;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnNew;
        private System.Windows.Forms.ToolStripButton tsbtnRename;
        private System.Windows.Forms.ToolStripButton tsbtnDelete;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvGroup;
        private CustomUtil.controls.panel.CustomPanel pnlGroup;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvUsers;
        private CustomUtil.controls.panel.CustomPanel bdSearch;
        private System.Windows.Forms.Button btnSearch;
        private CustomUtil.controls.textbox.WatermarkTextbox txtSearch;
        private CustomUtil.controls.panel.CustomPanel customPanel2;
        private System.Windows.Forms.CheckedListBox ckblbGroup;
        private CustomUtil.controls.button.CustomButton btnSave;
        private System.Windows.Forms.Label lblSelectedGroup;
        private System.Windows.Forms.CheckBox ckbCheckall;
        private System.Windows.Forms.ToolStripButton tsbtnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn cGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOldGroup;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbtnHk;
        private System.Windows.Forms.ToolStripButton tsbtnJp;
        private System.Windows.Forms.ToolStripButton tsbtnCn;
        private System.Windows.Forms.ToolStripButton tsbtnVn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDivision;
        private System.Windows.Forms.DataGridViewTextBoxColumn cloc;
    }
}
