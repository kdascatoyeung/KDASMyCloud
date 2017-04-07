namespace KDTHK_DM_SP.views
{
    partial class EformView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EformView));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tsbtnHra = new System.Windows.Forms.ToolStripButton();
            this.tsbtnIpo = new System.Windows.Forms.ToolStripButton();
            this.tsbtnLog = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRps = new System.Windows.Forms.ToolStripButton();
            this.tsbtnCm = new System.Windows.Forms.ToolStripButton();
            this.tsbtnMcc = new System.Windows.Forms.ToolStripButton();
            this.pnlMain = new CustomUtil.controls.panel.CustomPanel();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.tsbtnHra,
            this.tsbtnIpo,
            this.tsbtnLog,
            this.tsbtnRps,
            this.tsbtnCm,
            this.tsbtnMcc});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(1206, 25);
            this.toolStrip.TabIndex = 67;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(35, 22);
            this.toolStripButton1.Tag = "general";
            this.toolStripButton1.Text = "共通";
            this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButtonClicked);
            // 
            // tsbtnHra
            // 
            this.tsbtnHra.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnHra.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnHra.Image")));
            this.tsbtnHra.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnHra.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tsbtnHra.Name = "tsbtnHra";
            this.tsbtnHra.Size = new System.Drawing.Size(107, 22);
            this.tsbtnHra.Tag = "hra";
            this.tsbtnHra.Text = "行政及人力資源部";
            this.tsbtnHra.Click += new System.EventHandler(this.ToolStripButtonClicked);
            // 
            // tsbtnIpo
            // 
            this.tsbtnIpo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnIpo.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tsbtnIpo.Name = "tsbtnIpo";
            this.tsbtnIpo.Size = new System.Drawing.Size(69, 22);
            this.tsbtnIpo.Tag = "ipo";
            this.tsbtnIpo.Text = "IPO 採購部";
            this.tsbtnIpo.Click += new System.EventHandler(this.ToolStripButtonClicked);
            // 
            // tsbtnLog
            // 
            this.tsbtnLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLog.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tsbtnLog.Name = "tsbtnLog";
            this.tsbtnLog.Size = new System.Drawing.Size(47, 22);
            this.tsbtnLog.Tag = "log";
            this.tsbtnLog.Text = "物流部";
            this.tsbtnLog.Click += new System.EventHandler(this.ToolStripButtonClicked);
            // 
            // tsbtnRps
            // 
            this.tsbtnRps.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRps.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tsbtnRps.Name = "tsbtnRps";
            this.tsbtnRps.Size = new System.Drawing.Size(70, 22);
            this.tsbtnRps.Tag = "rps";
            this.tsbtnRps.Text = "RPS 管理部";
            this.tsbtnRps.Click += new System.EventHandler(this.ToolStripButtonClicked);
            // 
            // tsbtnCm
            // 
            this.tsbtnCm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCm.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tsbtnCm.Name = "tsbtnCm";
            this.tsbtnCm.Size = new System.Drawing.Size(71, 22);
            this.tsbtnCm.Tag = "cm";
            this.tsbtnCm.Text = "經營管理部";
            this.tsbtnCm.Click += new System.EventHandler(this.ToolStripButtonClicked);
            // 
            // tsbtnMcc
            // 
            this.tsbtnMcc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnMcc.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tsbtnMcc.Name = "tsbtnMcc";
            this.tsbtnMcc.Size = new System.Drawing.Size(95, 22);
            this.tsbtnMcc.Tag = "mcc";
            this.tsbtnMcc.Text = "MASTER 管理科";
            this.tsbtnMcc.Click += new System.EventHandler(this.ToolStripButtonClicked);
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
            this.pnlMain.Size = new System.Drawing.Size(1206, 601);
            this.pnlMain.TabIndex = 68;
            // 
            // EformView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "EformView";
            this.Size = new System.Drawing.Size(1206, 629);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsbtnIpo;
        private System.Windows.Forms.ToolStripButton tsbtnLog;
        private System.Windows.Forms.ToolStripButton tsbtnRps;
        private System.Windows.Forms.ToolStripButton tsbtnCm;
        private System.Windows.Forms.ToolStripButton tsbtnMcc;
        private CustomUtil.controls.panel.CustomPanel pnlMain;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton tsbtnHra;
    }
}
