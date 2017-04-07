namespace KDTHK_DM_SP.views
{
    partial class SettingView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.pnlMain = new CustomUtil.controls.panel.CustomPanel();
            this.tsbtnGroup = new System.Windows.Forms.ToolStripButton();
            this.tsbtnPassword = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnGroup,
            this.tsbtnPassword});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1196, 25);
            this.toolStrip1.TabIndex = 62;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.BackColor = System.Drawing.SystemColors.Window;
            this.pnlMain.BackColor2 = System.Drawing.SystemColors.Window;
            this.pnlMain.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.BorderWidth = 1;
            this.pnlMain.Curvature = 2;
            this.pnlMain.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.pnlMain.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.pnlMain.Location = new System.Drawing.Point(0, 26);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1196, 611);
            this.pnlMain.TabIndex = 65;
            // 
            // tsbtnGroup
            // 
            this.tsbtnGroup.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnGroup.Image")));
            this.tsbtnGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGroup.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tsbtnGroup.Name = "tsbtnGroup";
            this.tsbtnGroup.Size = new System.Drawing.Size(60, 22);
            this.tsbtnGroup.Text = "Group";
            this.tsbtnGroup.Click += new System.EventHandler(this.tsbtnGroup_Click);
            // 
            // tsbtnPassword
            // 
            this.tsbtnPassword.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnPassword.Image")));
            this.tsbtnPassword.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPassword.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tsbtnPassword.Name = "tsbtnPassword";
            this.tsbtnPassword.Size = new System.Drawing.Size(77, 22);
            this.tsbtnPassword.Text = "Password";
            this.tsbtnPassword.Click += new System.EventHandler(this.tsbtnPassword_Click);
            // 
            // SettingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SettingView";
            this.Size = new System.Drawing.Size(1196, 637);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnGroup;
        private CustomUtil.controls.panel.CustomPanel pnlMain;
        private System.Windows.Forms.ToolStripButton tsbtnPassword;
    }
}
