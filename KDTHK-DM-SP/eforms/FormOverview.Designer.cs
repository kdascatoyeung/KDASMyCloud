namespace KDTHK_DM_SP.eforms
{
    partial class FormOverview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOverview));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnNew = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.dgvForm1 = new System.Windows.Forms.DataGridView();
            this.cstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cremarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capprover = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crefno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msDebit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeApproverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvForm = new Zuby.ADGV.AdvancedDataGridView();
            this.cnst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cntype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cntitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnremarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cncreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnapprover = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnrefno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsForm = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForm1)).BeginInit();
            this.msDebit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsForm)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.AliceBlue;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnNew,
            this.tsbtnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1174, 25);
            this.toolStrip1.TabIndex = 68;
            this.toolStrip1.Text = "toolStrip1";
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
            // dgvForm1
            // 
            this.dgvForm1.AllowUserToAddRows = false;
            this.dgvForm1.AllowUserToDeleteRows = false;
            this.dgvForm1.AllowUserToResizeRows = false;
            this.dgvForm1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvForm1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvForm1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvForm1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvForm1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvForm1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvForm1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvForm1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvForm1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cstatus,
            this.ctype,
            this.ctitle,
            this.cremarks,
            this.ccreated,
            this.capprover,
            this.crefno});
            this.dgvForm1.ContextMenuStrip = this.msDebit;
            this.dgvForm1.Location = new System.Drawing.Point(785, 0);
            this.dgvForm1.Name = "dgvForm1";
            this.dgvForm1.ReadOnly = true;
            this.dgvForm1.RowHeadersVisible = false;
            this.dgvForm1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dgvForm1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvForm1.Size = new System.Drawing.Size(66, 10);
            this.dgvForm1.TabIndex = 69;
            this.dgvForm1.Visible = false;
            this.dgvForm1.DoubleClick += new System.EventHandler(this.dgvForm_DoubleClick);
            this.dgvForm1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvForm_MouseDown);
            // 
            // cstatus
            // 
            this.cstatus.DataPropertyName = "st";
            this.cstatus.FillWeight = 50F;
            this.cstatus.HeaderText = "Status";
            this.cstatus.Name = "cstatus";
            this.cstatus.ReadOnly = true;
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
            this.ctitle.HeaderText = "Title";
            this.ctitle.Name = "ctitle";
            this.ctitle.ReadOnly = true;
            // 
            // cremarks
            // 
            this.cremarks.DataPropertyName = "remarks";
            this.cremarks.HeaderText = "Remarks";
            this.cremarks.Name = "cremarks";
            this.cremarks.ReadOnly = true;
            // 
            // ccreated
            // 
            this.ccreated.DataPropertyName = "created";
            this.ccreated.FillWeight = 50F;
            this.ccreated.HeaderText = "Created";
            this.ccreated.Name = "ccreated";
            this.ccreated.ReadOnly = true;
            // 
            // capprover
            // 
            this.capprover.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.capprover.DataPropertyName = "approver";
            this.capprover.FillWeight = 80F;
            this.capprover.HeaderText = "Approver";
            this.capprover.Name = "capprover";
            this.capprover.ReadOnly = true;
            this.capprover.Width = 82;
            // 
            // crefno
            // 
            this.crefno.DataPropertyName = "refno";
            this.crefno.HeaderText = "refno";
            this.crefno.Name = "crefno";
            this.crefno.ReadOnly = true;
            this.crefno.Visible = false;
            // 
            // msDebit
            // 
            this.msDebit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msDebit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sendToolStripMenuItem,
            this.changeApproverToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.msDebit.Name = "msDebit";
            this.msDebit.Size = new System.Drawing.Size(206, 136);
            this.msDebit.Opening += new System.ComponentModel.CancelEventHandler(this.msDebit_Opening);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.printToolStripMenuItem.Text = "Print Debit / Credit Note";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // sendToolStripMenuItem
            // 
            this.sendToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sendToolStripMenuItem.Image")));
            this.sendToolStripMenuItem.Name = "sendToolStripMenuItem";
            this.sendToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.sendToolStripMenuItem.Text = "Send";
            this.sendToolStripMenuItem.Click += new System.EventHandler(this.sendToolStripMenuItem_Click);
            // 
            // changeApproverToolStripMenuItem
            // 
            this.changeApproverToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("changeApproverToolStripMenuItem.Image")));
            this.changeApproverToolStripMenuItem.Name = "changeApproverToolStripMenuItem";
            this.changeApproverToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.changeApproverToolStripMenuItem.Text = "Change Approver";
            this.changeApproverToolStripMenuItem.Click += new System.EventHandler(this.changeApproverToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
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
            this.dgvForm.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvForm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnst,
            this.cntype,
            this.cntitle,
            this.cnremarks,
            this.cncreated,
            this.cnapprover,
            this.cnrefno});
            this.dgvForm.ContextMenuStrip = this.msDebit;
            this.dgvForm.FilterAndSortEnabled = true;
            this.dgvForm.Location = new System.Drawing.Point(0, 25);
            this.dgvForm.Name = "dgvForm";
            this.dgvForm.ReadOnly = true;
            this.dgvForm.RowHeadersVisible = false;
            this.dgvForm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvForm.Size = new System.Drawing.Size(1174, 618);
            this.dgvForm.TabIndex = 70;
            this.dgvForm.SortStringChanged += new System.EventHandler(this.dgvForm_SortStringChanged);
            this.dgvForm.FilterStringChanged += new System.EventHandler(this.dgvForm_FilterStringChanged);
            this.dgvForm.DoubleClick += new System.EventHandler(this.dgvForm_DoubleClick);
            this.dgvForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvForm_MouseDown);
            // 
            // cnst
            // 
            this.cnst.DataPropertyName = "st";
            this.cnst.FillWeight = 25F;
            this.cnst.HeaderText = "Status";
            this.cnst.MinimumWidth = 22;
            this.cnst.Name = "cnst";
            this.cnst.ReadOnly = true;
            this.cnst.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // cntype
            // 
            this.cntype.DataPropertyName = "type";
            this.cntype.FillWeight = 25F;
            this.cntype.HeaderText = "Type";
            this.cntype.MinimumWidth = 22;
            this.cntype.Name = "cntype";
            this.cntype.ReadOnly = true;
            this.cntype.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // cntitle
            // 
            this.cntitle.DataPropertyName = "title";
            this.cntitle.FillWeight = 67.71574F;
            this.cntitle.HeaderText = "Title";
            this.cntitle.MinimumWidth = 22;
            this.cntitle.Name = "cntitle";
            this.cntitle.ReadOnly = true;
            this.cntitle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // cnremarks
            // 
            this.cnremarks.DataPropertyName = "remarks";
            this.cnremarks.FillWeight = 67.71574F;
            this.cnremarks.HeaderText = "Remarks";
            this.cnremarks.MinimumWidth = 22;
            this.cnremarks.Name = "cnremarks";
            this.cnremarks.ReadOnly = true;
            this.cnremarks.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // cncreated
            // 
            this.cncreated.DataPropertyName = "created";
            this.cncreated.FillWeight = 40F;
            this.cncreated.HeaderText = "Created";
            this.cncreated.MinimumWidth = 22;
            this.cncreated.Name = "cncreated";
            this.cncreated.ReadOnly = true;
            this.cncreated.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // cnapprover
            // 
            this.cnapprover.DataPropertyName = "approver";
            this.cnapprover.FillWeight = 30F;
            this.cnapprover.HeaderText = "Approver";
            this.cnapprover.MinimumWidth = 22;
            this.cnapprover.Name = "cnapprover";
            this.cnapprover.ReadOnly = true;
            this.cnapprover.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // cnrefno
            // 
            this.cnrefno.DataPropertyName = "refno";
            this.cnrefno.HeaderText = "refno";
            this.cnrefno.MinimumWidth = 22;
            this.cnrefno.Name = "cnrefno";
            this.cnrefno.ReadOnly = true;
            this.cnrefno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.cnrefno.Visible = false;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItem1.Text = "Print Outstanding Slip";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // FormOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.dgvForm);
            this.Controls.Add(this.dgvForm1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormOverview";
            this.Size = new System.Drawing.Size(1174, 643);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForm1)).EndInit();
            this.msDebit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsForm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnNew;
        private System.Windows.Forms.ToolStripButton tsbtnRefresh;
        private System.Windows.Forms.DataGridView dgvForm1;
        private System.Windows.Forms.ContextMenuStrip msDebit;
        private System.Windows.Forms.ToolStripMenuItem sendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn cstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctype;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn cremarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn capprover;
        private System.Windows.Forms.DataGridViewTextBoxColumn crefno;
        private Zuby.ADGV.AdvancedDataGridView dgvForm;
        private System.Windows.Forms.BindingSource bsForm;
        private System.Windows.Forms.ToolStripMenuItem changeApproverToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnst;
        private System.Windows.Forms.DataGridViewTextBoxColumn cntype;
        private System.Windows.Forms.DataGridViewTextBoxColumn cntitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnremarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn cncreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnapprover;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnrefno;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}
