namespace ACT2
{
    partial class inactive
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
            this.pcbExit = new System.Windows.Forms.PictureBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pcbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbExit
            // 
            this.pcbExit.Image = global::ACT2.Properties.Resources.reject;
            this.pcbExit.Location = new System.Drawing.Point(1420, 11);
            this.pcbExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pcbExit.Name = "pcbExit";
            this.pcbExit.Size = new System.Drawing.Size(45, 46);
            this.pcbExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbExit.TabIndex = 19;
            this.pcbExit.TabStop = false;
            this.pcbExit.Click += new System.EventHandler(this.pcbExit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Firebrick;
            this.btnDelete.Location = new System.Drawing.Point(846, 692);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(249, 72);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Firebrick;
            this.btnAdd.Location = new System.Drawing.Point(518, 692);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(249, 72);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.Text = "Add Student";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.MistyRose;
            this.txtSearch.Location = new System.Drawing.Point(706, 89);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(463, 26);
            this.txtSearch.TabIndex = 15;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.btnSearch.Location = new System.Drawing.Point(1180, 85);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(200, 57);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // dgv1
            // 
            this.dgv1.BackgroundColor = System.Drawing.Color.PaleVioletRed;
            this.dgv1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(96, 151);
            this.dgv1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersWidth = 62;
            this.dgv1.Size = new System.Drawing.Size(1282, 475);
            this.dgv1.TabIndex = 14;
            this.dgv1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv1_CellMouseDoubleClick);
            // 
            // inactive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1476, 863);
            this.Controls.Add(this.pcbExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgv1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "inactive";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "inactive";
            ((System.ComponentModel.ISupportInitialize)(this.pcbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbExit;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.TextBox txtSearch;
        public System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.DataGridView dgv1;
    }
}