namespace KDTHK_DM_SP.backup
{
    partial class Backup
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDocBackup = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.colImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.colFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ckeyword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShared = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colowner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colread = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colpath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colvpath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colfav = new System.Windows.Forms.DataGridViewImageColumn();
            this.cDisc = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvDoc = new System.Windows.Forms.DataGridView();
            this.cImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cShared = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cvpath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFavorite = new System.Windows.Forms.DataGridViewImageColumn();
            this.cStatus = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocBackup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoc)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDocBackup
            // 
            this.dgvDocBackup.AllowDrop = true;
            this.dgvDocBackup.AllowUserToAddRows = false;
            this.dgvDocBackup.AllowUserToDeleteRows = false;
            this.dgvDocBackup.AllowUserToResizeRows = false;
            this.dgvDocBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDocBackup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDocBackup.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvDocBackup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDocBackup.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvDocBackup.ColumnHeaderColor1 = System.Drawing.Color.AliceBlue;
            this.dgvDocBackup.ColumnHeaderColor2 = System.Drawing.SystemColors.ControlLightLight;
            this.dgvDocBackup.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocBackup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDocBackup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocBackup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colImg,
            this.colFilename,
            this.ckeyword,
            this.colModified,
            this.colShared,
            this.colowner,
            this.colread,
            this.coltype,
            this.colpath,
            this.colvpath,
            this.colfav,
            this.cDisc});
            this.dgvDocBackup.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDocBackup.EnableHeadersVisualStyles = false;
            this.dgvDocBackup.Location = new System.Drawing.Point(-39, 115);
            this.dgvDocBackup.Name = "dgvDocBackup";
            this.dgvDocBackup.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvDocBackup.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvDocBackup.RowHeadersVisible = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDocBackup.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDocBackup.RowTemplate.Height = 20;
            this.dgvDocBackup.SecondaryLength = 2;
            this.dgvDocBackup.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvDocBackup.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvDocBackup.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvDocBackup.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvDocBackup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocBackup.ShowCellErrors = false;
            this.dgvDocBackup.ShowCellToolTips = false;
            this.dgvDocBackup.ShowEditingIcon = false;
            this.dgvDocBackup.ShowRowErrors = false;
            this.dgvDocBackup.Size = new System.Drawing.Size(363, 32);
            this.dgvDocBackup.TabIndex = 59;
            this.dgvDocBackup.Visible = false;
            // 
            // colImg
            // 
            this.colImg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colImg.DataPropertyName = "img";
            this.colImg.FillWeight = 10F;
            this.colImg.HeaderText = "";
            this.colImg.Name = "colImg";
            this.colImg.Width = 5;
            // 
            // colFilename
            // 
            this.colFilename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colFilename.DataPropertyName = "filename";
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.colFilename.DefaultCellStyle = dataGridViewCellStyle2;
            this.colFilename.FillWeight = 97.9351F;
            this.colFilename.HeaderText = "Name";
            this.colFilename.Name = "colFilename";
            this.colFilename.ReadOnly = true;
            this.colFilename.Width = 61;
            // 
            // ckeyword
            // 
            this.ckeyword.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ckeyword.HeaderText = "Keyword";
            this.ckeyword.Name = "ckeyword";
            this.ckeyword.ReadOnly = true;
            this.ckeyword.Width = 77;
            // 
            // colModified
            // 
            this.colModified.DataPropertyName = "modified";
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.colModified.DefaultCellStyle = dataGridViewCellStyle3;
            this.colModified.FillWeight = 97.9351F;
            this.colModified.HeaderText = "Date Modified";
            this.colModified.Name = "colModified";
            this.colModified.ReadOnly = true;
            // 
            // colShared
            // 
            this.colShared.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colShared.DataPropertyName = "shared";
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.colShared.DefaultCellStyle = dataGridViewCellStyle4;
            this.colShared.FillWeight = 97.9351F;
            this.colShared.HeaderText = "Shared";
            this.colShared.Name = "colShared";
            this.colShared.ReadOnly = true;
            this.colShared.Width = 68;
            // 
            // colowner
            // 
            this.colowner.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colowner.DataPropertyName = "owner";
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.colowner.DefaultCellStyle = dataGridViewCellStyle5;
            this.colowner.HeaderText = "Owner";
            this.colowner.Name = "colowner";
            this.colowner.ReadOnly = true;
            this.colowner.Width = 66;
            // 
            // colread
            // 
            this.colread.DataPropertyName = "read";
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.colread.DefaultCellStyle = dataGridViewCellStyle6;
            this.colread.FillWeight = 30F;
            this.colread.HeaderText = "Read";
            this.colread.Name = "colread";
            this.colread.ReadOnly = true;
            // 
            // coltype
            // 
            this.coltype.DataPropertyName = "type";
            this.coltype.HeaderText = "type";
            this.coltype.Name = "coltype";
            this.coltype.Visible = false;
            // 
            // colpath
            // 
            this.colpath.DataPropertyName = "path";
            this.colpath.HeaderText = "path";
            this.colpath.Name = "colpath";
            this.colpath.Visible = false;
            // 
            // colvpath
            // 
            this.colvpath.HeaderText = "vpath";
            this.colvpath.Name = "colvpath";
            this.colvpath.Visible = false;
            // 
            // colfav
            // 
            this.colfav.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colfav.DataPropertyName = "favorite";
            this.colfav.HeaderText = "Favorite";
            this.colfav.Name = "colfav";
            this.colfav.Width = 56;
            // 
            // cDisc
            // 
            this.cDisc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.cDisc.HeaderText = "Status";
            this.cDisc.Name = "cDisc";
            this.cDisc.Width = 45;
            // 
            // dgvDoc
            // 
            this.dgvDoc.AllowDrop = true;
            this.dgvDoc.AllowUserToAddRows = false;
            this.dgvDoc.AllowUserToDeleteRows = false;
            this.dgvDoc.AllowUserToResizeRows = false;
            this.dgvDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoc.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvDoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDoc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDoc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cImg,
            this.cName,
            this.dataGridViewTextBoxColumn1,
            this.cModified,
            this.cShared,
            this.cOwner,
            this.cRead,
            this.cType,
            this.cPath,
            this.cvpath,
            this.cFavorite,
            this.cStatus});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDoc.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDoc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDoc.GridColor = System.Drawing.Color.Silver;
            this.dgvDoc.Location = new System.Drawing.Point(12, 12);
            this.dgvDoc.Name = "dgvDoc";
            this.dgvDoc.ReadOnly = true;
            this.dgvDoc.RowHeadersVisible = false;
            this.dgvDoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoc.ShowCellErrors = false;
            this.dgvDoc.ShowCellToolTips = false;
            this.dgvDoc.ShowEditingIcon = false;
            this.dgvDoc.ShowRowErrors = false;
            this.dgvDoc.Size = new System.Drawing.Size(862, 148);
            this.dgvDoc.TabIndex = 62;
            // 
            // cImg
            // 
            this.cImg.FillWeight = 10F;
            this.cImg.HeaderText = "";
            this.cImg.Name = "cImg";
            this.cImg.ReadOnly = true;
            // 
            // cName
            // 
            this.cName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cName.HeaderText = "Name";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            this.cName.Width = 60;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "Keyword";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 73;
            // 
            // cModified
            // 
            this.cModified.HeaderText = "Modified";
            this.cModified.Name = "cModified";
            this.cModified.ReadOnly = true;
            // 
            // cShared
            // 
            this.cShared.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cShared.HeaderText = "Shared";
            this.cShared.Name = "cShared";
            this.cShared.ReadOnly = true;
            this.cShared.Width = 66;
            // 
            // cOwner
            // 
            this.cOwner.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cOwner.HeaderText = "Owner";
            this.cOwner.Name = "cOwner";
            this.cOwner.ReadOnly = true;
            this.cOwner.Width = 63;
            // 
            // cRead
            // 
            this.cRead.FillWeight = 30F;
            this.cRead.HeaderText = "Read";
            this.cRead.Name = "cRead";
            this.cRead.ReadOnly = true;
            // 
            // cType
            // 
            this.cType.HeaderText = "type";
            this.cType.Name = "cType";
            this.cType.ReadOnly = true;
            this.cType.Visible = false;
            // 
            // cPath
            // 
            this.cPath.HeaderText = "path";
            this.cPath.Name = "cPath";
            this.cPath.ReadOnly = true;
            this.cPath.Visible = false;
            // 
            // cvpath
            // 
            this.cvpath.HeaderText = "vpath";
            this.cvpath.Name = "cvpath";
            this.cvpath.ReadOnly = true;
            this.cvpath.Visible = false;
            // 
            // cFavorite
            // 
            this.cFavorite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cFavorite.FillWeight = 10F;
            this.cFavorite.HeaderText = "Favorite";
            this.cFavorite.Name = "cFavorite";
            this.cFavorite.ReadOnly = true;
            this.cFavorite.Width = 70;
            // 
            // cStatus
            // 
            this.cStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cStatus.HeaderText = "Status";
            this.cStatus.Name = "cStatus";
            this.cStatus.ReadOnly = true;
            this.cStatus.Width = 43;
            // 
            // Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.dgvDoc);
            this.Controls.Add(this.dgvDocBackup);
            this.Name = "Backup";
            this.Text = "Backup";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocBackup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomUtil.controls.datagrid.CustomDatagrid dgvDocBackup;
        private System.Windows.Forms.DataGridViewImageColumn colImg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFilename;
        private System.Windows.Forms.DataGridViewTextBoxColumn ckeyword;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModified;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShared;
        private System.Windows.Forms.DataGridViewTextBoxColumn colowner;
        private System.Windows.Forms.DataGridViewTextBoxColumn colread;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltype;
        private System.Windows.Forms.DataGridViewTextBoxColumn colpath;
        private System.Windows.Forms.DataGridViewTextBoxColumn colvpath;
        private System.Windows.Forms.DataGridViewImageColumn colfav;
        private System.Windows.Forms.DataGridViewImageColumn cDisc;
        private System.Windows.Forms.DataGridView dgvDoc;
        private System.Windows.Forms.DataGridViewImageColumn cImg;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cModified;
        private System.Windows.Forms.DataGridViewTextBoxColumn cShared;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRead;
        private System.Windows.Forms.DataGridViewTextBoxColumn cType;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn cvpath;
        private System.Windows.Forms.DataGridViewImageColumn cFavorite;
        private System.Windows.Forms.DataGridViewImageColumn cStatus;
    }
}