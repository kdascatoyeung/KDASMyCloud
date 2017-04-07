namespace KDTHK_DM_SP.eforms.hra
{
    partial class FormPermission
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.customPanel1 = new CustomUtil.controls.panel.CustomPanel();
            this.rtbContent = new System.Windows.Forms.RichTextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlCategory = new System.Windows.Forms.Panel();
            this.ckbComment = new System.Windows.Forms.CheckBox();
            this.ckbSupport = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.customPanel2 = new CustomUtil.controls.panel.CustomPanel();
            this.dgvPermission = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.ctotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cstock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cborrow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOK = new CustomUtil.controls.button.CustomButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHead = new System.Windows.Forms.TextBox();
            this.lblHead = new System.Windows.Forms.Label();
            this.customPanel3 = new CustomUtil.controls.panel.CustomPanel();
            this.rtbDetail = new System.Windows.Forms.RichTextBox();
            this.customPanel1.SuspendLayout();
            this.pnlCategory.SuspendLayout();
            this.customPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermission)).BeginInit();
            this.customPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Location = new System.Drawing.Point(2, 388);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 5);
            this.panel1.TabIndex = 164;
            // 
            // txtEnd
            // 
            this.txtEnd.Location = new System.Drawing.Point(489, 327);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(289, 23);
            this.txtEnd.TabIndex = 163;
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(110, 327);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(264, 23);
            this.txtStart.TabIndex = 162;
            // 
            // customPanel1
            // 
            this.customPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.customPanel1.BackColor2 = System.Drawing.SystemColors.Window;
            this.customPanel1.BorderColor = System.Drawing.Color.LightGray;
            this.customPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel1.BorderWidth = 1;
            this.customPanel1.Controls.Add(this.rtbContent);
            this.customPanel1.Curvature = 2;
            this.customPanel1.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.customPanel1.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.customPanel1.Location = new System.Drawing.Point(110, 41);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(668, 246);
            this.customPanel1.TabIndex = 161;
            // 
            // rtbContent
            // 
            this.rtbContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbContent.Location = new System.Drawing.Point(3, 3);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.Size = new System.Drawing.Size(662, 240);
            this.rtbContent.TabIndex = 111;
            this.rtbContent.Text = "";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(110, 12);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(264, 23);
            this.txtUser.TabIndex = 160;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(57, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 159;
            this.label5.Text = "申請者";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(436, 331);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 158;
            this.label4.Text = "完成日";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 332);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 157;
            this.label3.Text = "開始日";
            // 
            // pnlCategory
            // 
            this.pnlCategory.Controls.Add(this.ckbComment);
            this.pnlCategory.Controls.Add(this.ckbSupport);
            this.pnlCategory.Enabled = false;
            this.pnlCategory.Location = new System.Drawing.Point(110, 293);
            this.pnlCategory.Name = "pnlCategory";
            this.pnlCategory.Size = new System.Drawing.Size(182, 28);
            this.pnlCategory.TabIndex = 156;
            // 
            // ckbComment
            // 
            this.ckbComment.AutoSize = true;
            this.ckbComment.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbComment.Location = new System.Drawing.Point(88, 5);
            this.ckbComment.Name = "ckbComment";
            this.ckbComment.Size = new System.Drawing.Size(66, 21);
            this.ckbComment.TabIndex = 6;
            this.ckbComment.Text = "意見箱";
            this.ckbComment.UseVisualStyleBackColor = true;
            // 
            // ckbSupport
            // 
            this.ckbSupport.AutoSize = true;
            this.ckbSupport.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbSupport.Location = new System.Drawing.Point(3, 5);
            this.ckbSupport.Name = "ckbSupport";
            this.ckbSupport.Size = new System.Drawing.Size(79, 21);
            this.ckbSupport.TabIndex = 5;
            this.ckbSupport.Text = "技術支援";
            this.ckbSupport.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 155;
            this.label2.Text = "類別";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 154;
            this.label1.Text = "申請內容";
            // 
            // customPanel2
            // 
            this.customPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanel2.BackColor = System.Drawing.SystemColors.Window;
            this.customPanel2.BackColor2 = System.Drawing.SystemColors.Window;
            this.customPanel2.BorderColor = System.Drawing.Color.Silver;
            this.customPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel2.BorderWidth = 1;
            this.customPanel2.Controls.Add(this.dgvPermission);
            this.customPanel2.Curvature = 3;
            this.customPanel2.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.customPanel2.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.customPanel2.Location = new System.Drawing.Point(110, 399);
            this.customPanel2.Name = "customPanel2";
            this.customPanel2.Size = new System.Drawing.Size(668, 50);
            this.customPanel2.TabIndex = 165;
            // 
            // dgvPermission
            // 
            this.dgvPermission.AllowUserToDeleteRows = false;
            this.dgvPermission.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.dgvPermission.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPermission.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPermission.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPermission.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPermission.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPermission.ColumnHeaderColor1 = System.Drawing.Color.White;
            this.dgvPermission.ColumnHeaderColor2 = System.Drawing.Color.WhiteSmoke;
            this.dgvPermission.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPermission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermission.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ctotal,
            this.cuser,
            this.cstock,
            this.cborrow});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPermission.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPermission.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvPermission.Location = new System.Drawing.Point(3, 3);
            this.dgvPermission.MultiSelect = false;
            this.dgvPermission.Name = "dgvPermission";
            this.dgvPermission.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvPermission.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvPermission.RowHeadersVisible = false;
            this.dgvPermission.SecondaryLength = 2;
            this.dgvPermission.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvPermission.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvPermission.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvPermission.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvPermission.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPermission.Size = new System.Drawing.Size(662, 44);
            this.dgvPermission.TabIndex = 7;
            this.dgvPermission.Tag = "category";
            // 
            // ctotal
            // 
            this.ctotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ctotal.FillWeight = 60F;
            this.ctotal.HeaderText = "Item Name";
            this.ctotal.Name = "ctotal";
            this.ctotal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ctotal.Width = 90;
            // 
            // cuser
            // 
            this.cuser.FillWeight = 40F;
            this.cuser.HeaderText = "User ID";
            this.cuser.Name = "cuser";
            // 
            // cstock
            // 
            this.cstock.FillWeight = 45F;
            this.cstock.HeaderText = "Start";
            this.cstock.Name = "cstock";
            // 
            // cborrow
            // 
            this.cborrow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cborrow.FillWeight = 40F;
            this.cborrow.HeaderText = "Status";
            this.cborrow.Name = "cborrow";
            this.cborrow.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cborrow.Width = 66;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(70, 399);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 17);
            this.label6.TabIndex = 166;
            this.label6.Text = "項目";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.Gainsboro;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.Black;
            this.btnOK.GlowColor = System.Drawing.Color.SkyBlue;
            this.btnOK.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnOK.Location = new System.Drawing.Point(691, 626);
            this.btnOK.Name = "btnOK";
            this.btnOK.OuterBorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnOK.ShineColor = System.Drawing.Color.WhiteSmoke;
            this.btnOK.Size = new System.Drawing.Size(87, 25);
            this.btnOK.TabIndex = 169;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(70, 457);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 17);
            this.label7.TabIndex = 167;
            this.label7.Text = "詳情";
            // 
            // txtHead
            // 
            this.txtHead.Location = new System.Drawing.Point(110, 356);
            this.txtHead.Name = "txtHead";
            this.txtHead.Size = new System.Drawing.Size(264, 23);
            this.txtHead.TabIndex = 171;
            // 
            // lblHead
            // 
            this.lblHead.AutoSize = true;
            this.lblHead.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHead.Location = new System.Drawing.Point(57, 360);
            this.lblHead.Name = "lblHead";
            this.lblHead.Size = new System.Drawing.Size(47, 17);
            this.lblHead.TabIndex = 170;
            this.lblHead.Text = "承認者";
            // 
            // customPanel3
            // 
            this.customPanel3.BackColor = System.Drawing.SystemColors.Window;
            this.customPanel3.BackColor2 = System.Drawing.SystemColors.Window;
            this.customPanel3.BorderColor = System.Drawing.Color.LightGray;
            this.customPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel3.BorderWidth = 1;
            this.customPanel3.Controls.Add(this.rtbDetail);
            this.customPanel3.Curvature = 2;
            this.customPanel3.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.customPanel3.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.customPanel3.Location = new System.Drawing.Point(110, 455);
            this.customPanel3.Name = "customPanel3";
            this.customPanel3.Size = new System.Drawing.Size(668, 165);
            this.customPanel3.TabIndex = 172;
            // 
            // rtbDetail
            // 
            this.rtbDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDetail.Location = new System.Drawing.Point(3, 3);
            this.rtbDetail.Name = "rtbDetail";
            this.rtbDetail.Size = new System.Drawing.Size(662, 159);
            this.rtbDetail.TabIndex = 111;
            this.rtbDetail.Text = "";
            // 
            // FormPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(796, 659);
            this.Controls.Add(this.customPanel3);
            this.Controls.Add(this.txtHead);
            this.Controls.Add(this.lblHead);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.customPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtEnd);
            this.Controls.Add(this.txtStart);
            this.Controls.Add(this.customPanel1);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pnlCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPermission";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "紀錄 - 權限關連及軟件安裝";
            this.customPanel1.ResumeLayout(false);
            this.pnlCategory.ResumeLayout(false);
            this.pnlCategory.PerformLayout();
            this.customPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermission)).EndInit();
            this.customPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.TextBox txtStart;
        private CustomUtil.controls.panel.CustomPanel customPanel1;
        private System.Windows.Forms.RichTextBox rtbContent;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlCategory;
        private System.Windows.Forms.CheckBox ckbComment;
        private System.Windows.Forms.CheckBox ckbSupport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private CustomUtil.controls.panel.CustomPanel customPanel2;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvPermission;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuser;
        private System.Windows.Forms.DataGridViewTextBoxColumn cstock;
        private System.Windows.Forms.DataGridViewTextBoxColumn cborrow;
        private System.Windows.Forms.Label label6;
        private CustomUtil.controls.button.CustomButton btnOK;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHead;
        private System.Windows.Forms.Label lblHead;
        private CustomUtil.controls.panel.CustomPanel customPanel3;
        private System.Windows.Forms.RichTextBox rtbDetail;
    }
}