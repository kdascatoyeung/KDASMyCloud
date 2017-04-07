namespace KDTHK_DM_SP.eforms.cm
{
    partial class CustomerForm
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
            this.watermarkTextbox1 = new CustomUtil.controls.textbox.WatermarkTextbox();
            this.dgvCustomer = new System.Windows.Forms.DataGridView();
            this.ccode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccurr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpayterm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // watermarkTextbox1
            // 
            this.watermarkTextbox1.FocusSelect = true;
            this.watermarkTextbox1.Location = new System.Drawing.Point(2, 1);
            this.watermarkTextbox1.Name = "watermarkTextbox1";
            this.watermarkTextbox1.PromptFont = new System.Drawing.Font("Calibri", 9F);
            this.watermarkTextbox1.PromptForeColor = System.Drawing.SystemColors.GrayText;
            this.watermarkTextbox1.PromptText = "Search here";
            this.watermarkTextbox1.Size = new System.Drawing.Size(587, 23);
            this.watermarkTextbox1.TabIndex = 0;
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.AllowUserToAddRows = false;
            this.dgvCustomer.AllowUserToDeleteRows = false;
            this.dgvCustomer.AllowUserToResizeRows = false;
            this.dgvCustomer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomer.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvCustomer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCustomer.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCustomer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ccode,
            this.cname,
            this.ccurr,
            this.cpayterm});
            this.dgvCustomer.Location = new System.Drawing.Point(2, 25);
            this.dgvCustomer.MultiSelect = false;
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.ReadOnly = true;
            this.dgvCustomer.RowHeadersVisible = false;
            this.dgvCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomer.Size = new System.Drawing.Size(587, 390);
            this.dgvCustomer.TabIndex = 1;
            this.dgvCustomer.DoubleClick += new System.EventHandler(this.dgvCustomer_DoubleClick);
            // 
            // ccode
            // 
            this.ccode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ccode.DataPropertyName = "code";
            this.ccode.HeaderText = "Cust. Code";
            this.ccode.Name = "ccode";
            this.ccode.ReadOnly = true;
            this.ccode.Width = 89;
            // 
            // cname
            // 
            this.cname.DataPropertyName = "name";
            this.cname.HeaderText = "Cust. Name";
            this.cname.Name = "cname";
            this.cname.ReadOnly = true;
            // 
            // ccurr
            // 
            this.ccurr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ccurr.DataPropertyName = "curr";
            this.ccurr.HeaderText = "Cust. Curr.";
            this.ccurr.Name = "ccurr";
            this.ccurr.ReadOnly = true;
            this.ccurr.Width = 88;
            // 
            // cpayterm
            // 
            this.cpayterm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cpayterm.DataPropertyName = "payterm";
            this.cpayterm.HeaderText = "Pay Term";
            this.cpayterm.Name = "cpayterm";
            this.cpayterm.ReadOnly = true;
            this.cpayterm.Width = 81;
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(590, 415);
            this.Controls.Add(this.dgvCustomer);
            this.Controls.Add(this.watermarkTextbox1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer List";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomUtil.controls.textbox.WatermarkTextbox watermarkTextbox1;
        private System.Windows.Forms.DataGridView dgvCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccurr;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpayterm;
    }
}