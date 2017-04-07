namespace KDTHK_DM_SP.eforms.acc.subforms
{
    partial class OutstandingErrorBox
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
            this.btnInput = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvError = new System.Windows.Forms.DataGridView();
            this.cindex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvError)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInput
            // 
            this.btnInput.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnInput.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInput.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInput.Location = new System.Drawing.Point(306, 311);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(128, 23);
            this.btnInput.TabIndex = 196;
            this.btnInput.Text = "OK";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 15);
            this.label1.TabIndex = 197;
            this.label1.Text = "Error found when uploading data";
            // 
            // dgvError
            // 
            this.dgvError.AllowUserToAddRows = false;
            this.dgvError.AllowUserToDeleteRows = false;
            this.dgvError.AllowUserToResizeRows = false;
            this.dgvError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvError.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvError.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvError.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvError.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvError.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvError.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvError.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cindex,
            this.cmsg});
            this.dgvError.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvError.Location = new System.Drawing.Point(1, 27);
            this.dgvError.Name = "dgvError";
            this.dgvError.RowHeadersVisible = false;
            this.dgvError.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvError.Size = new System.Drawing.Size(433, 278);
            this.dgvError.TabIndex = 198;
            // 
            // cindex
            // 
            this.cindex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cindex.HeaderText = "Index";
            this.cindex.Name = "cindex";
            this.cindex.Width = 62;
            // 
            // cmsg
            // 
            this.cmsg.HeaderText = "Message";
            this.cmsg.Name = "cmsg";
            // 
            // btnExport
            // 
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(172, 311);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(128, 23);
            this.btnExport.TabIndex = 199;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // OutstandingErrorBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(434, 346);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dgvError);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInput);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OutstandingErrorBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error Found";
            ((System.ComponentModel.ISupportInitialize)(this.dgvError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvError;
        private System.Windows.Forms.DataGridViewTextBoxColumn cindex;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmsg;
        private System.Windows.Forms.Button btnExport;
    }
}