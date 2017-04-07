namespace KDTHK_DM_SP.forms
{
    partial class MultiShareForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiShareForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnUndo = new System.Windows.Forms.ToolStripButton();
            this.customPanel2 = new CustomUtil.controls.panel.CustomPanel();
            this.dgvShareSetup = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.colFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colpath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colvpath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cShared = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ckeyword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clastmodified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdisc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cshared2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customPanel1 = new CustomUtil.controls.panel.CustomPanel();
            this.dgvUser = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDivision = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.toolStrip1.SuspendLayout();
            this.customPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShareSetup)).BeginInit();
            this.customPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.customPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnUndo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1197, 25);
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
            this.tsbtnUndo.Click += new System.EventHandler(this.tsbtnUndo_Click);
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
            this.customPanel2.Controls.Add(this.dgvShareSetup);
            this.customPanel2.Curvature = 2;
            this.customPanel2.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.customPanel2.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.customPanel2.Location = new System.Drawing.Point(2, 24);
            this.customPanel2.Name = "customPanel2";
            this.customPanel2.Size = new System.Drawing.Size(981, 583);
            this.customPanel2.TabIndex = 22;
            // 
            // dgvShareSetup
            // 
            this.dgvShareSetup.AllowDrop = true;
            this.dgvShareSetup.AllowUserToAddRows = false;
            this.dgvShareSetup.AllowUserToDeleteRows = false;
            this.dgvShareSetup.AllowUserToResizeRows = false;
            this.dgvShareSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvShareSetup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvShareSetup.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvShareSetup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvShareSetup.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvShareSetup.ColumnHeaderColor1 = System.Drawing.Color.AliceBlue;
            this.dgvShareSetup.ColumnHeaderColor2 = System.Drawing.SystemColors.ControlLightLight;
            this.dgvShareSetup.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShareSetup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvShareSetup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShareSetup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFilename,
            this.colpath,
            this.colvpath,
            this.cShared,
            this.ckeyword,
            this.clastmodified,
            this.cdisc,
            this.cshared2});
            this.dgvShareSetup.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvShareSetup.EnableHeadersVisualStyles = false;
            this.dgvShareSetup.Location = new System.Drawing.Point(3, 3);
            this.dgvShareSetup.Name = "dgvShareSetup";
            this.dgvShareSetup.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvShareSetup.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvShareSetup.ReadOnly = true;
            this.dgvShareSetup.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvShareSetup.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvShareSetup.RowTemplate.Height = 20;
            this.dgvShareSetup.SecondaryLength = 2;
            this.dgvShareSetup.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvShareSetup.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvShareSetup.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvShareSetup.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvShareSetup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvShareSetup.ShowCellErrors = false;
            this.dgvShareSetup.ShowCellToolTips = false;
            this.dgvShareSetup.ShowEditingIcon = false;
            this.dgvShareSetup.ShowRowErrors = false;
            this.dgvShareSetup.Size = new System.Drawing.Size(975, 577);
            this.dgvShareSetup.TabIndex = 58;
            this.dgvShareSetup.SelectionChanged += new System.EventHandler(this.dgvShareSetup_SelectionChanged);
            // 
            // colFilename
            // 
            this.colFilename.DataPropertyName = "filename";
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.colFilename.DefaultCellStyle = dataGridViewCellStyle2;
            this.colFilename.FillWeight = 97.9351F;
            this.colFilename.HeaderText = "Name";
            this.colFilename.Name = "colFilename";
            this.colFilename.ReadOnly = true;
            // 
            // colpath
            // 
            this.colpath.DataPropertyName = "path";
            this.colpath.HeaderText = "path";
            this.colpath.Name = "colpath";
            this.colpath.ReadOnly = true;
            this.colpath.Visible = false;
            // 
            // colvpath
            // 
            this.colvpath.HeaderText = "Folder";
            this.colvpath.Name = "colvpath";
            this.colvpath.ReadOnly = true;
            // 
            // cShared
            // 
            this.cShared.HeaderText = "Shared";
            this.cShared.Name = "cShared";
            this.cShared.ReadOnly = true;
            // 
            // ckeyword
            // 
            this.ckeyword.HeaderText = "keyword";
            this.ckeyword.Name = "ckeyword";
            this.ckeyword.ReadOnly = true;
            this.ckeyword.Visible = false;
            // 
            // clastmodified
            // 
            this.clastmodified.HeaderText = "lastmodified";
            this.clastmodified.Name = "clastmodified";
            this.clastmodified.ReadOnly = true;
            this.clastmodified.Visible = false;
            // 
            // cdisc
            // 
            this.cdisc.HeaderText = "disc";
            this.cdisc.Name = "cdisc";
            this.cdisc.ReadOnly = true;
            this.cdisc.Visible = false;
            // 
            // cshared2
            // 
            this.cshared2.HeaderText = "shared";
            this.cshared2.Name = "cshared2";
            this.cshared2.ReadOnly = true;
            this.cshared2.Visible = false;
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
            this.customPanel1.Location = new System.Drawing.Point(986, 24);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(210, 583);
            this.customPanel1.TabIndex = 23;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cName,
            this.cDivision});
            this.dgvUser.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvUser.EnableHeadersVisualStyles = false;
            this.dgvUser.Location = new System.Drawing.Point(3, 26);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvUser.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvUser.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgvUser.RowsDefaultCellStyle = dataGridViewCellStyle5;
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
            this.dgvUser.Size = new System.Drawing.Size(204, 384);
            this.dgvUser.TabIndex = 70;
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
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.GlowColor = System.Drawing.Color.SkyBlue;
            this.btnSave.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnSave.Location = new System.Drawing.Point(3, 550);
            this.btnSave.Name = "btnSave";
            this.btnSave.OuterBorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.ShineColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.Size = new System.Drawing.Size(204, 30);
            this.btnSave.TabIndex = 69;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ckbApplyAll
            // 
            this.ckbApplyAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
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
            this.customPanel8.Location = new System.Drawing.Point(3, 439);
            this.customPanel8.Name = "customPanel8";
            this.customPanel8.Size = new System.Drawing.Size(204, 5);
            this.customPanel8.TabIndex = 53;
            // 
            // rbtnDepartment
            // 
            this.rbtnDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbtnDepartment.AutoSize = true;
            this.rbtnDepartment.Location = new System.Drawing.Point(3, 500);
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
            this.rbtnDivision.Location = new System.Drawing.Point(3, 475);
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
            this.rbtnCustom.Location = new System.Drawing.Point(3, 450);
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
            this.lbShare.Location = new System.Drawing.Point(141, 460);
            this.lbShare.Name = "lbShare";
            this.lbShare.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbShare.Size = new System.Drawing.Size(66, 75);
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
            // MultiShareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1197, 608);
            this.Controls.Add(this.customPanel1);
            this.Controls.Add(this.customPanel2);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MultiShareForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Document Sharing Wizard";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.customPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShareSetup)).EndInit();
            this.customPanel1.ResumeLayout(false);
            this.customPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.customPanel3.ResumeLayout(false);
            this.customPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private CustomUtil.controls.panel.CustomPanel customPanel2;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvShareSetup;
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
        private System.Windows.Forms.ToolStripButton tsbtnUndo;
        private CustomUtil.controls.button.CustomButton btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFilename;
        private System.Windows.Forms.DataGridViewTextBoxColumn colpath;
        private System.Windows.Forms.DataGridViewTextBoxColumn colvpath;
        private System.Windows.Forms.DataGridViewTextBoxColumn cShared;
        private System.Windows.Forms.DataGridViewTextBoxColumn ckeyword;
        private System.Windows.Forms.DataGridViewTextBoxColumn clastmodified;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdisc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cshared2;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDivision;
    }
}