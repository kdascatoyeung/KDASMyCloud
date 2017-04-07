namespace KDTHK_DM_SP.eforms.acc
{
    partial class OutstandingViewForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInvoice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVendorName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVendorCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCurrency = new System.Windows.Forms.TextBox();
            this.customPanel3 = new CustomUtil.controls.panel.CustomPanel();
            this.dgvOutstanding = new System.Windows.Forms.DataGridView();
            this.cac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cacname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccostcentre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccostcentrename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.camount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdesc1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdesc2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdesc3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdesc4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdesc5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtInputDate = new System.Windows.Forms.TextBox();
            this.txtPayDate = new System.Windows.Forms.TextBox();
            this.gbOverall = new System.Windows.Forms.GroupBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.customPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutstanding)).BeginInit();
            this.gbOverall.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.panel2.Location = new System.Drawing.Point(442, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(192, 4);
            this.panel2.TabIndex = 69;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(438, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(203, 29);
            this.lblTitle.TabIndex = 68;
            this.lblTitle.Text = "OUTSTANDING SLIP";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(416, 108);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(190, 23);
            this.txtAmount.TabIndex = 206;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressed);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(319, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 15);
            this.label7.TabIndex = 205;
            this.label7.Text = "Invoice Amount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 15);
            this.label6.TabIndex = 204;
            this.label6.Text = "Currency";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(620, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 202;
            this.label5.Text = "Payment Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(346, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 200;
            this.label4.Text = "Input Date";
            // 
            // txtInvoice
            // 
            this.txtInvoice.Location = new System.Drawing.Point(99, 79);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(214, 23);
            this.txtInvoice.TabIndex = 199;
            this.txtInvoice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 198;
            this.label3.Text = "Invoice #";
            // 
            // txtVendorName
            // 
            this.txtVendorName.Location = new System.Drawing.Point(416, 50);
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.Size = new System.Drawing.Size(487, 23);
            this.txtVendorName.TabIndex = 197;
            this.txtVendorName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(332, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 196;
            this.label2.Text = "Vendor name";
            // 
            // txtVendorCode
            // 
            this.txtVendorCode.Location = new System.Drawing.Point(99, 50);
            this.txtVendorCode.Name = "txtVendorCode";
            this.txtVendorCode.Size = new System.Drawing.Size(214, 23);
            this.txtVendorCode.TabIndex = 195;
            this.txtVendorCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 194;
            this.label1.Text = "Vendor code";
            // 
            // txtCurrency
            // 
            this.txtCurrency.Location = new System.Drawing.Point(99, 108);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(214, 23);
            this.txtCurrency.TabIndex = 208;
            this.txtCurrency.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressed);
            // 
            // customPanel3
            // 
            this.customPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanel3.BackColor = System.Drawing.SystemColors.Window;
            this.customPanel3.BackColor2 = System.Drawing.SystemColors.Window;
            this.customPanel3.BorderColor = System.Drawing.Color.Silver;
            this.customPanel3.BorderWidth = 1;
            this.customPanel3.Controls.Add(this.dgvOutstanding);
            this.customPanel3.Curvature = 1;
            this.customPanel3.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.customPanel3.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.customPanel3.Location = new System.Drawing.Point(0, 137);
            this.customPanel3.Name = "customPanel3";
            this.customPanel3.Size = new System.Drawing.Size(1102, 403);
            this.customPanel3.TabIndex = 209;
            // 
            // dgvOutstanding
            // 
            this.dgvOutstanding.AllowUserToAddRows = false;
            this.dgvOutstanding.AllowUserToDeleteRows = false;
            this.dgvOutstanding.AllowUserToResizeRows = false;
            this.dgvOutstanding.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOutstanding.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvOutstanding.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOutstanding.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvOutstanding.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutstanding.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cac,
            this.cacname,
            this.ccostcentre,
            this.ccostcentrename,
            this.camount,
            this.cdesc1,
            this.cdesc2,
            this.cdesc3,
            this.cdesc4,
            this.cdesc5,
            this.cdesc});
            this.dgvOutstanding.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvOutstanding.Location = new System.Drawing.Point(3, 3);
            this.dgvOutstanding.Name = "dgvOutstanding";
            this.dgvOutstanding.ReadOnly = true;
            this.dgvOutstanding.RowHeadersVisible = false;
            this.dgvOutstanding.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvOutstanding.Size = new System.Drawing.Size(1096, 397);
            this.dgvOutstanding.TabIndex = 0;
            // 
            // cac
            // 
            this.cac.DataPropertyName = "acc";
            this.cac.HeaderText = "AccountCode";
            this.cac.Name = "cac";
            this.cac.ReadOnly = true;
            this.cac.Width = 110;
            // 
            // cacname
            // 
            this.cacname.DataPropertyName = "accname";
            this.cacname.HeaderText = "AccountName";
            this.cacname.Name = "cacname";
            this.cacname.ReadOnly = true;
            this.cacname.Width = 109;
            // 
            // ccostcentre
            // 
            this.ccostcentre.DataPropertyName = "cc";
            this.ccostcentre.HeaderText = "CostCentre";
            this.ccostcentre.Name = "ccostcentre";
            this.ccostcentre.ReadOnly = true;
            this.ccostcentre.Width = 110;
            // 
            // ccostcentrename
            // 
            this.ccostcentrename.DataPropertyName = "ccname";
            this.ccostcentrename.HeaderText = "CostCentreName";
            this.ccostcentrename.Name = "ccostcentrename";
            this.ccostcentrename.ReadOnly = true;
            this.ccostcentrename.Width = 109;
            // 
            // camount
            // 
            this.camount.DataPropertyName = "amount";
            this.camount.HeaderText = "Amount";
            this.camount.Name = "camount";
            this.camount.ReadOnly = true;
            this.camount.Width = 110;
            // 
            // cdesc1
            // 
            this.cdesc1.DataPropertyName = "desc1";
            this.cdesc1.HeaderText = "Remarks 1";
            this.cdesc1.MaxInputLength = 50;
            this.cdesc1.Name = "cdesc1";
            this.cdesc1.ReadOnly = true;
            this.cdesc1.Width = 109;
            // 
            // cdesc2
            // 
            this.cdesc2.DataPropertyName = "desc2";
            this.cdesc2.HeaderText = "Remarks 2";
            this.cdesc2.MaxInputLength = 50;
            this.cdesc2.Name = "cdesc2";
            this.cdesc2.ReadOnly = true;
            this.cdesc2.Width = 110;
            // 
            // cdesc3
            // 
            this.cdesc3.DataPropertyName = "desc3";
            this.cdesc3.HeaderText = "Remarks 3";
            this.cdesc3.MaxInputLength = 50;
            this.cdesc3.Name = "cdesc3";
            this.cdesc3.ReadOnly = true;
            this.cdesc3.Width = 109;
            // 
            // cdesc4
            // 
            this.cdesc4.DataPropertyName = "desc4";
            this.cdesc4.HeaderText = "Remarks 4";
            this.cdesc4.MaxInputLength = 50;
            this.cdesc4.Name = "cdesc4";
            this.cdesc4.ReadOnly = true;
            this.cdesc4.Width = 110;
            // 
            // cdesc5
            // 
            this.cdesc5.DataPropertyName = "desc5";
            this.cdesc5.HeaderText = "Remarks 5";
            this.cdesc5.MaxInputLength = 50;
            this.cdesc5.Name = "cdesc5";
            this.cdesc5.ReadOnly = true;
            this.cdesc5.Width = 109;
            // 
            // cdesc
            // 
            this.cdesc.DataPropertyName = "descdisplay";
            this.cdesc.HeaderText = "Description";
            this.cdesc.Name = "cdesc";
            this.cdesc.ReadOnly = true;
            // 
            // btnReject
            // 
            this.btnReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReject.BackColor = System.Drawing.Color.LightCoral;
            this.btnReject.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReject.Location = new System.Drawing.Point(915, 546);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(89, 29);
            this.btnReject.TabIndex = 211;
            this.btnReject.Tag = "reject";
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Visible = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApprove.BackColor = System.Drawing.Color.SpringGreen;
            this.btnApprove.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprove.Location = new System.Drawing.Point(820, 546);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(89, 29);
            this.btnApprove.TabIndex = 210;
            this.btnApprove.Tag = "approve";
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Visible = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(1010, 546);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(89, 29);
            this.btnOK.TabIndex = 212;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtInputDate
            // 
            this.txtInputDate.Location = new System.Drawing.Point(416, 79);
            this.txtInputDate.Name = "txtInputDate";
            this.txtInputDate.Size = new System.Drawing.Size(190, 23);
            this.txtInputDate.TabIndex = 213;
            this.txtInputDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressed);
            // 
            // txtPayDate
            // 
            this.txtPayDate.Location = new System.Drawing.Point(708, 79);
            this.txtPayDate.Name = "txtPayDate";
            this.txtPayDate.Size = new System.Drawing.Size(195, 23);
            this.txtPayDate.TabIndex = 214;
            this.txtPayDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressed);
            // 
            // gbOverall
            // 
            this.gbOverall.Controls.Add(this.btnUpload);
            this.gbOverall.Controls.Add(this.btnDownload);
            this.gbOverall.Location = new System.Drawing.Point(909, 41);
            this.gbOverall.Name = "gbOverall";
            this.gbOverall.Size = new System.Drawing.Size(190, 90);
            this.gbOverall.TabIndex = 215;
            this.gbOverall.TabStop = false;
            this.gbOverall.Text = "Overall";
            // 
            // btnUpload
            // 
            this.btnUpload.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.Location = new System.Drawing.Point(6, 52);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(175, 24);
            this.btnUpload.TabIndex = 214;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownload.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.Location = new System.Drawing.Point(6, 22);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(175, 24);
            this.btnDownload.TabIndex = 213;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // OutstandingViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1102, 587);
            this.Controls.Add(this.gbOverall);
            this.Controls.Add(this.txtPayDate);
            this.Controls.Add(this.txtInputDate);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.customPanel3);
            this.Controls.Add(this.txtCurrency);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtInvoice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVendorName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVendorCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OutstandingViewForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OutstandingViewForm";
            this.customPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutstanding)).EndInit();
            this.gbOverall.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInvoice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVendorName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVendorCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCurrency;
        private CustomUtil.controls.panel.CustomPanel customPanel3;
        private System.Windows.Forms.DataGridView dgvOutstanding;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtInputDate;
        private System.Windows.Forms.TextBox txtPayDate;
        private System.Windows.Forms.GroupBox gbOverall;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.DataGridViewTextBoxColumn cac;
        private System.Windows.Forms.DataGridViewTextBoxColumn cacname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccostcentre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccostcentrename;
        private System.Windows.Forms.DataGridViewTextBoxColumn camount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdesc1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdesc2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdesc3;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdesc4;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdesc5;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdesc;
    }
}