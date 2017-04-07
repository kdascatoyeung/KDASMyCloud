namespace KDTHK_DM_SP.eforms.cm.subforms
{
    partial class CustomerSearchForm
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
            this.dgvCustomer = new System.Windows.Forms.DataGridView();
            this.txtSearch = new CustomUtil.controls.textbox.WatermarkTextbox();
            this.ccustcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccustname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccustcurr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccustpayterm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.AllowUserToAddRows = false;
            this.dgvCustomer.AllowUserToDeleteRows = false;
            this.dgvCustomer.AllowUserToResizeRows = false;
            this.dgvCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCustomer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomer.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvCustomer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCustomer.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvCustomer.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvCustomer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ccustcode,
            this.ccustname,
            this.ccustcurr,
            this.ccustpayterm,
            this.currtype,
            this.currdesc});
            this.dgvCustomer.Location = new System.Drawing.Point(2, 27);
            this.dgvCustomer.MultiSelect = false;
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.ReadOnly = true;
            this.dgvCustomer.RowHeadersVisible = false;
            this.dgvCustomer.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dgvCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomer.Size = new System.Drawing.Size(708, 241);
            this.dgvCustomer.TabIndex = 70;
            this.dgvCustomer.DoubleClick += new System.EventHandler(this.dgvCustomer_DoubleClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.FocusSelect = true;
            this.txtSearch.Location = new System.Drawing.Point(2, 1);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PromptFont = new System.Drawing.Font("Calibri", 9F);
            this.txtSearch.PromptForeColor = System.Drawing.SystemColors.GrayText;
            this.txtSearch.PromptText = "Search here";
            this.txtSearch.Size = new System.Drawing.Size(259, 23);
            this.txtSearch.TabIndex = 71;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // ccustcode
            // 
            this.ccustcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ccustcode.DataPropertyName = "code";
            this.ccustcode.HeaderText = "Cust. Code";
            this.ccustcode.Name = "ccustcode";
            this.ccustcode.ReadOnly = true;
            this.ccustcode.Width = 89;
            // 
            // ccustname
            // 
            this.ccustname.DataPropertyName = "name";
            this.ccustname.HeaderText = "Cust. Name";
            this.ccustname.Name = "ccustname";
            this.ccustname.ReadOnly = true;
            // 
            // ccustcurr
            // 
            this.ccustcurr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ccustcurr.DataPropertyName = "curr";
            this.ccustcurr.HeaderText = "Cust. Curr.";
            this.ccustcurr.Name = "ccustcurr";
            this.ccustcurr.ReadOnly = true;
            this.ccustcurr.Width = 88;
            // 
            // ccustpayterm
            // 
            this.ccustpayterm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ccustpayterm.DataPropertyName = "payterm";
            this.ccustpayterm.HeaderText = "PayTerm";
            this.ccustpayterm.Name = "ccustpayterm";
            this.ccustpayterm.ReadOnly = true;
            this.ccustpayterm.Width = 78;
            // 
            // currtype
            // 
            this.currtype.DataPropertyName = "currtype";
            this.currtype.HeaderText = "currtype";
            this.currtype.Name = "currtype";
            this.currtype.ReadOnly = true;
            this.currtype.Visible = false;
            // 
            // currdesc
            // 
            this.currdesc.DataPropertyName = "currdesc";
            this.currdesc.HeaderText = "currdesc";
            this.currdesc.Name = "currdesc";
            this.currdesc.ReadOnly = true;
            this.currdesc.Visible = false;
            // 
            // CustomerSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(711, 272);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvCustomer);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerSearchForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Customer";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCustomer;
        private CustomUtil.controls.textbox.WatermarkTextbox txtSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccustcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccustname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccustcurr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccustpayterm;
        private System.Windows.Forms.DataGridViewTextBoxColumn currtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn currdesc;
    }
}