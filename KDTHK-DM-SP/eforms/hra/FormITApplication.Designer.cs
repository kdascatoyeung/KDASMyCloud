namespace KDTHK_DM_SP.eforms.hra
{
    partial class FormITApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormITApplication));
            this.btnSave = new CustomUtil.controls.button.CustomButton();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlCategory = new System.Windows.Forms.Panel();
            this.ckbComment = new System.Windows.Forms.CheckBox();
            this.ckbSupport = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHead = new System.Windows.Forms.Label();
            this.txtHead = new System.Windows.Forms.TextBox();
            this.btnUsers = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnApplicant = new System.Windows.Forms.Button();
            this.ckbCancel = new System.Windows.Forms.CheckBox();
            this.customPanel1 = new CustomUtil.controls.panel.CustomPanel();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rtbContent = new KDTHK_DM_SP.utils.RtfPrintUtil();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pnlCategory.SuspendLayout();
            this.customPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.GlowColor = System.Drawing.Color.SkyBlue;
            this.btnSave.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnSave.Location = new System.Drawing.Point(666, 438);
            this.btnSave.Name = "btnSave";
            this.btnSave.OuterBorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.ShineColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.Size = new System.Drawing.Size(87, 25);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(464, 378);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(289, 23);
            this.dtpEnd.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(411, 383);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 100;
            this.label4.Text = "完成日";
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(85, 379);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(289, 23);
            this.dtpStart.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 384);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 98;
            this.label3.Text = "開始日";
            // 
            // pnlCategory
            // 
            this.pnlCategory.Controls.Add(this.ckbComment);
            this.pnlCategory.Controls.Add(this.ckbSupport);
            this.pnlCategory.Location = new System.Drawing.Point(85, 345);
            this.pnlCategory.Name = "pnlCategory";
            this.pnlCategory.Size = new System.Drawing.Size(182, 28);
            this.pnlCategory.TabIndex = 3;
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
            this.ckbComment.CheckedChanged += new System.EventHandler(this.ckbComment_CheckedChanged);
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
            this.ckbSupport.CheckedChanged += new System.EventHandler(this.ckbSupport_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 351);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 96;
            this.label2.Text = "類別";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 94;
            this.label1.Text = "詳細內容";
            // 
            // lblHead
            // 
            this.lblHead.AutoSize = true;
            this.lblHead.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHead.Location = new System.Drawing.Point(32, 412);
            this.lblHead.Name = "lblHead";
            this.lblHead.Size = new System.Drawing.Size(47, 17);
            this.lblHead.TabIndex = 103;
            this.lblHead.Text = "承認者";
            // 
            // txtHead
            // 
            this.txtHead.Location = new System.Drawing.Point(85, 408);
            this.txtHead.Name = "txtHead";
            this.txtHead.Size = new System.Drawing.Size(264, 23);
            this.txtHead.TabIndex = 6;
            this.txtHead.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHead_KeyPress);
            this.txtHead.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtHead_MouseDoubleClick);
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
            this.btnUsers.Location = new System.Drawing.Point(355, 412);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(16, 16);
            this.btnUsers.TabIndex = 105;
            this.btnUsers.Tag = "open";
            this.btnUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(85, 35);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(264, 23);
            this.txtUser.TabIndex = 0;
            this.txtUser.DoubleClick += new System.EventHandler(this.txtUser_DoubleClick);
            this.txtUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHead_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(32, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 107;
            this.label5.Text = "申請者";
            // 
            // btnApplicant
            // 
            this.btnApplicant.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnApplicant.BackgroundImage")));
            this.btnApplicant.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnApplicant.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnApplicant.FlatAppearance.BorderSize = 0;
            this.btnApplicant.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnApplicant.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnApplicant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplicant.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApplicant.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnApplicant.Location = new System.Drawing.Point(355, 38);
            this.btnApplicant.Name = "btnApplicant";
            this.btnApplicant.Size = new System.Drawing.Size(16, 16);
            this.btnApplicant.TabIndex = 109;
            this.btnApplicant.Tag = "open";
            this.btnApplicant.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnApplicant.UseVisualStyleBackColor = true;
            this.btnApplicant.Click += new System.EventHandler(this.btnApplicant_Click);
            // 
            // ckbCancel
            // 
            this.ckbCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbCancel.AutoSize = true;
            this.ckbCancel.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbCancel.ForeColor = System.Drawing.Color.Red;
            this.ckbCancel.Location = new System.Drawing.Point(581, 442);
            this.ckbCancel.Name = "ckbCancel";
            this.ckbCancel.Size = new System.Drawing.Size(79, 21);
            this.ckbCancel.TabIndex = 110;
            this.ckbCancel.Text = "取消申請";
            this.ckbCancel.UseVisualStyleBackColor = true;
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
            this.customPanel1.Location = new System.Drawing.Point(85, 93);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(668, 246);
            this.customPanel1.TabIndex = 2;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(85, 64);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(668, 23);
            this.txtTitle.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(45, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 17);
            this.label6.TabIndex = 113;
            this.label6.Text = "主題";
            // 
            // rtbContent
            // 
            this.rtbContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbContent.Location = new System.Drawing.Point(3, 2);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.Size = new System.Drawing.Size(662, 241);
            this.rtbContent.TabIndex = 114;
            this.rtbContent.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(692, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(58, 33);
            this.richTextBox1.TabIndex = 114;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // FormITApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(765, 475);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.customPanel1);
            this.Controls.Add(this.ckbCancel);
            this.Controls.Add(this.btnApplicant);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnUsers);
            this.Controls.Add(this.txtHead);
            this.Controls.Add(this.lblHead);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pnlCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormITApplication";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IT Application";
            this.pnlCategory.ResumeLayout(false);
            this.pnlCategory.PerformLayout();
            this.customPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomUtil.controls.button.CustomButton btnSave;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblHead;
        private System.Windows.Forms.TextBox txtHead;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnApplicant;
        private System.Windows.Forms.CheckBox ckbCancel;
        private CustomUtil.controls.panel.CustomPanel customPanel1;
        private System.Windows.Forms.CheckBox ckbComment;
        private System.Windows.Forms.CheckBox ckbSupport;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label6;
        private KDTHK_DM_SP.utils.RtfPrintUtil rtbContent;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}