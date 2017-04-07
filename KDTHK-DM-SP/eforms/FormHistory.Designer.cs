namespace KDTHK_DM_SP.eforms
{
    partial class FormHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHistory));
            this.dgvFormHistory1 = new System.Windows.Forms.DataGridView();
            this.cstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cremarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cstart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cchaseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msDebit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvFormHistory = new Zuby.ADGV.AdvancedDataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cnst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cntype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cntitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnremarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnstart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cncreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnrefno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormHistory1)).BeginInit();
            this.msDebit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFormHistory1
            // 
            this.dgvFormHistory1.AllowUserToAddRows = false;
            this.dgvFormHistory1.AllowUserToDeleteRows = false;
            this.dgvFormHistory1.AllowUserToResizeRows = false;
            this.dgvFormHistory1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFormHistory1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFormHistory1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvFormHistory1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFormHistory1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvFormHistory1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvFormHistory1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvFormHistory1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFormHistory1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cstatus,
            this.ctype,
            this.ctitle,
            this.cremarks,
            this.cstart,
            this.cend,
            this.ccreated,
            this.cchaseno});
            this.dgvFormHistory1.ContextMenuStrip = this.msDebit;
            this.dgvFormHistory1.Location = new System.Drawing.Point(1143, 517);
            this.dgvFormHistory1.MultiSelect = false;
            this.dgvFormHistory1.Name = "dgvFormHistory1";
            this.dgvFormHistory1.ReadOnly = true;
            this.dgvFormHistory1.RowHeadersVisible = false;
            this.dgvFormHistory1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dgvFormHistory1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFormHistory1.Size = new System.Drawing.Size(23, 33);
            this.dgvFormHistory1.TabIndex = 69;
            this.dgvFormHistory1.Visible = false;
            this.dgvFormHistory1.DoubleClick += new System.EventHandler(this.dgvFormHistory_DoubleClick);
            this.dgvFormHistory1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvFormHistory_MouseDown);
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
            // cstart
            // 
            this.cstart.DataPropertyName = "startdate";
            this.cstart.FillWeight = 50F;
            this.cstart.HeaderText = "Start";
            this.cstart.Name = "cstart";
            this.cstart.ReadOnly = true;
            this.cstart.Visible = false;
            // 
            // cend
            // 
            this.cend.DataPropertyName = "enddate";
            this.cend.FillWeight = 50F;
            this.cend.HeaderText = "End";
            this.cend.Name = "cend";
            this.cend.ReadOnly = true;
            this.cend.Visible = false;
            // 
            // ccreated
            // 
            this.ccreated.DataPropertyName = "created";
            this.ccreated.FillWeight = 50F;
            this.ccreated.HeaderText = "Created";
            this.ccreated.Name = "ccreated";
            this.ccreated.ReadOnly = true;
            // 
            // cchaseno
            // 
            this.cchaseno.DataPropertyName = "chaseno";
            this.cchaseno.HeaderText = "chaseno";
            this.cchaseno.Name = "cchaseno";
            this.cchaseno.ReadOnly = true;
            this.cchaseno.Visible = false;
            // 
            // msDebit
            // 
            this.msDebit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msDebit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem});
            this.msDebit.Name = "msDebit";
            this.msDebit.Size = new System.Drawing.Size(102, 26);
            this.msDebit.Opening += new System.ComponentModel.CancelEventHandler(this.msDebit_Opening);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // dgvFormHistory
            // 
            this.dgvFormHistory.AllowUserToAddRows = false;
            this.dgvFormHistory.AllowUserToDeleteRows = false;
            this.dgvFormHistory.AllowUserToResizeRows = false;
            this.dgvFormHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFormHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFormHistory.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvFormHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFormHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvFormHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvFormHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFormHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnst,
            this.cntype,
            this.cntitle,
            this.cnremarks,
            this.cnstart,
            this.cnend,
            this.cncreated,
            this.cnrefno});
            this.dgvFormHistory.ContextMenuStrip = this.msDebit;
            this.dgvFormHistory.FilterAndSortEnabled = true;
            this.dgvFormHistory.Location = new System.Drawing.Point(0, 0);
            this.dgvFormHistory.Name = "dgvFormHistory";
            this.dgvFormHistory.ReadOnly = true;
            this.dgvFormHistory.RowHeadersVisible = false;
            this.dgvFormHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFormHistory.Size = new System.Drawing.Size(1226, 639);
            this.dgvFormHistory.TabIndex = 71;
            this.dgvFormHistory.SortStringChanged += new System.EventHandler(this.dgvFormHistory_SortStringChanged);
            this.dgvFormHistory.FilterStringChanged += new System.EventHandler(this.dgvFormHistory_FilterStringChanged);
            this.dgvFormHistory.DoubleClick += new System.EventHandler(this.dgvFormHistory_DoubleClick);
            this.dgvFormHistory.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvFormHistory_MouseDown);
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
            // cnstart
            // 
            this.cnstart.DataPropertyName = "startdate";
            this.cnstart.HeaderText = "Start";
            this.cnstart.MinimumWidth = 22;
            this.cnstart.Name = "cnstart";
            this.cnstart.ReadOnly = true;
            this.cnstart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.cnstart.Visible = false;
            // 
            // cnend
            // 
            this.cnend.DataPropertyName = "enddate";
            this.cnend.HeaderText = "End";
            this.cnend.MinimumWidth = 22;
            this.cnend.Name = "cnend";
            this.cnend.ReadOnly = true;
            this.cnend.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.cnend.Visible = false;
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
            // cnrefno
            // 
            this.cnrefno.DataPropertyName = "chaseno";
            this.cnrefno.HeaderText = "refno";
            this.cnrefno.MinimumWidth = 22;
            this.cnrefno.Name = "cnrefno";
            this.cnrefno.ReadOnly = true;
            this.cnrefno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.cnrefno.Visible = false;
            // 
            // FormHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.dgvFormHistory);
            this.Controls.Add(this.dgvFormHistory1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormHistory";
            this.Size = new System.Drawing.Size(1226, 639);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormHistory1)).EndInit();
            this.msDebit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFormHistory1;
        private System.Windows.Forms.ContextMenuStrip msDebit;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn cstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctype;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn cremarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn cstart;
        private System.Windows.Forms.DataGridViewTextBoxColumn cend;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn cchaseno;
        private Zuby.ADGV.AdvancedDataGridView dgvFormHistory;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnst;
        private System.Windows.Forms.DataGridViewTextBoxColumn cntype;
        private System.Windows.Forms.DataGridViewTextBoxColumn cntitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnremarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnstart;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnend;
        private System.Windows.Forms.DataGridViewTextBoxColumn cncreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnrefno;
    }
}
