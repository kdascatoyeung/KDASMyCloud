namespace KDTHK_DM_SP.eforms.acc
{
    partial class OutstandingForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutstandingForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtVendorCode = new System.Windows.Forms.TextBox();
            this.txtVendorName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInvoice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpInput = new System.Windows.Forms.DateTimePicker();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.customPanel3 = new CustomUtil.controls.panel.CustomPanel();
            this.dgvOutstanding = new System.Windows.Forms.DataGridView();
            this.cac = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cacname = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ccostcentre = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ccostcentrename = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.camount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdesc1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdesc2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdesc3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdesc4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdesc5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbCurr = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnTemplate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pbTick = new System.Windows.Forms.PictureBox();
            this.btnSearch2 = new System.Windows.Forms.Button();
            this.btnSearch1 = new System.Windows.Forms.Button();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.cimg = new System.Windows.Forms.DataGridViewImageColumn();
            this.customPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutstanding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTick)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vendor code";
            // 
            // txtVendorCode
            // 
            this.txtVendorCode.Location = new System.Drawing.Point(91, 54);
            this.txtVendorCode.MaxLength = 10;
            this.txtVendorCode.Name = "txtVendorCode";
            this.txtVendorCode.Size = new System.Drawing.Size(214, 23);
            this.txtVendorCode.TabIndex = 1;
            this.txtVendorCode.TextChanged += new System.EventHandler(this.txtVendorCode_TextChanged);
            this.txtVendorCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVendorCode_KeyDown);
            // 
            // txtVendorName
            // 
            this.txtVendorName.Location = new System.Drawing.Point(408, 54);
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.Size = new System.Drawing.Size(487, 23);
            this.txtVendorName.TabIndex = 3;
            this.txtVendorName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVendorName_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(324, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Vendor name";
            // 
            // txtInvoice
            // 
            this.txtInvoice.Location = new System.Drawing.Point(91, 83);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(214, 23);
            this.txtInvoice.TabIndex = 5;
            this.txtInvoice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtInvoice_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Invoice #";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(338, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Input Date";
            // 
            // dtpInput
            // 
            this.dtpInput.CustomFormat = "yyyy/MM/dd";
            this.dtpInput.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInput.Location = new System.Drawing.Point(408, 83);
            this.dtpInput.Name = "dtpInput";
            this.dtpInput.Size = new System.Drawing.Size(190, 23);
            this.dtpInput.TabIndex = 7;
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.CustomFormat = "yyyy/MM/dd";
            this.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPaymentDate.Location = new System.Drawing.Point(700, 83);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.Size = new System.Drawing.Size(195, 23);
            this.dtpPaymentDate.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(612, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Payment Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Currency";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(408, 112);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(190, 23);
            this.txtAmount.TabIndex = 13;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressed);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(311, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Invoice Amount";
            // 
            // customPanel3
            // 
            this.customPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanel3.BackColor = System.Drawing.Color.LightGray;
            this.customPanel3.BackColor2 = System.Drawing.SystemColors.Window;
            this.customPanel3.BorderColor = System.Drawing.Color.Silver;
            this.customPanel3.BorderWidth = 1;
            this.customPanel3.Controls.Add(this.dgvOutstanding);
            this.customPanel3.Curvature = 1;
            this.customPanel3.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.customPanel3.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.customPanel3.Location = new System.Drawing.Point(-2, 141);
            this.customPanel3.Name = "customPanel3";
            this.customPanel3.Size = new System.Drawing.Size(1210, 402);
            this.customPanel3.TabIndex = 61;
            // 
            // dgvOutstanding
            // 
            this.dgvOutstanding.AllowUserToDeleteRows = false;
            this.dgvOutstanding.AllowUserToResizeRows = false;
            this.dgvOutstanding.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOutstanding.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.cimg});
            this.dgvOutstanding.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvOutstanding.Location = new System.Drawing.Point(3, 2);
            this.dgvOutstanding.Name = "dgvOutstanding";
            this.dgvOutstanding.RowHeadersVisible = false;
            this.dgvOutstanding.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvOutstanding.Size = new System.Drawing.Size(1207, 400);
            this.dgvOutstanding.TabIndex = 0;
            this.dgvOutstanding.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOutstanding_CellContentClick);
            this.dgvOutstanding.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOutstanding_CellEndEdit);
            this.dgvOutstanding.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvOutstanding_CellFormatting);
            this.dgvOutstanding.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvOutstanding_DataBindingComplete);
            this.dgvOutstanding.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvOutstanding_DataError);
            this.dgvOutstanding.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvOutstanding_EditingControlShowing);
            this.dgvOutstanding.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvOutstanding_RowsAdded);
            this.dgvOutstanding.SelectionChanged += new System.EventHandler(this.dgvOutstanding_SelectionChanged);
            this.dgvOutstanding.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvOutstanding_KeyDown);
            this.dgvOutstanding.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvOutstanding_KeyUp);
            // 
            // cac
            // 
            this.cac.FillWeight = 170F;
            this.cac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cac.HeaderText = "AccountCode";
            this.cac.Name = "cac";
            this.cac.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cac.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cacname
            // 
            this.cacname.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cacname.HeaderText = "AccountName";
            this.cacname.Name = "cacname";
            this.cacname.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cacname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cacname.Visible = false;
            // 
            // ccostcentre
            // 
            this.ccostcentre.FillWeight = 90F;
            this.ccostcentre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ccostcentre.HeaderText = "CostCentre";
            this.ccostcentre.Name = "ccostcentre";
            this.ccostcentre.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ccostcentre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ccostcentrename
            // 
            this.ccostcentrename.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ccostcentrename.HeaderText = "CostCentreName";
            this.ccostcentrename.Name = "ccostcentrename";
            this.ccostcentrename.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ccostcentrename.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ccostcentrename.Visible = false;
            // 
            // camount
            // 
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.camount.DefaultCellStyle = dataGridViewCellStyle1;
            this.camount.FillWeight = 35.39824F;
            this.camount.HeaderText = "Amount";
            this.camount.Name = "camount";
            // 
            // cdesc1
            // 
            this.cdesc1.FillWeight = 35.39824F;
            this.cdesc1.HeaderText = "Remarks 1";
            this.cdesc1.MaxInputLength = 50;
            this.cdesc1.Name = "cdesc1";
            // 
            // cdesc2
            // 
            this.cdesc2.FillWeight = 35.39824F;
            this.cdesc2.HeaderText = "Remarks 2";
            this.cdesc2.MaxInputLength = 50;
            this.cdesc2.Name = "cdesc2";
            // 
            // cdesc3
            // 
            this.cdesc3.FillWeight = 35.39824F;
            this.cdesc3.HeaderText = "Remarks 3";
            this.cdesc3.MaxInputLength = 50;
            this.cdesc3.Name = "cdesc3";
            // 
            // cdesc4
            // 
            this.cdesc4.FillWeight = 35.39824F;
            this.cdesc4.HeaderText = "Remarks 4";
            this.cdesc4.MaxInputLength = 50;
            this.cdesc4.Name = "cdesc4";
            // 
            // cdesc5
            // 
            this.cdesc5.FillWeight = 35.39824F;
            this.cdesc5.HeaderText = "Remarks 5";
            this.cdesc5.MaxInputLength = 50;
            this.cdesc5.Name = "cdesc5";
            // 
            // cbCurr
            // 
            this.cbCurr.FormattingEnabled = true;
            this.cbCurr.Items.AddRange(new object[] {
            "HKD",
            "USD",
            "JPY",
            "RMB",
            "EUR"});
            this.cbCurr.Location = new System.Drawing.Point(91, 112);
            this.cbCurr.Name = "cbCurr";
            this.cbCurr.Size = new System.Drawing.Size(214, 23);
            this.cbCurr.TabIndex = 63;
            this.cbCurr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressed);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.panel2.Location = new System.Drawing.Point(505, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(192, 4);
            this.panel2.TabIndex = 67;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(501, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(203, 29);
            this.lblTitle.TabIndex = 66;
            this.lblTitle.Text = "OUTSTANDING SLIP";
            // 
            // btnUpload
            // 
            this.btnUpload.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.Location = new System.Drawing.Point(1103, 12);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(96, 23);
            this.btnUpload.TabIndex = 192;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Visible = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnTemplate
            // 
            this.btnTemplate.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemplate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTemplate.Location = new System.Drawing.Point(1004, 12);
            this.btnTemplate.Name = "btnTemplate";
            this.btnTemplate.Size = new System.Drawing.Size(93, 23);
            this.btnTemplate.TabIndex = 193;
            this.btnTemplate.Text = "Template";
            this.btnTemplate.UseVisualStyleBackColor = true;
            this.btnTemplate.Visible = false;
            this.btnTemplate.Click += new System.EventHandler(this.btnTemplate_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(1096, 549);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 31);
            this.btnSave.TabIndex = 194;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pbTick
            // 
            this.pbTick.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbTick.BackgroundImage")));
            this.pbTick.Location = new System.Drawing.Point(285, 86);
            this.pbTick.Name = "pbTick";
            this.pbTick.Size = new System.Drawing.Size(16, 16);
            this.pbTick.TabIndex = 195;
            this.pbTick.TabStop = false;
            this.pbTick.Visible = false;
            // 
            // btnSearch2
            // 
            this.btnSearch2.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch2.BackgroundImage")));
            this.btnSearch2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch2.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSearch2.FlatAppearance.BorderSize = 0;
            this.btnSearch2.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSearch2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch2.Location = new System.Drawing.Point(877, 57);
            this.btnSearch2.Name = "btnSearch2";
            this.btnSearch2.Size = new System.Drawing.Size(16, 16);
            this.btnSearch2.TabIndex = 65;
            this.btnSearch2.UseVisualStyleBackColor = false;
            this.btnSearch2.Click += new System.EventHandler(this.btnSearch2_Click);
            // 
            // btnSearch1
            // 
            this.btnSearch1.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch1.BackgroundImage")));
            this.btnSearch1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSearch1.FlatAppearance.BorderSize = 0;
            this.btnSearch1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSearch1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSearch1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch1.Location = new System.Drawing.Point(285, 58);
            this.btnSearch1.Name = "btnSearch1";
            this.btnSearch1.Size = new System.Drawing.Size(16, 16);
            this.btnSearch1.TabIndex = 64;
            this.btnSearch1.UseVisualStyleBackColor = false;
            this.btnSearch1.Click += new System.EventHandler(this.btnSearch1_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 21;
            // 
            // cimg
            // 
            this.cimg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cimg.HeaderText = "";
            this.cimg.Image = ((System.Drawing.Image)(resources.GetObject("cimg.Image")));
            this.cimg.Name = "cimg";
            this.cimg.ReadOnly = true;
            this.cimg.Width = 21;
            // 
            // OutstandingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1209, 605);
            this.Controls.Add(this.pbTick);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnTemplate);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSearch2);
            this.Controls.Add(this.btnSearch1);
            this.Controls.Add(this.cbCurr);
            this.Controls.Add(this.customPanel3);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpPaymentDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtInvoice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVendorName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVendorCode);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OutstandingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Outstanding Slip";
            this.customPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutstanding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTick)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVendorCode;
        private System.Windows.Forms.TextBox txtVendorName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInvoice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpInput;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label7;
        private CustomUtil.controls.panel.CustomPanel customPanel3;
        private System.Windows.Forms.DataGridView dgvOutstanding;
        private System.Windows.Forms.ComboBox cbCurr;
        private System.Windows.Forms.Button btnSearch1;
        private System.Windows.Forms.Button btnSearch2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnTemplate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox pbTick;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn cac;
        private System.Windows.Forms.DataGridViewComboBoxColumn cacname;
        private System.Windows.Forms.DataGridViewComboBoxColumn ccostcentre;
        private System.Windows.Forms.DataGridViewComboBoxColumn ccostcentrename;
        private System.Windows.Forms.DataGridViewTextBoxColumn camount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdesc1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdesc2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdesc3;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdesc4;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdesc5;
        private System.Windows.Forms.DataGridViewImageColumn cimg;
    }
}