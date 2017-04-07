namespace KDTHK_DM_SP.views
{
    partial class DiscView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiscView));
            this.customPanel3 = new CustomUtil.controls.panel.CustomPanel();
            this.dgvDisc = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.customPanel16 = new CustomUtil.controls.panel.CustomPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.customPanel1 = new CustomUtil.controls.panel.CustomPanel();
            this.dgvPending = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.cPendingFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customPanel4 = new CustomUtil.controls.panel.CustomPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDisc = new CustomUtil.controls.panel.CustomPanel();
            this.dgvDiscView = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.bdSearch = new CustomUtil.controls.panel.CustomPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new CustomUtil.controls.textbox.WatermarkTextbox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRequest = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbtnView = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbtnViewDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.iPOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iPOToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rPS管理部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.經營管理部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.行政及人力資源部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mASTER管理科ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cDisc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDiscPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDiscNo = new System.Windows.Forms.Label();
            this.customPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisc)).BeginInit();
            this.customPanel16.SuspendLayout();
            this.customPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPending)).BeginInit();
            this.customPanel4.SuspendLayout();
            this.pnlDisc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscView)).BeginInit();
            this.bdSearch.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // customPanel3
            // 
            this.customPanel3.BackColor = System.Drawing.SystemColors.Window;
            this.customPanel3.BackColor2 = System.Drawing.SystemColors.Window;
            this.customPanel3.BorderColor = System.Drawing.Color.DarkGray;
            this.customPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel3.BorderWidth = 1;
            this.customPanel3.Controls.Add(this.toolStrip2);
            this.customPanel3.Controls.Add(this.dgvDisc);
            this.customPanel3.Controls.Add(this.customPanel16);
            this.customPanel3.Curvature = 2;
            this.customPanel3.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.customPanel3.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.customPanel3.Location = new System.Drawing.Point(3, 3);
            this.customPanel3.Name = "customPanel3";
            this.customPanel3.Size = new System.Drawing.Size(240, 336);
            this.customPanel3.TabIndex = 12;
            // 
            // dgvDisc
            // 
            this.dgvDisc.AllowDrop = true;
            this.dgvDisc.AllowUserToAddRows = false;
            this.dgvDisc.AllowUserToDeleteRows = false;
            this.dgvDisc.AllowUserToResizeRows = false;
            this.dgvDisc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDisc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDisc.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvDisc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDisc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvDisc.ColumnHeaderColor1 = System.Drawing.Color.AliceBlue;
            this.dgvDisc.ColumnHeaderColor2 = System.Drawing.SystemColors.ControlLightLight;
            this.dgvDisc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDisc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDisc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDisc,
            this.cDiscPath});
            this.dgvDisc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDisc.EnableHeadersVisualStyles = false;
            this.dgvDisc.Location = new System.Drawing.Point(3, 49);
            this.dgvDisc.MultiSelect = false;
            this.dgvDisc.Name = "dgvDisc";
            this.dgvDisc.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvDisc.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvDisc.ReadOnly = true;
            this.dgvDisc.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDisc.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDisc.RowTemplate.Height = 20;
            this.dgvDisc.SecondaryLength = 2;
            this.dgvDisc.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvDisc.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvDisc.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvDisc.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvDisc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDisc.ShowCellErrors = false;
            this.dgvDisc.ShowCellToolTips = false;
            this.dgvDisc.ShowEditingIcon = false;
            this.dgvDisc.ShowRowErrors = false;
            this.dgvDisc.Size = new System.Drawing.Size(234, 285);
            this.dgvDisc.TabIndex = 60;
            this.dgvDisc.DoubleClick += new System.EventHandler(this.dgvDisc_DoubleClick);
            // 
            // customPanel16
            // 
            this.customPanel16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.customPanel16.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.customPanel16.BorderColor = System.Drawing.Color.DarkGray;
            this.customPanel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel16.BorderWidth = 1;
            this.customPanel16.Controls.Add(this.label7);
            this.customPanel16.Curvature = 1;
            this.customPanel16.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.customPanel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.customPanel16.GradientMode = CustomUtil.controls.panel.LinearGradientMode.Vertical;
            this.customPanel16.Location = new System.Drawing.Point(0, 0);
            this.customPanel16.Name = "customPanel16";
            this.customPanel16.Size = new System.Drawing.Size(240, 24);
            this.customPanel16.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(91, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "Disc List";
            // 
            // customPanel1
            // 
            this.customPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.customPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.customPanel1.BackColor2 = System.Drawing.SystemColors.Window;
            this.customPanel1.BorderColor = System.Drawing.Color.DarkGray;
            this.customPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel1.BorderWidth = 1;
            this.customPanel1.Controls.Add(this.toolStrip1);
            this.customPanel1.Controls.Add(this.dgvPending);
            this.customPanel1.Controls.Add(this.customPanel4);
            this.customPanel1.Curvature = 2;
            this.customPanel1.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.customPanel1.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.customPanel1.Location = new System.Drawing.Point(3, 345);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(240, 296);
            this.customPanel1.TabIndex = 13;
            // 
            // dgvPending
            // 
            this.dgvPending.AllowDrop = true;
            this.dgvPending.AllowUserToAddRows = false;
            this.dgvPending.AllowUserToDeleteRows = false;
            this.dgvPending.AllowUserToResizeRows = false;
            this.dgvPending.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPending.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPending.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPending.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPending.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvPending.ColumnHeaderColor1 = System.Drawing.Color.AliceBlue;
            this.dgvPending.ColumnHeaderColor2 = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPending.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPending.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPending.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPending.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cPendingFile,
            this.cPath});
            this.dgvPending.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvPending.EnableHeadersVisualStyles = false;
            this.dgvPending.Location = new System.Drawing.Point(3, 48);
            this.dgvPending.Name = "dgvPending";
            this.dgvPending.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvPending.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvPending.ReadOnly = true;
            this.dgvPending.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgvPending.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPending.RowTemplate.Height = 20;
            this.dgvPending.SecondaryLength = 2;
            this.dgvPending.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvPending.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvPending.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvPending.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvPending.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPending.ShowCellErrors = false;
            this.dgvPending.ShowCellToolTips = false;
            this.dgvPending.ShowEditingIcon = false;
            this.dgvPending.ShowRowErrors = false;
            this.dgvPending.Size = new System.Drawing.Size(234, 245);
            this.dgvPending.TabIndex = 59;
            this.dgvPending.DoubleClick += new System.EventHandler(this.dgvPending_DoubleClick);
            // 
            // cPendingFile
            // 
            this.cPendingFile.HeaderText = "File";
            this.cPendingFile.Name = "cPendingFile";
            this.cPendingFile.ReadOnly = true;
            // 
            // cPath
            // 
            this.cPath.HeaderText = "path";
            this.cPath.Name = "cPath";
            this.cPath.ReadOnly = true;
            this.cPath.Visible = false;
            // 
            // customPanel4
            // 
            this.customPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.customPanel4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.customPanel4.BorderColor = System.Drawing.Color.DarkGray;
            this.customPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel4.BorderWidth = 1;
            this.customPanel4.Controls.Add(this.label1);
            this.customPanel4.Curvature = 1;
            this.customPanel4.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.customPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.customPanel4.GradientMode = CustomUtil.controls.panel.LinearGradientMode.Vertical;
            this.customPanel4.Location = new System.Drawing.Point(0, 0);
            this.customPanel4.Name = "customPanel4";
            this.customPanel4.Size = new System.Drawing.Size(240, 24);
            this.customPanel4.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(76, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pending files";
            // 
            // pnlDisc
            // 
            this.pnlDisc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDisc.BackColor = System.Drawing.SystemColors.Window;
            this.pnlDisc.BackColor2 = System.Drawing.SystemColors.Window;
            this.pnlDisc.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlDisc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDisc.BorderWidth = 1;
            this.pnlDisc.Controls.Add(this.lblDiscNo);
            this.pnlDisc.Controls.Add(this.dgvDiscView);
            this.pnlDisc.Controls.Add(this.bdSearch);
            this.pnlDisc.Curvature = 2;
            this.pnlDisc.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.pnlDisc.Enabled = false;
            this.pnlDisc.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.pnlDisc.Location = new System.Drawing.Point(249, 3);
            this.pnlDisc.Name = "pnlDisc";
            this.pnlDisc.Size = new System.Drawing.Size(921, 638);
            this.pnlDisc.TabIndex = 14;
            // 
            // dgvDiscView
            // 
            this.dgvDiscView.AllowDrop = true;
            this.dgvDiscView.AllowUserToAddRows = false;
            this.dgvDiscView.AllowUserToDeleteRows = false;
            this.dgvDiscView.AllowUserToResizeRows = false;
            this.dgvDiscView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDiscView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDiscView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvDiscView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDiscView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvDiscView.ColumnHeaderColor1 = System.Drawing.Color.AliceBlue;
            this.dgvDiscView.ColumnHeaderColor2 = System.Drawing.SystemColors.ControlLightLight;
            this.dgvDiscView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDiscView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDiscView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiscView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cFileName});
            this.dgvDiscView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDiscView.EnableHeadersVisualStyles = false;
            this.dgvDiscView.Location = new System.Drawing.Point(3, 25);
            this.dgvDiscView.Name = "dgvDiscView";
            this.dgvDiscView.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvDiscView.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvDiscView.ReadOnly = true;
            this.dgvDiscView.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDiscView.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDiscView.RowTemplate.Height = 20;
            this.dgvDiscView.SecondaryLength = 2;
            this.dgvDiscView.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvDiscView.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvDiscView.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvDiscView.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvDiscView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDiscView.ShowCellErrors = false;
            this.dgvDiscView.ShowCellToolTips = false;
            this.dgvDiscView.ShowEditingIcon = false;
            this.dgvDiscView.ShowRowErrors = false;
            this.dgvDiscView.Size = new System.Drawing.Size(915, 610);
            this.dgvDiscView.TabIndex = 61;
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
            this.bdSearch.Location = new System.Drawing.Point(721, 2);
            this.bdSearch.Name = "bdSearch";
            this.bdSearch.Size = new System.Drawing.Size(197, 22);
            this.bdSearch.TabIndex = 7;
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
            this.btnSearch.Location = new System.Drawing.Point(177, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(16, 16);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.txtSearch.Size = new System.Drawing.Size(167, 16);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnRefresh,
            this.tsbtnRemove,
            this.tsbtnRequest});
            this.toolStrip1.Location = new System.Drawing.Point(2, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(235, 25);
            this.toolStrip1.TabIndex = 60;
            this.toolStrip1.Text = "toolStrip1";
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
            // tsbtnRequest
            // 
            this.tsbtnRequest.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRequest.Image")));
            this.tsbtnRequest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRequest.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tsbtnRequest.Name = "tsbtnRequest";
            this.tsbtnRequest.Size = new System.Drawing.Size(69, 22);
            this.tsbtnRequest.Text = "Request";
            this.tsbtnRequest.Click += new System.EventHandler(this.tsbtnRequest_Click);
            // 
            // tsbtnRemove
            // 
            this.tsbtnRemove.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRemove.Image")));
            this.tsbtnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRemove.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tsbtnRemove.Name = "tsbtnRemove";
            this.tsbtnRemove.Size = new System.Drawing.Size(70, 22);
            this.tsbtnRemove.Text = "Remove";
            this.tsbtnRemove.Click += new System.EventHandler(this.tsbtnRemove_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnView});
            this.toolStrip2.Location = new System.Drawing.Point(2, 25);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(235, 25);
            this.toolStrip2.TabIndex = 61;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbtnView
            // 
            this.tsbtnView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnViewDefault,
            this.iPOToolStripMenuItem,
            this.iPOToolStripMenuItem1,
            this.rPS管理部ToolStripMenuItem,
            this.經營管理部ToolStripMenuItem,
            this.行政及人力資源部ToolStripMenuItem,
            this.mASTER管理科ToolStripMenuItem});
            this.tsbtnView.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbtnView.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnView.Image")));
            this.tsbtnView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnView.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tsbtnView.Name = "tsbtnView";
            this.tsbtnView.Size = new System.Drawing.Size(50, 22);
            this.tsbtnView.Text = "All";
            // 
            // tsbtnViewDefault
            // 
            this.tsbtnViewDefault.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsbtnViewDefault.BackgroundImage")));
            this.tsbtnViewDefault.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnViewDefault.Image")));
            this.tsbtnViewDefault.Name = "tsbtnViewDefault";
            this.tsbtnViewDefault.Size = new System.Drawing.Size(171, 22);
            this.tsbtnViewDefault.Tag = "all";
            this.tsbtnViewDefault.Text = "All";
            this.tsbtnViewDefault.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // iPOToolStripMenuItem
            // 
            this.iPOToolStripMenuItem.BackgroundImage = global::KDTHK_DM_SP.Properties.Resources.temp;
            this.iPOToolStripMenuItem.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iPOToolStripMenuItem.Name = "iPOToolStripMenuItem";
            this.iPOToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.iPOToolStripMenuItem.Tag = "ipo";
            this.iPOToolStripMenuItem.Text = "IPO 採購部";
            this.iPOToolStripMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // iPOToolStripMenuItem1
            // 
            this.iPOToolStripMenuItem1.BackgroundImage = global::KDTHK_DM_SP.Properties.Resources.temp;
            this.iPOToolStripMenuItem1.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iPOToolStripMenuItem1.Name = "iPOToolStripMenuItem1";
            this.iPOToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.iPOToolStripMenuItem1.Tag = "log";
            this.iPOToolStripMenuItem1.Text = "物流部";
            this.iPOToolStripMenuItem1.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // rPS管理部ToolStripMenuItem
            // 
            this.rPS管理部ToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rPS管理部ToolStripMenuItem.BackgroundImage")));
            this.rPS管理部ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rPS管理部ToolStripMenuItem.Name = "rPS管理部ToolStripMenuItem";
            this.rPS管理部ToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.rPS管理部ToolStripMenuItem.Tag = "rps";
            this.rPS管理部ToolStripMenuItem.Text = "RPS 管理部";
            this.rPS管理部ToolStripMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // 經營管理部ToolStripMenuItem
            // 
            this.經營管理部ToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("經營管理部ToolStripMenuItem.BackgroundImage")));
            this.經營管理部ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.經營管理部ToolStripMenuItem.Name = "經營管理部ToolStripMenuItem";
            this.經營管理部ToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.經營管理部ToolStripMenuItem.Tag = "cm";
            this.經營管理部ToolStripMenuItem.Text = "經營管理部";
            this.經營管理部ToolStripMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // 行政及人力資源部ToolStripMenuItem
            // 
            this.行政及人力資源部ToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("行政及人力資源部ToolStripMenuItem.BackgroundImage")));
            this.行政及人力資源部ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.行政及人力資源部ToolStripMenuItem.Name = "行政及人力資源部ToolStripMenuItem";
            this.行政及人力資源部ToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.行政及人力資源部ToolStripMenuItem.Tag = "hra";
            this.行政及人力資源部ToolStripMenuItem.Text = "行政及人力資源部";
            this.行政及人力資源部ToolStripMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // mASTER管理科ToolStripMenuItem
            // 
            this.mASTER管理科ToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mASTER管理科ToolStripMenuItem.BackgroundImage")));
            this.mASTER管理科ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mASTER管理科ToolStripMenuItem.Name = "mASTER管理科ToolStripMenuItem";
            this.mASTER管理科ToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.mASTER管理科ToolStripMenuItem.Tag = "mcc";
            this.mASTER管理科ToolStripMenuItem.Text = "MASTER 管理科";
            this.mASTER管理科ToolStripMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // cDisc
            // 
            this.cDisc.HeaderText = "Disc";
            this.cDisc.Name = "cDisc";
            this.cDisc.ReadOnly = true;
            // 
            // cDiscPath
            // 
            this.cDiscPath.HeaderText = "path";
            this.cDiscPath.Name = "cDiscPath";
            this.cDiscPath.ReadOnly = true;
            this.cDiscPath.Visible = false;
            // 
            // cFileName
            // 
            this.cFileName.HeaderText = "Filename";
            this.cFileName.Name = "cFileName";
            this.cFileName.ReadOnly = true;
            // 
            // lblDiscNo
            // 
            this.lblDiscNo.AutoSize = true;
            this.lblDiscNo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscNo.Location = new System.Drawing.Point(3, 6);
            this.lblDiscNo.Name = "lblDiscNo";
            this.lblDiscNo.Size = new System.Drawing.Size(112, 15);
            this.lblDiscNo.TabIndex = 62;
            this.lblDiscNo.Text = "Disc No. : Unknown";
            // 
            // DiscView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.pnlDisc);
            this.Controls.Add(this.customPanel1);
            this.Controls.Add(this.customPanel3);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DiscView";
            this.Size = new System.Drawing.Size(1173, 644);
            this.customPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisc)).EndInit();
            this.customPanel16.ResumeLayout(false);
            this.customPanel16.PerformLayout();
            this.customPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPending)).EndInit();
            this.customPanel4.ResumeLayout(false);
            this.customPanel4.PerformLayout();
            this.pnlDisc.ResumeLayout(false);
            this.pnlDisc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscView)).EndInit();
            this.bdSearch.ResumeLayout(false);
            this.bdSearch.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomUtil.controls.panel.CustomPanel customPanel3;
        private CustomUtil.controls.panel.CustomPanel customPanel1;
        private CustomUtil.controls.panel.CustomPanel pnlDisc;
        private CustomUtil.controls.panel.CustomPanel customPanel16;
        private System.Windows.Forms.Label label7;
        private CustomUtil.controls.panel.CustomPanel customPanel4;
        private System.Windows.Forms.Label label1;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvPending;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPendingFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPath;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvDisc;
        private CustomUtil.controls.panel.CustomPanel bdSearch;
        private System.Windows.Forms.Button btnSearch;
        private CustomUtil.controls.textbox.WatermarkTextbox txtSearch;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvDiscView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnRefresh;
        private System.Windows.Forms.ToolStripButton tsbtnRequest;
        private System.Windows.Forms.ToolStripButton tsbtnRemove;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripDropDownButton tsbtnView;
        private System.Windows.Forms.ToolStripMenuItem tsbtnViewDefault;
        private System.Windows.Forms.ToolStripMenuItem iPOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iPOToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rPS管理部ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 經營管理部ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 行政及人力資源部ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mASTER管理科ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDisc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDiscPath;
        private System.Windows.Forms.Label lblDiscNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFileName;

    }
}
