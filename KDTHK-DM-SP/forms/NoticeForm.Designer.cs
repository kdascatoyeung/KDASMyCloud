namespace KDTHK_DM_SP.forms
{
    partial class NoticeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoticeForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbtnClear = new System.Windows.Forms.ToolStripButton();
            this.customPanel2 = new CustomUtil.controls.panel.CustomPanel();
            this.dgvNotice = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.cSender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdatetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cfilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbtnReceived = new System.Windows.Forms.DataGridViewButtonColumn();
            this.toolStrip1.SuspendLayout();
            this.customPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotice)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnRefresh,
            this.tsbtnClear});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(797, 25);
            this.toolStrip1.TabIndex = 65;
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
            // tsbtnClear
            // 
            this.tsbtnClear.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnClear.Image")));
            this.tsbtnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnClear.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tsbtnClear.Name = "tsbtnClear";
            this.tsbtnClear.Size = new System.Drawing.Size(54, 22);
            this.tsbtnClear.Text = "Clear";
            this.tsbtnClear.Click += new System.EventHandler(this.tsbtnClear_Click);
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
            this.customPanel2.Controls.Add(this.dgvNotice);
            this.customPanel2.Curvature = 2;
            this.customPanel2.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.customPanel2.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.customPanel2.Location = new System.Drawing.Point(0, 24);
            this.customPanel2.Name = "customPanel2";
            this.customPanel2.Size = new System.Drawing.Size(796, 270);
            this.customPanel2.TabIndex = 66;
            // 
            // dgvNotice
            // 
            this.dgvNotice.AllowDrop = true;
            this.dgvNotice.AllowUserToAddRows = false;
            this.dgvNotice.AllowUserToDeleteRows = false;
            this.dgvNotice.AllowUserToResizeRows = false;
            this.dgvNotice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNotice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNotice.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvNotice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNotice.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvNotice.ColumnHeaderColor1 = System.Drawing.Color.AliceBlue;
            this.dgvNotice.ColumnHeaderColor2 = System.Drawing.SystemColors.ControlLightLight;
            this.dgvNotice.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNotice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNotice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cSender,
            this.cdatetime,
            this.cfilename,
            this.cmessage,
            this.cpath,
            this.cbtnReceived});
            this.dgvNotice.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvNotice.EnableHeadersVisualStyles = false;
            this.dgvNotice.Location = new System.Drawing.Point(3, 2);
            this.dgvNotice.Name = "dgvNotice";
            this.dgvNotice.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvNotice.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvNotice.ReadOnly = true;
            this.dgvNotice.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvNotice.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNotice.RowTemplate.Height = 20;
            this.dgvNotice.SecondaryLength = 2;
            this.dgvNotice.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvNotice.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvNotice.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvNotice.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvNotice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotice.ShowCellErrors = false;
            this.dgvNotice.ShowCellToolTips = false;
            this.dgvNotice.ShowEditingIcon = false;
            this.dgvNotice.ShowRowErrors = false;
            this.dgvNotice.Size = new System.Drawing.Size(790, 264);
            this.dgvNotice.TabIndex = 58;
            this.dgvNotice.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNotice_CellContentClick);
            this.dgvNotice.DoubleClick += new System.EventHandler(this.dgvNotice_DoubleClick);
            // 
            // cSender
            // 
            this.cSender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cSender.HeaderText = "Sender";
            this.cSender.Name = "cSender";
            this.cSender.ReadOnly = true;
            this.cSender.Width = 67;
            // 
            // cdatetime
            // 
            this.cdatetime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdatetime.HeaderText = "Datetime";
            this.cdatetime.Name = "cdatetime";
            this.cdatetime.ReadOnly = true;
            this.cdatetime.Width = 78;
            // 
            // cfilename
            // 
            this.cfilename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cfilename.HeaderText = "Filename";
            this.cfilename.Name = "cfilename";
            this.cfilename.ReadOnly = true;
            this.cfilename.Width = 80;
            // 
            // cmessage
            // 
            this.cmessage.HeaderText = "Message";
            this.cmessage.Name = "cmessage";
            this.cmessage.ReadOnly = true;
            // 
            // cpath
            // 
            this.cpath.HeaderText = "path";
            this.cpath.Name = "cpath";
            this.cpath.ReadOnly = true;
            this.cpath.Visible = false;
            // 
            // cbtnReceived
            // 
            this.cbtnReceived.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cbtnReceived.HeaderText = "";
            this.cbtnReceived.Name = "cbtnReceived";
            this.cbtnReceived.ReadOnly = true;
            this.cbtnReceived.Text = "";
            this.cbtnReceived.Width = 5;
            // 
            // NoticeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(797, 296);
            this.Controls.Add(this.customPanel2);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NoticeForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Received Notice";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.customPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnClear;
        private CustomUtil.controls.panel.CustomPanel customPanel2;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvNotice;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSender;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdatetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn cfilename;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpath;
        private System.Windows.Forms.DataGridViewButtonColumn cbtnReceived;
        private System.Windows.Forms.ToolStripButton tsbtnRefresh;
    }
}