namespace KDTHK_DM_SP.eforms.acc.subforms
{
    partial class OutstandingPreviewDetailForm
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
            this.dgvPreview = new System.Windows.Forms.DataGridView();
            this.cvendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cacname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cccname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cremarks1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cremarks2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cremarks3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cremarks4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cremarks5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPreview
            // 
            this.dgvPreview.AllowUserToAddRows = false;
            this.dgvPreview.AllowUserToDeleteRows = false;
            this.dgvPreview.AllowUserToResizeRows = false;
            this.dgvPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPreview.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPreview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPreview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvPreview.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvPreview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cvendor,
            this.cname,
            this.cac,
            this.cacname,
            this.ccc,
            this.cccname,
            this.ctotal,
            this.cremarks1,
            this.cremarks2,
            this.cremarks3,
            this.cremarks4,
            this.cremarks5});
            this.dgvPreview.Location = new System.Drawing.Point(0, 0);
            this.dgvPreview.Name = "dgvPreview";
            this.dgvPreview.ReadOnly = true;
            this.dgvPreview.RowHeadersVisible = false;
            this.dgvPreview.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dgvPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPreview.Size = new System.Drawing.Size(1194, 510);
            this.dgvPreview.TabIndex = 71;
            // 
            // cvendor
            // 
            this.cvendor.DataPropertyName = "code";
            this.cvendor.FillWeight = 50F;
            this.cvendor.HeaderText = "Vendor";
            this.cvendor.Name = "cvendor";
            this.cvendor.ReadOnly = true;
            // 
            // cname
            // 
            this.cname.DataPropertyName = "name";
            this.cname.HeaderText = "Name";
            this.cname.Name = "cname";
            this.cname.ReadOnly = true;
            // 
            // cac
            // 
            this.cac.DataPropertyName = "ac";
            this.cac.HeaderText = "AccountCode";
            this.cac.Name = "cac";
            this.cac.ReadOnly = true;
            // 
            // cacname
            // 
            this.cacname.DataPropertyName = "acname";
            this.cacname.HeaderText = "AccountCodeName";
            this.cacname.Name = "cacname";
            this.cacname.ReadOnly = true;
            // 
            // ccc
            // 
            this.ccc.DataPropertyName = "cc";
            this.ccc.HeaderText = "CostCentre";
            this.ccc.Name = "ccc";
            this.ccc.ReadOnly = true;
            // 
            // cccname
            // 
            this.cccname.DataPropertyName = "ccname";
            this.cccname.HeaderText = "CostCentreName";
            this.cccname.Name = "cccname";
            this.cccname.ReadOnly = true;
            // 
            // ctotal
            // 
            this.ctotal.DataPropertyName = "amt";
            this.ctotal.FillWeight = 40F;
            this.ctotal.HeaderText = "Amount";
            this.ctotal.Name = "ctotal";
            this.ctotal.ReadOnly = true;
            // 
            // cremarks1
            // 
            this.cremarks1.DataPropertyName = "rm1";
            this.cremarks1.HeaderText = "Remarks1";
            this.cremarks1.Name = "cremarks1";
            this.cremarks1.ReadOnly = true;
            // 
            // cremarks2
            // 
            this.cremarks2.DataPropertyName = "rm2";
            this.cremarks2.HeaderText = "Remarks2";
            this.cremarks2.Name = "cremarks2";
            this.cremarks2.ReadOnly = true;
            // 
            // cremarks3
            // 
            this.cremarks3.DataPropertyName = "rm3";
            this.cremarks3.HeaderText = "Remarks3";
            this.cremarks3.Name = "cremarks3";
            this.cremarks3.ReadOnly = true;
            // 
            // cremarks4
            // 
            this.cremarks4.DataPropertyName = "rm4";
            this.cremarks4.HeaderText = "Remarks4";
            this.cremarks4.Name = "cremarks4";
            this.cremarks4.ReadOnly = true;
            // 
            // cremarks5
            // 
            this.cremarks5.DataPropertyName = "rm5";
            this.cremarks5.HeaderText = "Remarks5";
            this.cremarks5.Name = "cremarks5";
            this.cremarks5.ReadOnly = true;
            // 
            // OutstandingPreviewDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1195, 511);
            this.Controls.Add(this.dgvPreview);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OutstandingPreviewDetailForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OutstandingPreviewDetailForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPreview;
        private System.Windows.Forms.DataGridViewTextBoxColumn cvendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cname;
        private System.Windows.Forms.DataGridViewTextBoxColumn cac;
        private System.Windows.Forms.DataGridViewTextBoxColumn cacname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cccname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cremarks1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cremarks2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cremarks3;
        private System.Windows.Forms.DataGridViewTextBoxColumn cremarks4;
        private System.Windows.Forms.DataGridViewTextBoxColumn cremarks5;
    }
}