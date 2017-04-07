namespace KDTHK_DM_SP.eforms.hra
{
    partial class FormR3Application
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormR3Application));
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.cbR3Type = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtR3Id = new CustomUtil.controls.textbox.WatermarkTextbox();
            this.txtRequest = new CustomUtil.controls.textbox.WatermarkTextbox();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.txtAttachment = new System.Windows.Forms.TextBox();
            this.txtHead = new System.Windows.Forms.TextBox();
            this.btnSave = new CustomUtil.controls.button.CustomButton();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.ckbCancel = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(34, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 17);
            this.label6.TabIndex = 115;
            this.label6.Text = "R/3 類別";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(32, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 114;
            this.label5.Text = "申請類別";
            // 
            // cbType
            // 
            this.cbType.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "新規",
            "修改",
            "刪除"});
            this.cbType.Location = new System.Drawing.Point(98, 35);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(93, 24);
            this.cbType.TabIndex = 116;
            this.cbType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressed);
            // 
            // cbR3Type
            // 
            this.cbR3Type.FormattingEnabled = true;
            this.cbR3Type.Items.AddRange(new object[] {
            "ID",
            "TX",
            "ROLE"});
            this.cbR3Type.Location = new System.Drawing.Point(98, 64);
            this.cbR3Type.Name = "cbR3Type";
            this.cbR3Type.Size = new System.Drawing.Size(93, 23);
            this.cbR3Type.TabIndex = 117;
            this.cbR3Type.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 118;
            this.label1.Text = "R/3 ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 119;
            this.label2.Text = "申請依賴";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 120;
            this.label3.Text = "申請理由";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 369);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 121;
            this.label4.Text = "使用開始日";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(58, 396);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 17);
            this.label7.TabIndex = 122;
            this.label7.Text = "附件";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(45, 425);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 17);
            this.label8.TabIndex = 123;
            this.label8.Text = "責任者";
            // 
            // txtR3Id
            // 
            this.txtR3Id.FocusSelect = true;
            this.txtR3Id.Location = new System.Drawing.Point(98, 93);
            this.txtR3Id.MaxLength = 2147483647;
            this.txtR3Id.Multiline = true;
            this.txtR3Id.Name = "txtR3Id";
            this.txtR3Id.PromptFont = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtR3Id.PromptForeColor = System.Drawing.SystemColors.GrayText;
            this.txtR3Id.PromptText = "可輸入多個R/3用戶ID";
            this.txtR3Id.Size = new System.Drawing.Size(655, 115);
            this.txtR3Id.TabIndex = 124;
            // 
            // txtRequest
            // 
            this.txtRequest.FocusSelect = true;
            this.txtRequest.Location = new System.Drawing.Point(98, 214);
            this.txtRequest.MaxLength = 2147483647;
            this.txtRequest.Multiline = true;
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.PromptFont = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequest.PromptForeColor = System.Drawing.SystemColors.GrayText;
            this.txtRequest.PromptText = "請輸入申請依賴內容";
            this.txtRequest.Size = new System.Drawing.Size(655, 115);
            this.txtRequest.TabIndex = 125;
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(98, 335);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(655, 23);
            this.txtReason.TabIndex = 126;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(98, 364);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(237, 23);
            this.dtpStart.TabIndex = 127;
            // 
            // txtAttachment
            // 
            this.txtAttachment.Location = new System.Drawing.Point(98, 394);
            this.txtAttachment.Name = "txtAttachment";
            this.txtAttachment.Size = new System.Drawing.Size(633, 23);
            this.txtAttachment.TabIndex = 128;
            this.txtAttachment.DoubleClick += new System.EventHandler(this.txtAttachment_DoubleClick);
            this.txtAttachment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressed);
            // 
            // txtHead
            // 
            this.txtHead.Location = new System.Drawing.Point(98, 423);
            this.txtHead.Name = "txtHead";
            this.txtHead.Size = new System.Drawing.Size(237, 23);
            this.txtHead.TabIndex = 129;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.GlowColor = System.Drawing.Color.SkyBlue;
            this.btnSave.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnSave.Location = new System.Drawing.Point(666, 456);
            this.btnSave.Name = "btnSave";
            this.btnSave.OuterBorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.ShineColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.Size = new System.Drawing.Size(87, 25);
            this.btnSave.TabIndex = 130;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUsers.BackgroundImage")));
            this.btnUsers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUsers.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUsers.Location = new System.Drawing.Point(341, 426);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(16, 16);
            this.btnUsers.TabIndex = 131;
            this.btnUsers.Tag = "open";
            this.btnUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUsers.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackgroundImage = global::KDTHK_DM_SP.Properties.Resources.folder_open;
            this.btnBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBrowse.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnBrowse.FlatAppearance.BorderSize = 0;
            this.btnBrowse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnBrowse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowse.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBrowse.Location = new System.Drawing.Point(737, 396);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(16, 16);
            this.btnBrowse.TabIndex = 132;
            this.btnBrowse.Tag = "open";
            this.btnBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // ckbCancel
            // 
            this.ckbCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbCancel.AutoSize = true;
            this.ckbCancel.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbCancel.ForeColor = System.Drawing.Color.Red;
            this.ckbCancel.Location = new System.Drawing.Point(581, 459);
            this.ckbCancel.Name = "ckbCancel";
            this.ckbCancel.Size = new System.Drawing.Size(79, 21);
            this.ckbCancel.TabIndex = 133;
            this.ckbCancel.Text = "取消申請";
            this.ckbCancel.UseVisualStyleBackColor = true;
            // 
            // FormR3Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(765, 493);
            this.Controls.Add(this.ckbCancel);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnUsers);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtHead);
            this.Controls.Add(this.txtAttachment);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.txtRequest);
            this.Controls.Add(this.txtR3Id);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbR3Type);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormR3Application";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "R3 Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.ComboBox cbR3Type;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private CustomUtil.controls.textbox.WatermarkTextbox txtR3Id;
        private CustomUtil.controls.textbox.WatermarkTextbox txtRequest;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.TextBox txtAttachment;
        private System.Windows.Forms.TextBox txtHead;
        private CustomUtil.controls.button.CustomButton btnSave;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.CheckBox ckbCancel;
    }
}