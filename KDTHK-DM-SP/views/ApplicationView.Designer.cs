namespace KDTHK_DM_SP.views
{
    partial class ApplicationView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationView));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlGroup = new CustomUtil.controls.panel.CustomPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.dgvAppList = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.cCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clastaccess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customPanel3 = new CustomUtil.controls.panel.CustomPanel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMain = new System.Windows.Forms.Label();
            this.customPanel16 = new CustomUtil.controls.panel.CustomPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlGroup.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppList)).BeginInit();
            this.customPanel3.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.customPanel16.SuspendLayout();
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
            this.pnlGroup.Controls.Add(this.toolStrip1);
            this.pnlGroup.Controls.Add(this.dgvAppList);
            this.pnlGroup.Curvature = 2;
            this.pnlGroup.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.pnlGroup.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.pnlGroup.Location = new System.Drawing.Point(216, 3);
            this.pnlGroup.Name = "pnlGroup";
            this.pnlGroup.Size = new System.Drawing.Size(952, 629);
            this.pnlGroup.TabIndex = 69;
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
            this.tsbtnOpen,
            this.tsbtnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(2, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(948, 25);
            this.toolStrip1.TabIndex = 65;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnOpen
            // 
            this.tsbtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnOpen.Image")));
            this.tsbtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOpen.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tsbtnOpen.Name = "tsbtnOpen";
            this.tsbtnOpen.Size = new System.Drawing.Size(56, 22);
            this.tsbtnOpen.Text = "Open";
            this.tsbtnOpen.Click += new System.EventHandler(this.tsbtnOpen_Click);
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
            // dgvAppList
            // 
            this.dgvAppList.AllowDrop = true;
            this.dgvAppList.AllowUserToAddRows = false;
            this.dgvAppList.AllowUserToDeleteRows = false;
            this.dgvAppList.AllowUserToResizeRows = false;
            this.dgvAppList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAppList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppList.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvAppList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAppList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvAppList.ColumnHeaderColor1 = System.Drawing.Color.AliceBlue;
            this.dgvAppList.ColumnHeaderColor2 = System.Drawing.SystemColors.ControlLightLight;
            this.dgvAppList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAppList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAppList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cCategory,
            this.cName,
            this.cDesc,
            this.cpath,
            this.clastaccess});
            this.dgvAppList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvAppList.EnableHeadersVisualStyles = false;
            this.dgvAppList.Location = new System.Drawing.Point(3, 27);
            this.dgvAppList.MultiSelect = false;
            this.dgvAppList.Name = "dgvAppList";
            this.dgvAppList.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvAppList.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvAppList.ReadOnly = true;
            this.dgvAppList.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvAppList.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAppList.RowTemplate.Height = 32;
            this.dgvAppList.SecondaryLength = 2;
            this.dgvAppList.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvAppList.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvAppList.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvAppList.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvAppList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppList.ShowCellErrors = false;
            this.dgvAppList.ShowCellToolTips = false;
            this.dgvAppList.ShowEditingIcon = false;
            this.dgvAppList.ShowRowErrors = false;
            this.dgvAppList.Size = new System.Drawing.Size(946, 599);
            this.dgvAppList.TabIndex = 64;
            this.dgvAppList.DoubleClick += new System.EventHandler(this.dgvAppList_DoubleClick);
            // 
            // cCategory
            // 
            this.cCategory.HeaderText = "Category";
            this.cCategory.Name = "cCategory";
            this.cCategory.ReadOnly = true;
            // 
            // cName
            // 
            this.cName.FillWeight = 138.5787F;
            this.cName.HeaderText = "Name";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            // 
            // cDesc
            // 
            this.cDesc.HeaderText = "Description";
            this.cDesc.Name = "cDesc";
            this.cDesc.ReadOnly = true;
            // 
            // cpath
            // 
            this.cpath.HeaderText = "path";
            this.cpath.Name = "cpath";
            this.cpath.ReadOnly = true;
            this.cpath.Visible = false;
            // 
            // clastaccess
            // 
            this.clastaccess.HeaderText = "Last Access";
            this.clastaccess.Name = "clastaccess";
            this.clastaccess.ReadOnly = true;
            this.clastaccess.Visible = false;
            // 
            // customPanel3
            // 
            this.customPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.customPanel3.BackColor = System.Drawing.SystemColors.Window;
            this.customPanel3.BackColor2 = System.Drawing.SystemColors.Window;
            this.customPanel3.BorderColor = System.Drawing.Color.DarkGray;
            this.customPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel3.BorderWidth = 1;
            this.customPanel3.Controls.Add(this.pnlMenu);
            this.customPanel3.Controls.Add(this.customPanel16);
            this.customPanel3.Curvature = 2;
            this.customPanel3.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.customPanel3.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.customPanel3.Location = new System.Drawing.Point(3, 3);
            this.customPanel3.Name = "customPanel3";
            this.customPanel3.Size = new System.Drawing.Size(210, 629);
            this.customPanel3.TabIndex = 70;
            // 
            // pnlMenu
            // 
            this.pnlMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMenu.Controls.Add(this.label6);
            this.pnlMenu.Controls.Add(this.label4);
            this.pnlMenu.Controls.Add(this.label3);
            this.pnlMenu.Controls.Add(this.label2);
            this.pnlMenu.Controls.Add(this.lblMain);
            this.pnlMenu.Location = new System.Drawing.Point(3, 25);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(204, 406);
            this.pnlMenu.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(5, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(196, 35);
            this.label6.TabIndex = 24;
            this.label6.Tag = "form";
            this.label6.Text = "            Forms";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Click += new System.EventHandler(this.LabelClicked);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(5, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 35);
            this.label4.TabIndex = 22;
            this.label4.Tag = "tool";
            this.label4.Text = "            Tools";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Click += new System.EventHandler(this.LabelClicked);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(5, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 35);
            this.label3.TabIndex = 21;
            this.label3.Tag = "application";
            this.label3.Text = "            Application";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Click += new System.EventHandler(this.LabelClicked);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(5, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 35);
            this.label2.TabIndex = 20;
            this.label2.Tag = "others";
            this.label2.Text = "            Others";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Click += new System.EventHandler(this.LabelClicked);
            // 
            // lblMain
            // 
            this.lblMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMain.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMain.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblMain.Image = ((System.Drawing.Image)(resources.GetObject("lblMain.Image")));
            this.lblMain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMain.Location = new System.Drawing.Point(5, 3);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(196, 35);
            this.lblMain.TabIndex = 18;
            this.lblMain.Tag = "all";
            this.lblMain.Text = "            All";
            this.lblMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMain.Click += new System.EventHandler(this.LabelClicked);
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
            this.customPanel16.Size = new System.Drawing.Size(210, 24);
            this.customPanel16.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(58, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "Select Category";
            // 
            // ApplicationView2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.customPanel3);
            this.Controls.Add(this.pnlGroup);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ApplicationView2";
            this.Size = new System.Drawing.Size(1171, 635);
            this.pnlGroup.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppList)).EndInit();
            this.customPanel3.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.customPanel16.ResumeLayout(false);
            this.customPanel16.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomUtil.controls.panel.CustomPanel pnlGroup;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnOpen;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvAppList;
        private CustomUtil.controls.panel.CustomPanel customPanel3;
        private CustomUtil.controls.panel.CustomPanel customPanel16;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpath;
        private System.Windows.Forms.DataGridViewTextBoxColumn clastaccess;
        private System.Windows.Forms.ToolStripButton tsbtnRefresh;
    }
}
