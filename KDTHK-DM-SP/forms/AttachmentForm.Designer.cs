namespace KDTHK_DM_SP.forms
{
    partial class AttachmentForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.customPanel3 = new CustomUtil.controls.panel.CustomPanel();
            this.ckbAll = new System.Windows.Forms.CheckBox();
            this.dgvAttachment = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.cSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colExName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSend = new CustomUtil.controls.button.CustomButton();
            this.customPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachment)).BeginInit();
            this.SuspendLayout();
            // 
            // customPanel3
            // 
            this.customPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanel3.BackColor = System.Drawing.SystemColors.Window;
            this.customPanel3.BackColor2 = System.Drawing.SystemColors.Window;
            this.customPanel3.BorderColor = System.Drawing.Color.DarkGray;
            this.customPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel3.BorderWidth = 1;
            this.customPanel3.Controls.Add(this.ckbAll);
            this.customPanel3.Controls.Add(this.dgvAttachment);
            this.customPanel3.Curvature = 2;
            this.customPanel3.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.customPanel3.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.customPanel3.Location = new System.Drawing.Point(2, 2);
            this.customPanel3.Name = "customPanel3";
            this.customPanel3.Size = new System.Drawing.Size(523, 240);
            this.customPanel3.TabIndex = 12;
            // 
            // ckbAll
            // 
            this.ckbAll.AutoSize = true;
            this.ckbAll.Location = new System.Drawing.Point(7, 5);
            this.ckbAll.Name = "ckbAll";
            this.ckbAll.Size = new System.Drawing.Size(15, 14);
            this.ckbAll.TabIndex = 59;
            this.ckbAll.UseVisualStyleBackColor = true;
            this.ckbAll.CheckedChanged += new System.EventHandler(this.ckbAll_CheckedChanged);
            // 
            // dgvAttachment
            // 
            this.dgvAttachment.AllowDrop = true;
            this.dgvAttachment.AllowUserToAddRows = false;
            this.dgvAttachment.AllowUserToDeleteRows = false;
            this.dgvAttachment.AllowUserToResizeRows = false;
            this.dgvAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAttachment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAttachment.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvAttachment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAttachment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvAttachment.ColumnHeaderColor1 = System.Drawing.Color.AliceBlue;
            this.dgvAttachment.ColumnHeaderColor2 = System.Drawing.SystemColors.ControlLightLight;
            this.dgvAttachment.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAttachment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAttachment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttachment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cSelect,
            this.colExName,
            this.cModified,
            this.colExPath});
            this.dgvAttachment.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvAttachment.EnableHeadersVisualStyles = false;
            this.dgvAttachment.Location = new System.Drawing.Point(2, 3);
            this.dgvAttachment.MultiSelect = false;
            this.dgvAttachment.Name = "dgvAttachment";
            this.dgvAttachment.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvAttachment.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvAttachment.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgvAttachment.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAttachment.RowTemplate.Height = 20;
            this.dgvAttachment.SecondaryLength = 2;
            this.dgvAttachment.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvAttachment.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvAttachment.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvAttachment.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvAttachment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttachment.ShowCellErrors = false;
            this.dgvAttachment.ShowCellToolTips = false;
            this.dgvAttachment.ShowEditingIcon = false;
            this.dgvAttachment.ShowRowErrors = false;
            this.dgvAttachment.Size = new System.Drawing.Size(519, 234);
            this.dgvAttachment.TabIndex = 58;
            this.dgvAttachment.DoubleClick += new System.EventHandler(this.dgvAttachment_DoubleClick);
            // 
            // cSelect
            // 
            this.cSelect.FillWeight = 9F;
            this.cSelect.HeaderText = "";
            this.cSelect.Name = "cSelect";
            // 
            // colExName
            // 
            this.colExName.DataPropertyName = "filename";
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.colExName.DefaultCellStyle = dataGridViewCellStyle2;
            this.colExName.FillWeight = 96.88349F;
            this.colExName.HeaderText = "Name";
            this.colExName.Name = "colExName";
            this.colExName.ReadOnly = true;
            // 
            // cModified
            // 
            this.cModified.FillWeight = 98.92622F;
            this.cModified.HeaderText = "Date Modified";
            this.cModified.Name = "cModified";
            this.cModified.ReadOnly = true;
            // 
            // colExPath
            // 
            this.colExPath.DataPropertyName = "modified";
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.colExPath.DefaultCellStyle = dataGridViewCellStyle3;
            this.colExPath.FillWeight = 97.9351F;
            this.colExPath.HeaderText = "path";
            this.colExPath.Name = "colExPath";
            this.colExPath.ReadOnly = true;
            this.colExPath.Visible = false;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSend.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.Color.Black;
            this.btnSend.GlowColor = System.Drawing.Color.SkyBlue;
            this.btnSend.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnSend.Location = new System.Drawing.Point(441, 245);
            this.btnSend.Name = "btnSend";
            this.btnSend.OuterBorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnSend.ShineColor = System.Drawing.Color.WhiteSmoke;
            this.btnSend.Size = new System.Drawing.Size(84, 23);
            this.btnSend.TabIndex = 67;
            this.btnSend.Text = "Send";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // AttachmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(528, 272);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.customPanel3);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AttachmentForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Attachment List";
            this.customPanel3.ResumeLayout(false);
            this.customPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomUtil.controls.panel.CustomPanel customPanel3;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvAttachment;
        private System.Windows.Forms.CheckBox ckbAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cModified;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExPath;
        private CustomUtil.controls.button.CustomButton btnSend;
    }
}