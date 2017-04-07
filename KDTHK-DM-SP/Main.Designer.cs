namespace KDTHK_DM_SP
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbtnIdle = new System.Windows.Forms.ToolStripButton();
            this.tsbtnNotice = new System.Windows.Forms.ToolStripButton();
            this.tsbtnReceived = new System.Windows.Forms.ToolStripButton();
            this.tsbtnUserManual = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnMySky = new System.Windows.Forms.ToolStripButton();
            this.tsbtnApproval = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMain = new System.Windows.Forms.Label();
            this.ssBottom = new System.Windows.Forms.StatusStrip();
            this.tslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlMain = new CustomUtil.controls.panel.CustomPanel();
            this.pnlLeft = new CustomUtil.controls.panel.CustomPanel();
            this.btnExtend = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.ssBottom.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.AliceBlue;
            this.toolStrip1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnRefresh,
            this.tsbtnIdle,
            this.tsbtnNotice,
            this.tsbtnReceived,
            this.tsbtnUserManual,
            this.toolStripSeparator1,
            this.tsbtnMySky,
            this.tsbtnApproval,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1266, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnRefresh
            // 
            this.tsbtnRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRefresh.Image")));
            this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefresh.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tsbtnRefresh.Name = "tsbtnRefresh";
            this.tsbtnRefresh.Size = new System.Drawing.Size(23, 22);
            this.tsbtnRefresh.Visible = false;
            this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
            // 
            // tsbtnIdle
            // 
            this.tsbtnIdle.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnIdle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnIdle.ForeColor = System.Drawing.Color.Black;
            this.tsbtnIdle.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnIdle.Image")));
            this.tsbtnIdle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnIdle.Name = "tsbtnIdle";
            this.tsbtnIdle.Size = new System.Drawing.Size(50, 22);
            this.tsbtnIdle.Text = "Idle (0)";
            // 
            // tsbtnNotice
            // 
            this.tsbtnNotice.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnNotice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnNotice.ForeColor = System.Drawing.Color.Black;
            this.tsbtnNotice.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnNotice.Image")));
            this.tsbtnNotice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNotice.Name = "tsbtnNotice";
            this.tsbtnNotice.Size = new System.Drawing.Size(45, 22);
            this.tsbtnNotice.Text = "Notice";
            this.tsbtnNotice.Click += new System.EventHandler(this.tsbtnNotice_Click);
            // 
            // tsbtnReceived
            // 
            this.tsbtnReceived.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnReceived.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnReceived.ForeColor = System.Drawing.Color.Black;
            this.tsbtnReceived.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnReceived.Image")));
            this.tsbtnReceived.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnReceived.Name = "tsbtnReceived";
            this.tsbtnReceived.Size = new System.Drawing.Size(59, 22);
            this.tsbtnReceived.Text = "Received";
            this.tsbtnReceived.Click += new System.EventHandler(this.tsbtnReceived_Click);
            // 
            // tsbtnUserManual
            // 
            this.tsbtnUserManual.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnUserManual.ForeColor = System.Drawing.Color.DimGray;
            this.tsbtnUserManual.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnUserManual.Image")));
            this.tsbtnUserManual.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnUserManual.Name = "tsbtnUserManual";
            this.tsbtnUserManual.Size = new System.Drawing.Size(82, 22);
            this.tsbtnUserManual.Text = "User Manual";
            this.tsbtnUserManual.Click += new System.EventHandler(this.tsbtnUserManual_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnMySky
            // 
            this.tsbtnMySky.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnMySky.ForeColor = System.Drawing.Color.DimGray;
            this.tsbtnMySky.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnMySky.Image")));
            this.tsbtnMySky.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnMySky.Name = "tsbtnMySky";
            this.tsbtnMySky.Size = new System.Drawing.Size(46, 22);
            this.tsbtnMySky.Text = "MySky";
            this.tsbtnMySky.Click += new System.EventHandler(this.tsbtnMySky_Click);
            // 
            // tsbtnApproval
            // 
            this.tsbtnApproval.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnApproval.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnApproval.ForeColor = System.Drawing.Color.Black;
            this.tsbtnApproval.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnApproval.Image")));
            this.tsbtnApproval.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnApproval.Name = "tsbtnApproval";
            this.tsbtnApproval.Size = new System.Drawing.Size(61, 22);
            this.tsbtnApproval.Text = "Approval";
            this.tsbtnApproval.Click += new System.EventHandler(this.tsbtnApproval_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Visible = false;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(5, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 35);
            this.label6.TabIndex = 24;
            this.label6.Tag = "form";
            this.label6.Text = "            E-Form";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.label6, "E-Form");
            this.label6.Click += new System.EventHandler(this.LabelClicked);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(5, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 35);
            this.label4.TabIndex = 22;
            this.label4.Tag = "setting";
            this.label4.Text = "            Setting";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.label4, "Setting");
            this.label4.Click += new System.EventHandler(this.LabelClicked);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(5, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 35);
            this.label3.TabIndex = 21;
            this.label3.Tag = "application";
            this.label3.Text = "            Application";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.label3, "Application");
            this.label3.Click += new System.EventHandler(this.LabelClicked);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(5, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 35);
            this.label2.TabIndex = 20;
            this.label2.Tag = "schedule";
            this.label2.Text = "            Schedule";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.label2, "Schedule");
            this.label2.Click += new System.EventHandler(this.LabelClicked);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(5, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 35);
            this.label1.TabIndex = 19;
            this.label1.Tag = "disc";
            this.label1.Text = "            Disc";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.label1, "Disc");
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.LabelClicked);
            // 
            // lblMain
            // 
            this.lblMain.BackColor = System.Drawing.Color.AliceBlue;
            this.lblMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMain.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMain.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblMain.Image = ((System.Drawing.Image)(resources.GetObject("lblMain.Image")));
            this.lblMain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMain.Location = new System.Drawing.Point(5, 3);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(186, 35);
            this.lblMain.TabIndex = 18;
            this.lblMain.Tag = "document";
            this.lblMain.Text = "            Documents";
            this.lblMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.lblMain, "Documents");
            this.lblMain.Click += new System.EventHandler(this.LabelClicked);
            // 
            // ssBottom
            // 
            this.ssBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblStatus});
            this.ssBottom.Location = new System.Drawing.Point(0, 656);
            this.ssBottom.Name = "ssBottom";
            this.ssBottom.Size = new System.Drawing.Size(1266, 22);
            this.ssBottom.TabIndex = 3;
            this.ssBottom.Text = "statusStrip1";
            // 
            // tslblStatus
            // 
            this.tslblStatus.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tslblStatus.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tslblStatus.Name = "tslblStatus";
            this.tslblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.Window;
            this.pnlMain.BackColor2 = System.Drawing.SystemColors.Window;
            this.pnlMain.BorderColor = System.Drawing.Color.Silver;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.BorderWidth = 1;
            this.pnlMain.Curvature = 1;
            this.pnlMain.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.pnlMain.Location = new System.Drawing.Point(200, 25);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1066, 631);
            this.pnlMain.TabIndex = 5;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.SystemColors.Window;
            this.pnlLeft.BackColor2 = System.Drawing.SystemColors.Window;
            this.pnlLeft.BorderColor = System.Drawing.Color.Silver;
            this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeft.BorderWidth = 1;
            this.pnlLeft.Controls.Add(this.btnExtend);
            this.pnlLeft.Controls.Add(this.pnlMenu);
            this.pnlLeft.Curvature = 1;
            this.pnlLeft.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.pnlLeft.Location = new System.Drawing.Point(0, 25);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(200, 631);
            this.pnlLeft.TabIndex = 4;
            // 
            // btnExtend
            // 
            this.btnExtend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExtend.BackgroundImage = global::KDTHK_DM_SP.Properties.Resources.left_button_basic_blue;
            this.btnExtend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExtend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExtend.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExtend.FlatAppearance.BorderSize = 0;
            this.btnExtend.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExtend.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExtend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExtend.Location = new System.Drawing.Point(169, 6);
            this.btnExtend.Name = "btnExtend";
            this.btnExtend.Size = new System.Drawing.Size(24, 24);
            this.btnExtend.TabIndex = 14;
            this.btnExtend.UseVisualStyleBackColor = true;
            this.btnExtend.Click += new System.EventHandler(this.btnExtend_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMenu.Controls.Add(this.label6);
            this.pnlMenu.Controls.Add(this.label4);
            this.pnlMenu.Controls.Add(this.label3);
            this.pnlMenu.Controls.Add(this.label2);
            this.pnlMenu.Controls.Add(this.label1);
            this.pnlMenu.Controls.Add(this.lblMain);
            this.pnlMenu.Location = new System.Drawing.Point(3, 32);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(194, 406);
            this.pnlMenu.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1266, 678);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.ssBottom);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyCloud";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ssBottom.ResumeLayout(false);
            this.ssBottom.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripButton tsbtnReceived;
        private System.Windows.Forms.ToolStripButton tsbtnIdle;
        private System.Windows.Forms.ToolStripButton tsbtnNotice;
        private System.Windows.Forms.ToolStripButton tsbtnUserManual;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnMySky;
        private System.Windows.Forms.StatusStrip ssBottom;
        private CustomUtil.controls.panel.CustomPanel pnlLeft;
        private System.Windows.Forms.Button btnExtend;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMain;
        private CustomUtil.controls.panel.CustomPanel pnlMain;
        private System.Windows.Forms.ToolStripStatusLabel tslblStatus;
        private System.Windows.Forms.ToolStripButton tsbtnApproval;
        private System.Windows.Forms.ToolStripButton tsbtnRefresh;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

