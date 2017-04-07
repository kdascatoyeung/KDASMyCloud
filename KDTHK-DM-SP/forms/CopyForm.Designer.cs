namespace KDTHK_DM_SP.forms
{
    partial class CopyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CopyForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.markAllAsFavoriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllFromFavoriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customPanel15 = new CustomUtil.controls.panel.CustomPanel();
            this.tvFolder = new System.Windows.Forms.TreeView();
            this.imglist = new System.Windows.Forms.ImageList(this.components);
            this.customPanel16 = new CustomUtil.controls.panel.CustomPanel();
            this.btnNewFolder = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.customPanel1 = new CustomUtil.controls.panel.CustomPanel();
            this.btnSave = new CustomUtil.controls.button.CustomButton();
            this.ckbApplyAll = new System.Windows.Forms.CheckBox();
            this.customPanel8 = new CustomUtil.controls.panel.CustomPanel();
            this.rbtnDepartment = new System.Windows.Forms.RadioButton();
            this.rbtnDivision = new System.Windows.Forms.RadioButton();
            this.rbtnCustom = new System.Windows.Forms.RadioButton();
            this.lbShare = new System.Windows.Forms.ListBox();
            this.customPanel3 = new CustomUtil.controls.panel.CustomPanel();
            this.btnNewShare = new System.Windows.Forms.Button();
            this.btnDeleteShare = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.customPanel2 = new CustomUtil.controls.panel.CustomPanel();
            this.dgvCopySetup = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.cnameold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKeyword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colfav = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colpath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTmppath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colvpath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cShared = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvUser = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDivision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.customPanel15.SuspendLayout();
            this.customPanel16.SuspendLayout();
            this.customPanel1.SuspendLayout();
            this.customPanel3.SuspendLayout();
            this.customPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCopySetup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnUndo,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1177, 25);
            this.toolStrip1.TabIndex = 21;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnUndo
            // 
            this.tsbtnUndo.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnUndo.Image")));
            this.tsbtnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnUndo.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tsbtnUndo.Name = "tsbtnUndo";
            this.tsbtnUndo.Size = new System.Drawing.Size(56, 22);
            this.tsbtnUndo.Text = "Undo";
            this.tsbtnUndo.Visible = false;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.markAllAsFavoriteToolStripMenuItem,
            this.removeAllFromFavoriteToolStripMenuItem});
            this.toolStripButton1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.Image = global::KDTHK_DM_SP.Properties.Resources.star_16;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(81, 22);
            this.toolStripButton1.Text = "Favorite";
            // 
            // markAllAsFavoriteToolStripMenuItem
            // 
            this.markAllAsFavoriteToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("markAllAsFavoriteToolStripMenuItem.BackgroundImage")));
            this.markAllAsFavoriteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("markAllAsFavoriteToolStripMenuItem.Image")));
            this.markAllAsFavoriteToolStripMenuItem.Name = "markAllAsFavoriteToolStripMenuItem";
            this.markAllAsFavoriteToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.markAllAsFavoriteToolStripMenuItem.Text = "Mark all as Favorite";
            this.markAllAsFavoriteToolStripMenuItem.Click += new System.EventHandler(this.markAllAsFavoriteToolStripMenuItem_Click);
            // 
            // removeAllFromFavoriteToolStripMenuItem
            // 
            this.removeAllFromFavoriteToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("removeAllFromFavoriteToolStripMenuItem.BackgroundImage")));
            this.removeAllFromFavoriteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("removeAllFromFavoriteToolStripMenuItem.Image")));
            this.removeAllFromFavoriteToolStripMenuItem.Name = "removeAllFromFavoriteToolStripMenuItem";
            this.removeAllFromFavoriteToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.removeAllFromFavoriteToolStripMenuItem.Text = "Remove all from Favorite";
            this.removeAllFromFavoriteToolStripMenuItem.Click += new System.EventHandler(this.removeAllFromFavoriteToolStripMenuItem_Click);
            // 
            // customPanel15
            // 
            this.customPanel15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.customPanel15.BackColor = System.Drawing.SystemColors.Window;
            this.customPanel15.BackColor2 = System.Drawing.SystemColors.Window;
            this.customPanel15.BorderColor = System.Drawing.Color.DarkGray;
            this.customPanel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel15.BorderWidth = 1;
            this.customPanel15.Controls.Add(this.tvFolder);
            this.customPanel15.Controls.Add(this.customPanel16);
            this.customPanel15.Curvature = 2;
            this.customPanel15.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.customPanel15.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.customPanel15.Location = new System.Drawing.Point(2, 26);
            this.customPanel15.Name = "customPanel15";
            this.customPanel15.Size = new System.Drawing.Size(245, 582);
            this.customPanel15.TabIndex = 22;
            // 
            // tvFolder
            // 
            this.tvFolder.AllowDrop = true;
            this.tvFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvFolder.ImageIndex = 0;
            this.tvFolder.ImageList = this.imglist;
            this.tvFolder.Location = new System.Drawing.Point(3, 26);
            this.tvFolder.Name = "tvFolder";
            this.tvFolder.SelectedImageIndex = 0;
            this.tvFolder.Size = new System.Drawing.Size(239, 553);
            this.tvFolder.TabIndex = 2;
            this.tvFolder.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvFolder_NodeMouseClick);
            // 
            // imglist
            // 
            this.imglist.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglist.ImageStream")));
            this.imglist.TransparentColor = System.Drawing.SystemColors.ControlLightLight;
            this.imglist.Images.SetKeyName(0, "folder-open.png");
            // 
            // customPanel16
            // 
            this.customPanel16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanel16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.customPanel16.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.customPanel16.BorderColor = System.Drawing.Color.DarkGray;
            this.customPanel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel16.BorderWidth = 1;
            this.customPanel16.Controls.Add(this.btnNewFolder);
            this.customPanel16.Controls.Add(this.label7);
            this.customPanel16.Curvature = 1;
            this.customPanel16.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.customPanel16.GradientMode = CustomUtil.controls.panel.LinearGradientMode.Vertical;
            this.customPanel16.Location = new System.Drawing.Point(0, 0);
            this.customPanel16.Name = "customPanel16";
            this.customPanel16.Size = new System.Drawing.Size(245, 24);
            this.customPanel16.TabIndex = 1;
            // 
            // btnNewFolder
            // 
            this.btnNewFolder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNewFolder.BackgroundImage")));
            this.btnNewFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNewFolder.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnNewFolder.FlatAppearance.BorderSize = 0;
            this.btnNewFolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnNewFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnNewFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNewFolder.Location = new System.Drawing.Point(226, 3);
            this.btnNewFolder.Name = "btnNewFolder";
            this.btnNewFolder.Size = new System.Drawing.Size(16, 16);
            this.btnNewFolder.TabIndex = 51;
            this.btnNewFolder.Tag = "open";
            this.btnNewFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewFolder.UseVisualStyleBackColor = true;
            this.btnNewFolder.Click += new System.EventHandler(this.btnNewFolder_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(71, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "Personal Folder";
            // 
            // customPanel1
            // 
            this.customPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.customPanel1.BackColor2 = System.Drawing.SystemColors.Window;
            this.customPanel1.BorderColor = System.Drawing.Color.DarkGray;
            this.customPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel1.BorderWidth = 1;
            this.customPanel1.Controls.Add(this.dgvUser);
            this.customPanel1.Controls.Add(this.btnSave);
            this.customPanel1.Controls.Add(this.ckbApplyAll);
            this.customPanel1.Controls.Add(this.customPanel8);
            this.customPanel1.Controls.Add(this.rbtnDepartment);
            this.customPanel1.Controls.Add(this.rbtnDivision);
            this.customPanel1.Controls.Add(this.rbtnCustom);
            this.customPanel1.Controls.Add(this.lbShare);
            this.customPanel1.Controls.Add(this.customPanel3);
            this.customPanel1.Curvature = 2;
            this.customPanel1.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.customPanel1.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.customPanel1.Location = new System.Drawing.Point(966, 26);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(210, 582);
            this.customPanel1.TabIndex = 23;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.GlowColor = System.Drawing.Color.SkyBlue;
            this.btnSave.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnSave.Location = new System.Drawing.Point(3, 549);
            this.btnSave.Name = "btnSave";
            this.btnSave.OuterBorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.ShineColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.Size = new System.Drawing.Size(204, 30);
            this.btnSave.TabIndex = 68;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ckbApplyAll
            // 
            this.ckbApplyAll.AutoSize = true;
            this.ckbApplyAll.Checked = true;
            this.ckbApplyAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbApplyAll.Location = new System.Drawing.Point(3, 416);
            this.ckbApplyAll.Name = "ckbApplyAll";
            this.ckbApplyAll.Size = new System.Drawing.Size(115, 19);
            this.ckbApplyAll.TabIndex = 54;
            this.ckbApplyAll.Text = "Apply to all files";
            this.ckbApplyAll.UseVisualStyleBackColor = true;
            // 
            // customPanel8
            // 
            this.customPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanel8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.customPanel8.BackColor2 = System.Drawing.SystemColors.Window;
            this.customPanel8.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.customPanel8.BorderWidth = 1;
            this.customPanel8.Curvature = 3;
            this.customPanel8.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.customPanel8.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.customPanel8.Location = new System.Drawing.Point(3, 438);
            this.customPanel8.Name = "customPanel8";
            this.customPanel8.Size = new System.Drawing.Size(204, 5);
            this.customPanel8.TabIndex = 53;
            // 
            // rbtnDepartment
            // 
            this.rbtnDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbtnDepartment.AutoSize = true;
            this.rbtnDepartment.Location = new System.Drawing.Point(3, 499);
            this.rbtnDepartment.Name = "rbtnDepartment";
            this.rbtnDepartment.Size = new System.Drawing.Size(142, 19);
            this.rbtnDepartment.TabIndex = 52;
            this.rbtnDepartment.Tag = "department";
            this.rbtnDepartment.Text = "Department members";
            this.rbtnDepartment.UseVisualStyleBackColor = true;
            this.rbtnDepartment.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // rbtnDivision
            // 
            this.rbtnDivision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbtnDivision.AutoSize = true;
            this.rbtnDivision.Location = new System.Drawing.Point(3, 474);
            this.rbtnDivision.Name = "rbtnDivision";
            this.rbtnDivision.Size = new System.Drawing.Size(124, 19);
            this.rbtnDivision.TabIndex = 51;
            this.rbtnDivision.Tag = "division";
            this.rbtnDivision.Text = "Division members";
            this.rbtnDivision.UseVisualStyleBackColor = true;
            this.rbtnDivision.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // rbtnCustom
            // 
            this.rbtnCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbtnCustom.AutoSize = true;
            this.rbtnCustom.Checked = true;
            this.rbtnCustom.Location = new System.Drawing.Point(3, 449);
            this.rbtnCustom.Name = "rbtnCustom";
            this.rbtnCustom.Size = new System.Drawing.Size(66, 19);
            this.rbtnCustom.TabIndex = 50;
            this.rbtnCustom.TabStop = true;
            this.rbtnCustom.Tag = "custom";
            this.rbtnCustom.Text = "Custom";
            this.rbtnCustom.UseVisualStyleBackColor = true;
            this.rbtnCustom.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // lbShare
            // 
            this.lbShare.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbShare.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbShare.FormattingEnabled = true;
            this.lbShare.ItemHeight = 15;
            this.lbShare.Location = new System.Drawing.Point(141, 458);
            this.lbShare.Name = "lbShare";
            this.lbShare.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbShare.Size = new System.Drawing.Size(66, 60);
            this.lbShare.TabIndex = 49;
            this.lbShare.Visible = false;
            // 
            // customPanel3
            // 
            this.customPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.customPanel3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.customPanel3.BorderColor = System.Drawing.Color.DarkGray;
            this.customPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel3.BorderWidth = 1;
            this.customPanel3.Controls.Add(this.btnNewShare);
            this.customPanel3.Controls.Add(this.btnDeleteShare);
            this.customPanel3.Controls.Add(this.label1);
            this.customPanel3.Curvature = 1;
            this.customPanel3.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.customPanel3.GradientMode = CustomUtil.controls.panel.LinearGradientMode.Vertical;
            this.customPanel3.Location = new System.Drawing.Point(0, 0);
            this.customPanel3.Name = "customPanel3";
            this.customPanel3.Size = new System.Drawing.Size(210, 24);
            this.customPanel3.TabIndex = 1;
            // 
            // btnNewShare
            // 
            this.btnNewShare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewShare.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNewShare.BackgroundImage")));
            this.btnNewShare.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNewShare.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnNewShare.FlatAppearance.BorderSize = 0;
            this.btnNewShare.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnNewShare.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnNewShare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewShare.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewShare.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNewShare.Location = new System.Drawing.Point(169, 4);
            this.btnNewShare.Name = "btnNewShare";
            this.btnNewShare.Size = new System.Drawing.Size(16, 16);
            this.btnNewShare.TabIndex = 50;
            this.btnNewShare.Tag = "open";
            this.btnNewShare.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewShare.UseVisualStyleBackColor = true;
            this.btnNewShare.Click += new System.EventHandler(this.btnNewShare_Click);
            // 
            // btnDeleteShare
            // 
            this.btnDeleteShare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteShare.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDeleteShare.BackgroundImage")));
            this.btnDeleteShare.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteShare.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnDeleteShare.FlatAppearance.BorderSize = 0;
            this.btnDeleteShare.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnDeleteShare.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnDeleteShare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteShare.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteShare.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDeleteShare.Location = new System.Drawing.Point(191, 4);
            this.btnDeleteShare.Name = "btnDeleteShare";
            this.btnDeleteShare.Size = new System.Drawing.Size(16, 16);
            this.btnDeleteShare.TabIndex = 49;
            this.btnDeleteShare.Tag = "open";
            this.btnDeleteShare.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteShare.UseVisualStyleBackColor = true;
            this.btnDeleteShare.Click += new System.EventHandler(this.btnDeleteShare_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(80, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sharing";
            // 
            // customPanel2
            // 
            this.customPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanel2.BackColor = System.Drawing.SystemColors.Window;
            this.customPanel2.BackColor2 = System.Drawing.SystemColors.Window;
            this.customPanel2.BorderColor = System.Drawing.Color.DarkGray;
            this.customPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel2.BorderWidth = 1;
            this.customPanel2.Controls.Add(this.dgvCopySetup);
            this.customPanel2.Curvature = 2;
            this.customPanel2.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.customPanel2.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.customPanel2.Location = new System.Drawing.Point(249, 26);
            this.customPanel2.Name = "customPanel2";
            this.customPanel2.Size = new System.Drawing.Size(715, 582);
            this.customPanel2.TabIndex = 24;
            // 
            // dgvCopySetup
            // 
            this.dgvCopySetup.AllowDrop = true;
            this.dgvCopySetup.AllowUserToAddRows = false;
            this.dgvCopySetup.AllowUserToDeleteRows = false;
            this.dgvCopySetup.AllowUserToResizeRows = false;
            this.dgvCopySetup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCopySetup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCopySetup.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvCopySetup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCopySetup.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvCopySetup.ColumnHeaderColor1 = System.Drawing.Color.AliceBlue;
            this.dgvCopySetup.ColumnHeaderColor2 = System.Drawing.SystemColors.ControlLightLight;
            this.dgvCopySetup.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCopySetup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvCopySetup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCopySetup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnameold,
            this.colFilename,
            this.colKeyword,
            this.colfav,
            this.colpath,
            this.cTmppath,
            this.colvpath,
            this.cShared});
            this.dgvCopySetup.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvCopySetup.EnableHeadersVisualStyles = false;
            this.dgvCopySetup.Location = new System.Drawing.Point(3, 3);
            this.dgvCopySetup.Name = "dgvCopySetup";
            this.dgvCopySetup.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvCopySetup.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvCopySetup.RowHeadersVisible = false;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.White;
            this.dgvCopySetup.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvCopySetup.RowTemplate.Height = 20;
            this.dgvCopySetup.SecondaryLength = 2;
            this.dgvCopySetup.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvCopySetup.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvCopySetup.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvCopySetup.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvCopySetup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCopySetup.ShowCellErrors = false;
            this.dgvCopySetup.ShowCellToolTips = false;
            this.dgvCopySetup.ShowEditingIcon = false;
            this.dgvCopySetup.ShowRowErrors = false;
            this.dgvCopySetup.Size = new System.Drawing.Size(709, 576);
            this.dgvCopySetup.TabIndex = 58;
            this.dgvCopySetup.SelectionChanged += new System.EventHandler(this.dgvCopySetup_SelectionChanged);
            // 
            // cnameold
            // 
            this.cnameold.HeaderText = "Name (Old)";
            this.cnameold.Name = "cnameold";
            this.cnameold.Visible = false;
            // 
            // colFilename
            // 
            this.colFilename.DataPropertyName = "filename";
            dataGridViewCellStyle18.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.colFilename.DefaultCellStyle = dataGridViewCellStyle18;
            this.colFilename.FillWeight = 97.9351F;
            this.colFilename.HeaderText = "Name (New)";
            this.colFilename.Name = "colFilename";
            // 
            // colKeyword
            // 
            this.colKeyword.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colKeyword.DataPropertyName = "modified";
            dataGridViewCellStyle19.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.colKeyword.DefaultCellStyle = dataGridViewCellStyle19;
            this.colKeyword.FillWeight = 97.9351F;
            this.colKeyword.HeaderText = "Keyword";
            this.colKeyword.Name = "colKeyword";
            this.colKeyword.Width = 77;
            // 
            // colfav
            // 
            this.colfav.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colfav.DataPropertyName = "favorite";
            this.colfav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colfav.HeaderText = "Favorite";
            this.colfav.Items.AddRange(new object[] {
            "---",
            "Yes"});
            this.colfav.Name = "colfav";
            this.colfav.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colfav.Width = 56;
            // 
            // colpath
            // 
            this.colpath.DataPropertyName = "path";
            this.colpath.HeaderText = "path";
            this.colpath.Name = "colpath";
            this.colpath.Visible = false;
            // 
            // cTmppath
            // 
            this.cTmppath.HeaderText = "tmppath";
            this.cTmppath.Name = "cTmppath";
            this.cTmppath.Visible = false;
            // 
            // colvpath
            // 
            this.colvpath.HeaderText = "Folder";
            this.colvpath.Name = "colvpath";
            // 
            // cShared
            // 
            this.cShared.HeaderText = "Shared";
            this.cShared.Name = "cShared";
            this.cShared.ReadOnly = true;
            // 
            // dgvUser
            // 
            this.dgvUser.AllowDrop = true;
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.AllowUserToDeleteRows = false;
            this.dgvUser.AllowUserToResizeRows = false;
            this.dgvUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUser.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUser.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvUser.ColumnHeaderColor1 = System.Drawing.Color.AliceBlue;
            this.dgvUser.ColumnHeaderColor2 = System.Drawing.SystemColors.ControlLightLight;
            this.dgvUser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cName,
            this.cDivision});
            this.dgvUser.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvUser.EnableHeadersVisualStyles = false;
            this.dgvUser.Location = new System.Drawing.Point(3, 25);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvUser.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvUser.RowHeadersVisible = false;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.White;
            this.dgvUser.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvUser.RowTemplate.Height = 20;
            this.dgvUser.SecondaryLength = 2;
            this.dgvUser.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvUser.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvUser.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvUser.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUser.ShowCellErrors = false;
            this.dgvUser.ShowCellToolTips = false;
            this.dgvUser.ShowEditingIcon = false;
            this.dgvUser.ShowRowErrors = false;
            this.dgvUser.Size = new System.Drawing.Size(204, 385);
            this.dgvUser.TabIndex = 69;
            // 
            // cName
            // 
            this.cName.FillWeight = 30F;
            this.cName.HeaderText = "Name";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            // 
            // cDivision
            // 
            this.cDivision.FillWeight = 43.73942F;
            this.cDivision.HeaderText = "loc";
            this.cDivision.Name = "cDivision";
            this.cDivision.ReadOnly = true;
            this.cDivision.Visible = false;
            // 
            // CopyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1177, 611);
            this.Controls.Add(this.customPanel2);
            this.Controls.Add(this.customPanel1);
            this.Controls.Add(this.customPanel15);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CopyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Document Setup Wizard - Copy";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.customPanel15.ResumeLayout(false);
            this.customPanel16.ResumeLayout(false);
            this.customPanel16.PerformLayout();
            this.customPanel1.ResumeLayout(false);
            this.customPanel1.PerformLayout();
            this.customPanel3.ResumeLayout(false);
            this.customPanel3.PerformLayout();
            this.customPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCopySetup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnUndo;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem markAllAsFavoriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAllFromFavoriteToolStripMenuItem;
        private CustomUtil.controls.panel.CustomPanel customPanel15;
        private System.Windows.Forms.TreeView tvFolder;
        private CustomUtil.controls.panel.CustomPanel customPanel16;
        private System.Windows.Forms.Button btnNewFolder;
        private System.Windows.Forms.Label label7;
        private CustomUtil.controls.panel.CustomPanel customPanel1;
        private System.Windows.Forms.CheckBox ckbApplyAll;
        private CustomUtil.controls.panel.CustomPanel customPanel8;
        private System.Windows.Forms.RadioButton rbtnDepartment;
        private System.Windows.Forms.RadioButton rbtnDivision;
        private System.Windows.Forms.RadioButton rbtnCustom;
        private System.Windows.Forms.ListBox lbShare;
        private CustomUtil.controls.panel.CustomPanel customPanel3;
        private System.Windows.Forms.Button btnNewShare;
        private System.Windows.Forms.Button btnDeleteShare;
        private System.Windows.Forms.Label label1;
        private CustomUtil.controls.panel.CustomPanel customPanel2;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvCopySetup;
        private System.Windows.Forms.ImageList imglist;
        private CustomUtil.controls.button.CustomButton btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnameold;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFilename;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKeyword;
        private System.Windows.Forms.DataGridViewComboBoxColumn colfav;
        private System.Windows.Forms.DataGridViewTextBoxColumn colpath;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTmppath;
        private System.Windows.Forms.DataGridViewTextBoxColumn colvpath;
        private System.Windows.Forms.DataGridViewTextBoxColumn cShared;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDivision;
    }
}