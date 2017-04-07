namespace KDTHK_DM_SP.forms
{
    partial class UserGlobalForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserGlobalForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.customPanel2 = new CustomUtil.controls.panel.CustomPanel();
            this.ckbCheckall = new System.Windows.Forms.CheckBox();
            this.dgvUser = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.bdSearch = new CustomUtil.controls.panel.CustomPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new CustomUtil.controls.textbox.WatermarkTextbox();
            this.customPanel1 = new CustomUtil.controls.panel.CustomPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnHk = new System.Windows.Forms.ToolStripButton();
            this.tsbtnJp = new System.Windows.Forms.ToolStripButton();
            this.tsbtnCn = new System.Windows.Forms.ToolStripButton();
            this.tsbtnVn = new System.Windows.Forms.ToolStripButton();
            this.ckblbGroup = new System.Windows.Forms.CheckedListBox();
            this.btnConfirm = new CustomUtil.controls.button.CustomButton();
            this.cSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDivision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.bdSearch.SuspendLayout();
            this.customPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customPanel2
            // 
            this.customPanel2.BackColor = System.Drawing.SystemColors.Window;
            this.customPanel2.BackColor2 = System.Drawing.SystemColors.Window;
            this.customPanel2.BorderColor = System.Drawing.Color.DarkGray;
            this.customPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel2.BorderWidth = 1;
            this.customPanel2.Controls.Add(this.ckbCheckall);
            this.customPanel2.Controls.Add(this.dgvUser);
            this.customPanel2.Curvature = 2;
            this.customPanel2.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.customPanel2.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.customPanel2.Location = new System.Drawing.Point(2, 2);
            this.customPanel2.Name = "customPanel2";
            this.customPanel2.Size = new System.Drawing.Size(649, 510);
            this.customPanel2.TabIndex = 44;
            // 
            // ckbCheckall
            // 
            this.ckbCheckall.AutoSize = true;
            this.ckbCheckall.BackColor = System.Drawing.Color.Gainsboro;
            this.ckbCheckall.Location = new System.Drawing.Point(10, 4);
            this.ckbCheckall.Name = "ckbCheckall";
            this.ckbCheckall.Size = new System.Drawing.Size(15, 14);
            this.ckbCheckall.TabIndex = 59;
            this.ckbCheckall.UseVisualStyleBackColor = false;
            this.ckbCheckall.CheckedChanged += new System.EventHandler(this.ckbCheckall_CheckedChanged);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cSelection,
            this.cName,
            this.cDivision,
            this.cLocation});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUser.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvUser.EnableHeadersVisualStyles = false;
            this.dgvUser.Location = new System.Drawing.Point(3, 3);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvUser.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvUser.RowHeadersVisible = false;
            this.dgvUser.RowHeadersWidth = 50;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUser.RowTemplate.Height = 25;
            this.dgvUser.SecondaryLength = 2;
            this.dgvUser.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvUser.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvUser.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvUser.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvUser.ShowCellErrors = false;
            this.dgvUser.ShowCellToolTips = false;
            this.dgvUser.ShowEditingIcon = false;
            this.dgvUser.ShowRowErrors = false;
            this.dgvUser.Size = new System.Drawing.Size(643, 504);
            this.dgvUser.TabIndex = 58;
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
            this.bdSearch.Location = new System.Drawing.Point(653, 2);
            this.bdSearch.Name = "bdSearch";
            this.bdSearch.Size = new System.Drawing.Size(389, 22);
            this.bdSearch.TabIndex = 45;
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
            this.btnSearch.Location = new System.Drawing.Point(369, 3);
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
            this.txtSearch.Size = new System.Drawing.Size(359, 16);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // customPanel1
            // 
            this.customPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.customPanel1.BackColor2 = System.Drawing.SystemColors.Window;
            this.customPanel1.BorderColor = System.Drawing.Color.LightGray;
            this.customPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel1.BorderWidth = 1;
            this.customPanel1.Controls.Add(this.toolStrip1);
            this.customPanel1.Controls.Add(this.ckblbGroup);
            this.customPanel1.Curvature = 3;
            this.customPanel1.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.customPanel1.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.customPanel1.Location = new System.Drawing.Point(653, 27);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(389, 485);
            this.customPanel1.TabIndex = 46;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnHk,
            this.tsbtnJp,
            this.tsbtnCn,
            this.tsbtnVn});
            this.toolStrip1.Location = new System.Drawing.Point(1, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(386, 28);
            this.toolStrip1.TabIndex = 42;
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
            // ckblbGroup
            // 
            this.ckblbGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ckblbGroup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckblbGroup.CheckOnClick = true;
            this.ckblbGroup.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckblbGroup.FormattingEnabled = true;
            this.ckblbGroup.Location = new System.Drawing.Point(3, 32);
            this.ckblbGroup.Name = "ckblbGroup";
            this.ckblbGroup.Size = new System.Drawing.Size(383, 440);
            this.ckblbGroup.TabIndex = 41;
            this.ckblbGroup.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ckblbGroup_ItemCheck);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.BackColor = System.Drawing.Color.Silver;
            this.btnConfirm.ForeColor = System.Drawing.Color.Black;
            this.btnConfirm.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnConfirm.Location = new System.Drawing.Point(2, 518);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.OuterBorderColor = System.Drawing.Color.Gainsboro;
            this.btnConfirm.Size = new System.Drawing.Size(1040, 37);
            this.btnConfirm.TabIndex = 47;
            this.btnConfirm.Text = "OK";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // cSelection
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cSelection.DefaultCellStyle = dataGridViewCellStyle2;
            this.cSelection.FillWeight = 10F;
            this.cSelection.HeaderText = "";
            this.cSelection.Name = "cSelection";
            // 
            // cName
            // 
            this.cName.FillWeight = 60F;
            this.cName.HeaderText = "Name";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            // 
            // cDivision
            // 
            this.cDivision.HeaderText = "Division";
            this.cDivision.Name = "cDivision";
            this.cDivision.ReadOnly = true;
            // 
            // cLocation
            // 
            this.cLocation.HeaderText = "loc";
            this.cLocation.Name = "cLocation";
            this.cLocation.Visible = false;
            // 
            // UserGlobalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1043, 562);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.customPanel1);
            this.Controls.Add(this.bdSearch);
            this.Controls.Add(this.customPanel2);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserGlobalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Global User List";
            this.customPanel2.ResumeLayout(false);
            this.customPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.bdSearch.ResumeLayout(false);
            this.bdSearch.PerformLayout();
            this.customPanel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomUtil.controls.panel.CustomPanel customPanel2;
        private System.Windows.Forms.CheckBox ckbCheckall;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvUser;
        private CustomUtil.controls.panel.CustomPanel bdSearch;
        private System.Windows.Forms.Button btnSearch;
        private CustomUtil.controls.textbox.WatermarkTextbox txtSearch;
        private CustomUtil.controls.panel.CustomPanel customPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnHk;
        private System.Windows.Forms.ToolStripButton tsbtnJp;
        private System.Windows.Forms.ToolStripButton tsbtnCn;
        private System.Windows.Forms.ToolStripButton tsbtnVn;
        private System.Windows.Forms.CheckedListBox ckblbGroup;
        private CustomUtil.controls.button.CustomButton btnConfirm;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDivision;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLocation;
    }
}