namespace KDTHK_DM_SP.eforms.hra
{
    partial class FormIT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIT));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnNew = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.dgvForm = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.cstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cstart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capprover = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capproval = new System.Windows.Forms.DataGridViewImageColumn();
            this.crefno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForm)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(1227, 25);
            this.toolStrip1.TabIndex = 67;
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
            this.cstatus,
            this.ctype,
            this.ctitle,
            this.cstart,
            this.cend,
            this.ccreated,
            this.capprover,
            this.capproval,
            this.crefno});
            this.dgvForm.Location = new System.Drawing.Point(0, 25);
            this.dgvForm.MultiSelect = false;
            this.dgvForm.Name = "dgvForm";
            this.dgvForm.ReadOnly = true;
            this.dgvForm.RowHeadersVisible = false;
            this.dgvForm.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dgvForm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvForm.Size = new System.Drawing.Size(1227, 614);
            this.dgvForm.TabIndex = 68;
            this.dgvForm.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvForm_CellFormatting);
            this.dgvForm.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvForm_ColumnAdded);
            this.dgvForm.DoubleClick += new System.EventHandler(this.dgvForm_DoubleClick);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewImageColumn1.DataPropertyName = "approval";
            this.dataGridViewImageColumn1.HeaderText = "Approval";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 55;
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
            // cstart
            // 
            this.cstart.DataPropertyName = "startdate";
            this.cstart.FillWeight = 50F;
            this.cstart.HeaderText = "Start";
            this.cstart.Name = "cstart";
            this.cstart.ReadOnly = true;
            // 
            // cend
            // 
            this.cend.DataPropertyName = "enddate";
            this.cend.FillWeight = 50F;
            this.cend.HeaderText = "End";
            this.cend.Name = "cend";
            this.cend.ReadOnly = true;
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
            this.capprover.DataPropertyName = "approver";
            this.capprover.FillWeight = 80F;
            this.capprover.HeaderText = "Approver";
            this.capprover.Name = "capprover";
            this.capprover.ReadOnly = true;
            // 
            // capproval
            // 
            this.capproval.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.capproval.DataPropertyName = "approval";
            this.capproval.HeaderText = "Approval";
            this.capproval.Name = "capproval";
            this.capproval.ReadOnly = true;
            this.capproval.Width = 63;
            // 
            // crefno
            // 
            this.crefno.DataPropertyName = "refno";
            this.crefno.HeaderText = "refno";
            this.crefno.Name = "crefno";
            this.crefno.ReadOnly = true;
            this.crefno.Visible = false;
            // 
            // FormIT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgvForm);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormIT";
            this.Size = new System.Drawing.Size(1227, 639);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnRefresh;
        private System.Windows.Forms.ToolStripButton tsbtnNew;
        private System.Windows.Forms.DataGridView dgvForm;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctype;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn cstart;
        private System.Windows.Forms.DataGridViewTextBoxColumn cend;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn capprover;
        private System.Windows.Forms.DataGridViewImageColumn capproval;
        private System.Windows.Forms.DataGridViewTextBoxColumn crefno;

    }
}
