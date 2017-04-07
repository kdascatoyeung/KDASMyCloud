namespace KDTHK_DM_SP.eforms.adm.subforms
{
    partial class DeptSelectionForm
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
            this.lbDept = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbDept
            // 
            this.lbDept.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbDept.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDept.FormattingEnabled = true;
            this.lbDept.ItemHeight = 17;
            this.lbDept.Items.AddRange(new object[] {
            "IPO 採購部",
            "RPS 管理部",
            "物流部",
            "經營管理部",
            "MASTER 管理科"});
            this.lbDept.Location = new System.Drawing.Point(1, 3);
            this.lbDept.Name = "lbDept";
            this.lbDept.Size = new System.Drawing.Size(262, 170);
            this.lbDept.TabIndex = 0;
            this.lbDept.DoubleClick += new System.EventHandler(this.lbDept_DoubleClick);
            // 
            // DeptSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(265, 174);
            this.Controls.Add(this.lbDept);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeptSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeptSelectionForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbDept;
    }
}