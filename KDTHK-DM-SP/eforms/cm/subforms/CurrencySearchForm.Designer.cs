namespace KDTHK_DM_SP.eforms.cm.subforms
{
    partial class CurrencySearchForm
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
            this.txtSearch = new CustomUtil.controls.textbox.WatermarkTextbox();
            this.dgvCurrency = new System.Windows.Forms.DataGridView();
            this.cmonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.citem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrency)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.FocusSelect = true;
            this.txtSearch.Location = new System.Drawing.Point(1, 1);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PromptFont = new System.Drawing.Font("Calibri", 9F);
            this.txtSearch.PromptForeColor = System.Drawing.SystemColors.GrayText;
            this.txtSearch.PromptText = "Search here";
            this.txtSearch.Size = new System.Drawing.Size(259, 23);
            this.txtSearch.TabIndex = 72;
            // 
            // dgvCurrency
            // 
            this.dgvCurrency.AllowUserToAddRows = false;
            this.dgvCurrency.AllowUserToDeleteRows = false;
            this.dgvCurrency.AllowUserToResizeRows = false;
            this.dgvCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCurrency.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCurrency.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvCurrency.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCurrency.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvCurrency.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvCurrency.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCurrency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrency.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmonth,
            this.citem,
            this.cdesc,
            this.crate});
            this.dgvCurrency.Location = new System.Drawing.Point(1, 26);
            this.dgvCurrency.MultiSelect = false;
            this.dgvCurrency.Name = "dgvCurrency";
            this.dgvCurrency.RowHeadersVisible = false;
            this.dgvCurrency.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dgvCurrency.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCurrency.Size = new System.Drawing.Size(623, 273);
            this.dgvCurrency.TabIndex = 73;
            this.dgvCurrency.DoubleClick += new System.EventHandler(this.dgvCurrency_DoubleClick);
            // 
            // cmonth
            // 
            this.cmonth.DataPropertyName = "mon";
            this.cmonth.HeaderText = "Month";
            this.cmonth.Name = "cmonth";
            // 
            // citem
            // 
            this.citem.DataPropertyName = "item";
            this.citem.HeaderText = "Item";
            this.citem.Name = "citem";
            // 
            // cdesc
            // 
            this.cdesc.DataPropertyName = "description";
            this.cdesc.HeaderText = "Description";
            this.cdesc.Name = "cdesc";
            // 
            // crate
            // 
            this.crate.DataPropertyName = "rate";
            this.crate.HeaderText = "Rate";
            this.crate.Name = "crate";
            // 
            // CurrencySearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(624, 301);
            this.Controls.Add(this.dgvCurrency);
            this.Controls.Add(this.txtSearch);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CurrencySearchForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exchange Rate";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomUtil.controls.textbox.WatermarkTextbox txtSearch;
        private System.Windows.Forms.DataGridView dgvCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn citem;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn crate;
    }
}