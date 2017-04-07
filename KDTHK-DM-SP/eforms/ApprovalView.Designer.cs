namespace KDTHK_DM_SP.eforms
{
    partial class ApprovalView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApprovalView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbtnApprove = new System.Windows.Forms.ToolStripButton();
            this.tsbtnReject = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.dgvForm = new System.Windows.Forms.DataGridView();
            this.capp = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cchaseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccreatedby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvApprove = new Zuby.ADGV.AdvancedDataGridView();
            this.cappnew = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cchasenonew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctypenew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctitlenew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccreatednew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccreatedbynew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctablenew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewRichTextBoxColumn1 = new KDTHK_DM_SP.controls.DataGridViewRichTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApprove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnRefresh,
            this.tsbtnApprove,
            this.tsbtnReject,
            this.tsbtnSave,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1161, 25);
            this.toolStrip1.TabIndex = 68;
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
            // tsbtnApprove
            // 
            this.tsbtnApprove.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnApprove.Image")));
            this.tsbtnApprove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnApprove.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tsbtnApprove.Name = "tsbtnApprove";
            this.tsbtnApprove.Size = new System.Drawing.Size(89, 22);
            this.tsbtnApprove.Text = "Approve All";
            this.tsbtnApprove.Click += new System.EventHandler(this.tsbtnApprove_Click);
            // 
            // tsbtnReject
            // 
            this.tsbtnReject.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnReject.Image")));
            this.tsbtnReject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnReject.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tsbtnReject.Name = "tsbtnReject";
            this.tsbtnReject.Size = new System.Drawing.Size(76, 22);
            this.tsbtnReject.Text = "Reject All";
            this.tsbtnReject.Click += new System.EventHandler(this.tsbtnReject_Click);
            // 
            // tsbtnSave
            // 
            this.tsbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSave.Image")));
            this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSave.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tsbtnSave.Name = "tsbtnSave";
            this.tsbtnSave.Size = new System.Drawing.Size(51, 22);
            this.tsbtnSave.Text = "Save";
            this.tsbtnSave.Click += new System.EventHandler(this.tsbtnSave_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Visible = false;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // dgvForm
            // 
            this.dgvForm.AllowUserToAddRows = false;
            this.dgvForm.AllowUserToDeleteRows = false;
            this.dgvForm.AllowUserToResizeRows = false;
            this.dgvForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvForm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvForm.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvForm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvForm.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvForm.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvForm.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvForm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.capp,
            this.cchaseno,
            this.ctype,
            this.ctitle,
            this.ccreated,
            this.ccreatedby,
            this.ctable});
            this.dgvForm.Location = new System.Drawing.Point(610, 3);
            this.dgvForm.MultiSelect = false;
            this.dgvForm.Name = "dgvForm";
            this.dgvForm.RowHeadersVisible = false;
            this.dgvForm.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dgvForm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvForm.Size = new System.Drawing.Size(65, 16);
            this.dgvForm.TabIndex = 69;
            this.dgvForm.Visible = false;
            this.dgvForm.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvForm_CellFormatting);
            this.dgvForm.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvForm_CellPainting);
            this.dgvForm.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvForm_ColumnAdded);
            this.dgvForm.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvForm_DataError);
            this.dgvForm.DoubleClick += new System.EventHandler(this.dgvForm_DoubleClick);
            // 
            // capp
            // 
            this.capp.DataPropertyName = "app";
            this.capp.FillWeight = 50F;
            this.capp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.capp.HeaderText = "Approval";
            this.capp.Items.AddRange(new object[] {
            "---",
            "Approve",
            "Reject"});
            this.capp.Name = "capp";
            // 
            // cchaseno
            // 
            this.cchaseno.DataPropertyName = "chaseno";
            this.cchaseno.FillWeight = 50F;
            this.cchaseno.HeaderText = "ChaseNo.";
            this.cchaseno.Name = "cchaseno";
            // 
            // ctype
            // 
            this.ctype.DataPropertyName = "type";
            this.ctype.FillWeight = 50F;
            this.ctype.HeaderText = "Type";
            this.ctype.Name = "ctype";
            this.ctype.ReadOnly = true;
            // 
            // ctitle
            // 
            this.ctitle.DataPropertyName = "title";
            this.ctitle.FillWeight = 93.27411F;
            this.ctitle.HeaderText = "Title";
            this.ctitle.Name = "ctitle";
            // 
            // ccreated
            // 
            this.ccreated.DataPropertyName = "created";
            this.ccreated.FillWeight = 50F;
            this.ccreated.HeaderText = "Created";
            this.ccreated.Name = "ccreated";
            this.ccreated.ReadOnly = true;
            // 
            // ccreatedby
            // 
            this.ccreatedby.DataPropertyName = "createdby";
            this.ccreatedby.FillWeight = 70F;
            this.ccreatedby.HeaderText = "CreatedBy";
            this.ccreatedby.Name = "ccreatedby";
            this.ccreatedby.ReadOnly = true;
            // 
            // ctable
            // 
            this.ctable.DataPropertyName = "tablename";
            this.ctable.HeaderText = "table";
            this.ctable.Name = "ctable";
            this.ctable.Visible = false;
            // 
            // dgvApprove
            // 
            this.dgvApprove.AllowUserToAddRows = false;
            this.dgvApprove.AllowUserToDeleteRows = false;
            this.dgvApprove.AllowUserToResizeRows = false;
            this.dgvApprove.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvApprove.AutoGenerateColumns = false;
            this.dgvApprove.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApprove.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvApprove.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvApprove.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvApprove.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvApprove.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApprove.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cappnew,
            this.cchasenonew,
            this.ctypenew,
            this.ctitlenew,
            this.ccreatednew,
            this.ccreatedbynew,
            this.ctablenew});
            this.dgvApprove.DataSource = this.bindingSource1;
            this.dgvApprove.FilterAndSortEnabled = true;
            this.dgvApprove.Location = new System.Drawing.Point(0, 25);
            this.dgvApprove.MultiSelect = false;
            this.dgvApprove.Name = "dgvApprove";
            this.dgvApprove.RowHeadersVisible = false;
            this.dgvApprove.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApprove.Size = new System.Drawing.Size(1161, 612);
            this.dgvApprove.TabIndex = 70;
            this.dgvApprove.SortStringChanged += new System.EventHandler(this.dgvApprove_SortStringChanged);
            this.dgvApprove.FilterStringChanged += new System.EventHandler(this.dgvApprove_FilterStringChanged);
            this.dgvApprove.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvApprove_DataError);
            this.dgvApprove.DoubleClick += new System.EventHandler(this.dgvApprove_DoubleClick);
            // 
            // cappnew
            // 
            this.cappnew.DataPropertyName = "app";
            this.cappnew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cappnew.HeaderText = "Approval";
            this.cappnew.Items.AddRange(new object[] {
            "---",
            "Approve",
            "Reject"});
            this.cappnew.MinimumWidth = 22;
            this.cappnew.Name = "cappnew";
            this.cappnew.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // cchasenonew
            // 
            this.cchasenonew.DataPropertyName = "chaseno";
            this.cchasenonew.HeaderText = "ChaseNo.";
            this.cchasenonew.MinimumWidth = 22;
            this.cchasenonew.Name = "cchasenonew";
            this.cchasenonew.ReadOnly = true;
            this.cchasenonew.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cchasenonew.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // ctypenew
            // 
            this.ctypenew.DataPropertyName = "type";
            this.ctypenew.HeaderText = "Type";
            this.ctypenew.MinimumWidth = 22;
            this.ctypenew.Name = "ctypenew";
            this.ctypenew.ReadOnly = true;
            this.ctypenew.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ctypenew.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // ctitlenew
            // 
            this.ctitlenew.DataPropertyName = "title";
            this.ctitlenew.HeaderText = "Title";
            this.ctitlenew.MinimumWidth = 22;
            this.ctitlenew.Name = "ctitlenew";
            this.ctitlenew.ReadOnly = true;
            this.ctitlenew.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // ccreatednew
            // 
            this.ccreatednew.DataPropertyName = "created";
            this.ccreatednew.HeaderText = "Created";
            this.ccreatednew.MinimumWidth = 22;
            this.ccreatednew.Name = "ccreatednew";
            this.ccreatednew.ReadOnly = true;
            this.ccreatednew.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // ccreatedbynew
            // 
            this.ccreatedbynew.DataPropertyName = "createdby";
            this.ccreatedbynew.HeaderText = "CreatedBy";
            this.ccreatedbynew.MinimumWidth = 22;
            this.ccreatedbynew.Name = "ccreatedbynew";
            this.ccreatedbynew.ReadOnly = true;
            this.ccreatedbynew.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // ctablenew
            // 
            this.ctablenew.DataPropertyName = "tablename";
            this.ctablenew.HeaderText = "table";
            this.ctablenew.MinimumWidth = 22;
            this.ctablenew.Name = "ctablenew";
            this.ctablenew.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ctablenew.Visible = false;
            // 
            // dataGridViewRichTextBoxColumn1
            // 
            this.dataGridViewRichTextBoxColumn1.HeaderText = "Content";
            this.dataGridViewRichTextBoxColumn1.Name = "dataGridViewRichTextBoxColumn1";
            this.dataGridViewRichTextBoxColumn1.Width = 900;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "content";
            this.dataGridViewImageColumn1.HeaderText = "Content";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 900;
            // 
            // ApprovalView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.dgvApprove);
            this.Controls.Add(this.dgvForm);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ApprovalView";
            this.Size = new System.Drawing.Size(1161, 640);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApprove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnRefresh;
        private System.Windows.Forms.ToolStripButton tsbtnApprove;
        private System.Windows.Forms.ToolStripButton tsbtnReject;
        private System.Windows.Forms.ToolStripButton tsbtnSave;
        private System.Windows.Forms.DataGridView dgvForm;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private controls.DataGridViewRichTextBoxColumn dataGridViewRichTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn capp;
        private System.Windows.Forms.DataGridViewTextBoxColumn cchaseno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctype;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccreatedby;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctable;
        private Zuby.ADGV.AdvancedDataGridView dgvApprove;
        private System.Windows.Forms.DataGridViewComboBoxColumn cappnew;
        private System.Windows.Forms.DataGridViewTextBoxColumn cchasenonew;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctypenew;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctitlenew;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccreatednew;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccreatedbynew;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctablenew;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}
