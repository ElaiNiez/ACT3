using System.Security.Cryptography.X509Certificates;

namespace ACT2
{
    partial class active
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
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlActive = new System.Windows.Forms.Panel();
            this.pnlInactive = new System.Windows.Forms.Panel();
            this.pcbExit = new System.Windows.Forms.PictureBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.pnlActive.SuspendLayout();
            this.pnlInactive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbExit)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.BackgroundColor = System.Drawing.Color.PaleVioletRed;
            this.dgv1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(68, 94);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(855, 309);
            this.dgv1.TabIndex = 0;
            this.dgv1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellClick);
            this.dgv1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv1_CellMouseDoubleClick);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.MistyRose;
            this.txtSearch.Location = new System.Drawing.Point(475, 54);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(310, 20);
            this.txtSearch.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Rockwell Extra Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(776, 51);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(133, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlActive
            // 
            this.pnlActive.Controls.Add(this.pnlInactive);
            this.pnlActive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlActive.Location = new System.Drawing.Point(0, 0);
            this.pnlActive.Name = "pnlActive";
            this.pnlActive.Size = new System.Drawing.Size(984, 561);
            this.pnlActive.TabIndex = 5;
            // 
            // pnlInactive
            // 
            this.pnlInactive.BackColor = System.Drawing.Color.MistyRose;
            this.pnlInactive.Controls.Add(this.pcbExit);
            this.pnlInactive.Controls.Add(this.btnDelete);
            this.pnlInactive.Controls.Add(this.btnAdd);
            this.pnlInactive.Controls.Add(this.txtSearch);
            this.pnlInactive.Controls.Add(this.btnSearch);
            this.pnlInactive.Controls.Add(this.dgv1);
            this.pnlInactive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInactive.Location = new System.Drawing.Point(0, 0);
            this.pnlInactive.Name = "pnlInactive";
            this.pnlInactive.Size = new System.Drawing.Size(984, 561);
            this.pnlInactive.TabIndex = 6;
            // 
            // pcbExit
            // 
            this.pcbExit.Image = global::ACT2.Properties.Resources.reject;
            this.pcbExit.Location = new System.Drawing.Point(951, 3);
            this.pcbExit.Name = "pcbExit";
            this.pcbExit.Size = new System.Drawing.Size(30, 30);
            this.pcbExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbExit.TabIndex = 13;
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
            this.btnDelete.Location = new System.Drawing.Point(568, 446);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(166, 47);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Firebrick;
            this.btnAdd.Location = new System.Drawing.Point(349, 446);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(166, 47);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add Student";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // active
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.pnlActive);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "active";
            this.Text = "f2";
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.pnlActive.ResumeLayout(false);
            this.pnlInactive.ResumeLayout(false);
            this.pnlInactive.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

      public System.Windows.Forms.DataGridView dgv1;
        public System.Windows.Forms.TextBox txtSearch;
        public System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.Panel pnlActive;
        public System.Windows.Forms.Panel pnlInactive;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.PictureBox pcbExit;
    }
}