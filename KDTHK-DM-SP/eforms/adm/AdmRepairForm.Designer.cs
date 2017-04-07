namespace KDTHK_DM_SP.eforms.adm
{
    partial class AdmRepairForm
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
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFee = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDeptShared1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDeptShared2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.customPanel1 = new CustomUtil.controls.panel.CustomPanel();
            this.rtbContent = new KDTHK_DM_SP.utils.RtfPrintUtil();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDeptShared1 = new System.Windows.Forms.Button();
            this.btnDeptShared2 = new System.Windows.Forms.Button();
            this.customPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(112, 31);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(264, 23);
            this.txtUser.TabIndex = 110;
            this.txtUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressed);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(59, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 111;
            this.label5.Text = "申請者";
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(112, 60);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(264, 23);
            this.txtDepartment.TabIndex = 112;
            this.txtDepartment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 113;
            this.label1.Text = "申請部門";
            // 
            // txtFee
            // 
            this.txtFee.Location = new System.Drawing.Point(112, 89);
            this.txtFee.Name = "txtFee";
            this.txtFee.Size = new System.Drawing.Size(264, 23);
            this.txtFee.TabIndex = 114;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 115;
            this.label2.Text = "所需費用";
            // 
            // txtDeptShared1
            // 
            this.txtDeptShared1.Location = new System.Drawing.Point(112, 118);
            this.txtDeptShared1.Name = "txtDeptShared1";
            this.txtDeptShared1.Size = new System.Drawing.Size(264, 23);
            this.txtDeptShared1.TabIndex = 116;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 117;
            this.label3.Text = "費用分担部門1";
            // 
            // txtDeptShared2
            // 
            this.txtDeptShared2.Location = new System.Drawing.Point(112, 147);
            this.txtDeptShared2.Name = "txtDeptShared2";
            this.txtDeptShared2.Size = new System.Drawing.Size(264, 23);
            this.txtDeptShared2.TabIndex = 118;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 17);
            this.label4.TabIndex = 119;
            this.label4.Text = "費用分担部門2";
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
            this.customPanel1.Location = new System.Drawing.Point(112, 176);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(606, 321);
            this.customPanel1.TabIndex = 120;
            // 
            // rtbContent
            // 
            this.rtbContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbContent.Location = new System.Drawing.Point(3, 2);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.Size = new System.Drawing.Size(600, 316);
            this.rtbContent.TabIndex = 114;
            this.rtbContent.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(46, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 121;
            this.label6.Text = "詳細內容";
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(605, 503);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 26);
            this.btnSave.TabIndex = 335;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDeptShared1
            // 
            this.btnDeptShared1.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDeptShared1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeptShared1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeptShared1.Location = new System.Drawing.Point(382, 118);
            this.btnDeptShared1.Name = "btnDeptShared1";
            this.btnDeptShared1.Size = new System.Drawing.Size(27, 23);
            this.btnDeptShared1.TabIndex = 338;
            this.btnDeptShared1.Text = "...";
            this.btnDeptShared1.UseVisualStyleBackColor = true;
            this.btnDeptShared1.Click += new System.EventHandler(this.btnDeptShared1_Click);
            // 
            // btnDeptShared2
            // 
            this.btnDeptShared2.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDeptShared2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeptShared2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeptShared2.Location = new System.Drawing.Point(382, 147);
            this.btnDeptShared2.Name = "btnDeptShared2";
            this.btnDeptShared2.Size = new System.Drawing.Size(27, 23);
            this.btnDeptShared2.TabIndex = 339;
            this.btnDeptShared2.Text = "...";
            this.btnDeptShared2.UseVisualStyleBackColor = true;
            this.btnDeptShared2.Click += new System.EventHandler(this.btnDeptShared2_Click);
            // 
            // AdmRepairForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(722, 538);
            this.Controls.Add(this.btnDeptShared2);
            this.Controls.Add(this.btnDeptShared1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.customPanel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDeptShared2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDeptShared1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFee);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdmRepairForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "業務/修理依賴";
            this.customPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDeptShared1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDeptShared2;
        private System.Windows.Forms.Label label4;
        private CustomUtil.controls.panel.CustomPanel customPanel1;
        private KDTHK_DM_SP.utils.RtfPrintUtil rtbContent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDeptShared1;
        private System.Windows.Forms.Button btnDeptShared2;
    }
}