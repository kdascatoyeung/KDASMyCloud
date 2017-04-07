namespace KDTHK_DM_SP.forms
{
    partial class ReceivedForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceivedForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.customPanel2 = new CustomUtil.controls.panel.CustomPanel();
            this.ckbAll = new System.Windows.Forms.CheckBox();
            this.dgvReceived = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.markAllAsFavoriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllFromFavoriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReceive = new CustomUtil.controls.button.CustomButton();
            this.btnReceiveAll = new CustomUtil.controls.button.CustomButton();
            this.cSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.colFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colfav = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colpath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colvpath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cReject = new System.Windows.Forms.DataGridViewImageColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.customPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceived)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.customPanel2.Controls.Add(this.ckbAll);
            this.customPanel2.Controls.Add(this.dgvReceived);
            this.customPanel2.Curvature = 2;
            this.customPanel2.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.customPanel2.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.customPanel2.Location = new System.Drawing.Point(1, 25);
            this.customPanel2.Name = "customPanel2";
            this.customPanel2.Size = new System.Drawing.Size(1033, 372);
            this.customPanel2.TabIndex = 20;
            // 
            // ckbAll
            // 
            this.ckbAll.AutoSize = true;
            this.ckbAll.Location = new System.Drawing.Point(4, 4);
            this.ckbAll.Name = "ckbAll";
            this.ckbAll.Size = new System.Drawing.Size(15, 14);
            this.ckbAll.TabIndex = 60;
            this.ckbAll.UseVisualStyleBackColor = true;
            this.ckbAll.Visible = false;
            this.ckbAll.CheckedChanged += new System.EventHandler(this.ckbAll_CheckedChanged);
            // 
            // dgvReceived
            // 
            this.dgvReceived.AllowDrop = true;
            this.dgvReceived.AllowUserToAddRows = false;
            this.dgvReceived.AllowUserToDeleteRows = false;
            this.dgvReceived.AllowUserToResizeRows = false;
            this.dgvReceived.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReceived.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReceived.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvReceived.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReceived.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvReceived.ColumnHeaderColor1 = System.Drawing.Color.AliceBlue;
            this.dgvReceived.ColumnHeaderColor2 = System.Drawing.SystemColors.ControlLightLight;
            this.dgvReceived.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReceived.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReceived.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceived.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cSelect,
            this.cImg,
            this.colFilename,
            this.colfav,
            this.cOwner,
            this.cReceived,
            this.colpath,
            this.colvpath,
            this.cReject});
            this.dgvReceived.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvReceived.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvReceived.EnableHeadersVisualStyles = false;
            this.dgvReceived.Location = new System.Drawing.Point(3, 2);
            this.dgvReceived.Name = "dgvReceived";
            this.dgvReceived.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvReceived.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvReceived.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvReceived.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReceived.RowTemplate.Height = 20;
            this.dgvReceived.SecondaryLength = 2;
            this.dgvReceived.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvReceived.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvReceived.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvReceived.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvReceived.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceived.ShowCellErrors = false;
            this.dgvReceived.ShowCellToolTips = false;
            this.dgvReceived.ShowEditingIcon = false;
            this.dgvReceived.ShowRowErrors = false;
            this.dgvReceived.Size = new System.Drawing.Size(1027, 366);
            this.dgvReceived.TabIndex = 58;
            this.dgvReceived.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReceived_CellContentClick);
            this.dgvReceived.DoubleClick += new System.EventHandler(this.dgvReceived_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::KDTHK_DM_SP.Properties.Resources.cross;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1036, 25);
            this.toolStrip1.TabIndex = 21;
            this.toolStrip1.Text = "toolStrip1";
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
            // btnReceive
            // 
            this.btnReceive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReceive.BackColor = System.Drawing.Color.Gainsboro;
            this.btnReceive.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceive.ForeColor = System.Drawing.Color.Black;
            this.btnReceive.GlowColor = System.Drawing.Color.SkyBlue;
            this.btnReceive.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnReceive.Location = new System.Drawing.Point(789, 407);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.OuterBorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnReceive.ShineColor = System.Drawing.Color.WhiteSmoke;
            this.btnReceive.Size = new System.Drawing.Size(118, 25);
            this.btnReceive.TabIndex = 69;
            this.btnReceive.Text = "Receive";
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // btnReceiveAll
            // 
            this.btnReceiveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReceiveAll.BackColor = System.Drawing.Color.Gainsboro;
            this.btnReceiveAll.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceiveAll.ForeColor = System.Drawing.Color.Black;
            this.btnReceiveAll.GlowColor = System.Drawing.Color.SkyBlue;
            this.btnReceiveAll.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnReceiveAll.Location = new System.Drawing.Point(913, 407);
            this.btnReceiveAll.Name = "btnReceiveAll";
            this.btnReceiveAll.OuterBorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnReceiveAll.ShineColor = System.Drawing.Color.WhiteSmoke;
            this.btnReceiveAll.Size = new System.Drawing.Size(118, 25);
            this.btnReceiveAll.TabIndex = 70;
            this.btnReceiveAll.Text = "Receive All";
            this.btnReceiveAll.Click += new System.EventHandler(this.btnReceiveAll_Click);
            // 
            // cSelect
            // 
            this.cSelect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cSelect.FillWeight = 5F;
            this.cSelect.HeaderText = "";
            this.cSelect.Name = "cSelect";
            this.cSelect.Visible = false;
            this.cSelect.Width = 5;
            // 
            // cImg
            // 
            this.cImg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cImg.HeaderText = "";
            this.cImg.Name = "cImg";
            this.cImg.ReadOnly = true;
            this.cImg.Width = 5;
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
            // cOwner
            // 
            this.cOwner.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cOwner.HeaderText = "Owner";
            this.cOwner.Name = "cOwner";
            this.cOwner.ReadOnly = true;
            this.cOwner.Width = 66;
            // 
            // cReceived
            // 
            this.cReceived.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cReceived.HeaderText = "Received";
            this.cReceived.Name = "cReceived";
            this.cReceived.ReadOnly = true;
            this.cReceived.Width = 78;
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
            // cReject
            // 
            this.cReject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cReject.HeaderText = "";
            this.cReject.Name = "cReject";
            this.cReject.ReadOnly = true;
            this.cReject.Width = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 411);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 15);
            this.label1.TabIndex = 71;
            this.label1.Text = "Please select to receive specified files.";
            // 
            // ReceivedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1036, 436);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReceiveAll);
            this.Controls.Add(this.btnReceive);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.customPanel2);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReceivedForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Received Files";
            this.customPanel2.ResumeLayout(false);
            this.customPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceived)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomUtil.controls.panel.CustomPanel customPanel2;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvReceived;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem markAllAsFavoriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAllFromFavoriteToolStripMenuItem;
        private System.Windows.Forms.CheckBox ckbAll;
        private CustomUtil.controls.button.CustomButton btnReceive;
        private CustomUtil.controls.button.CustomButton btnReceiveAll;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cSelect;
        private System.Windows.Forms.DataGridViewImageColumn cImg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFilename;
        private System.Windows.Forms.DataGridViewComboBoxColumn colfav;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn cReceived;
        private System.Windows.Forms.DataGridViewTextBoxColumn colpath;
        private System.Windows.Forms.DataGridViewTextBoxColumn colvpath;
        private System.Windows.Forms.DataGridViewImageColumn cReject;
        private System.Windows.Forms.Label label1;
    }
}