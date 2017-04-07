namespace KDTHK_DM_SP.forms
{
    partial class RelocationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelocationForm));
            this.imglist = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnNewFolder = new System.Windows.Forms.ToolStripButton();
            this.tvFolder = new System.Windows.Forms.TreeView();
            this.customPanel15 = new CustomUtil.controls.panel.CustomPanel();
            this.btnCancel = new CustomUtil.controls.button.CustomButton();
            this.btnSave = new CustomUtil.controls.button.CustomButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.customPanel15.SuspendLayout();
            this.SuspendLayout();
            // 
            // imglist
            // 
            this.imglist.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglist.ImageStream")));
            this.imglist.TransparentColor = System.Drawing.SystemColors.ControlLightLight;
            this.imglist.Images.SetKeyName(0, "folder-open.png");
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnNewFolder,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(338, 25);
            this.toolStrip1.TabIndex = 61;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnNewFolder
            // 
            this.tsbtnNewFolder.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnNewFolder.Image")));
            this.tsbtnNewFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNewFolder.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tsbtnNewFolder.Name = "tsbtnNewFolder";
            this.tsbtnNewFolder.Size = new System.Drawing.Size(85, 22);
            this.tsbtnNewFolder.Text = "New folder";
            this.tsbtnNewFolder.Click += new System.EventHandler(this.tsbtnNewFolder_Click);
            // 
            // tvFolder
            // 
            this.tvFolder.AllowDrop = true;
            this.tvFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvFolder.ImageIndex = 0;
            this.tvFolder.ImageList = this.imglist;
            this.tvFolder.Location = new System.Drawing.Point(3, 3);
            this.tvFolder.Name = "tvFolder";
            this.tvFolder.SelectedImageIndex = 0;
            this.tvFolder.Size = new System.Drawing.Size(328, 404);
            this.tvFolder.TabIndex = 62;
            this.tvFolder.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvFolder_NodeMouseClick);
            // 
            // customPanel15
            // 
            this.customPanel15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanel15.BackColor = System.Drawing.SystemColors.Window;
            this.customPanel15.BackColor2 = System.Drawing.SystemColors.Window;
            this.customPanel15.BorderColor = System.Drawing.Color.DarkGray;
            this.customPanel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel15.BorderWidth = 1;
            this.customPanel15.Controls.Add(this.tvFolder);
            this.customPanel15.Curvature = 2;
            this.customPanel15.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.customPanel15.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.customPanel15.Location = new System.Drawing.Point(2, 25);
            this.customPanel15.Name = "customPanel15";
            this.customPanel15.Size = new System.Drawing.Size(334, 410);
            this.customPanel15.TabIndex = 64;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.GlowColor = System.Drawing.Color.SkyBlue;
            this.btnCancel.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnCancel.Location = new System.Drawing.Point(252, 442);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OuterBorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.ShineColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.Size = new System.Drawing.Size(84, 23);
            this.btnCancel.TabIndex = 65;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.GlowColor = System.Drawing.Color.SkyBlue;
            this.btnSave.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnSave.Location = new System.Drawing.Point(162, 442);
            this.btnSave.Name = "btnSave";
            this.btnSave.OuterBorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.ShineColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.Size = new System.Drawing.Size(84, 23);
            this.btnSave.TabIndex = 66;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // RelocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(338, 468);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.customPanel15);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RelocationForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Move To";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.customPanel15.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imglist;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnNewFolder;
        private System.Windows.Forms.TreeView tvFolder;
        private CustomUtil.controls.panel.CustomPanel customPanel15;
        private CustomUtil.controls.button.CustomButton btnCancel;
        private CustomUtil.controls.button.CustomButton btnSave;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}