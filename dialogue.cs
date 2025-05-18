using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACT2
{
    public partial class dialogue: Form
        
    {
        public bool UserConfirmedExit { get; private set; } = false;
        public dialogue()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FloralWhite;
            this.Size = new Size(300, 160);
            SetupUI();
            MakeRoundedEdges();
        }
        private void SetupUI()
        {
            // Label
            Label lblMessage = new Label
            {
                Text = "Do you want to exit?",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.PaleVioletRed,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 60
            };

            // Yes Button
            Button btnYes = new Button
            {
                Text = "Yes",
                BackColor = Color.PaleVioletRed,
                ForeColor = Color.MistyRose,
                FlatStyle = FlatStyle.Flat,
                Width = 100,
                Height = 35,
                Location = new Point(40, 90)
            };
            btnYes.FlatAppearance.BorderSize = 0;
            btnYes.Click += (s, e) =>
            {
                UserConfirmedExit = true;
                this.Close();
            };

            // No Button
            Button btnNo = new Button
            {
                Text = "No",
                BackColor = Color.FloralWhite,
                ForeColor = Color.RosyBrown,
                FlatStyle = FlatStyle.Flat,
                Width = 100,
                Height = 35,
                Location = new Point(160, 90)
            };
            btnNo.FlatAppearance.BorderSize = 2;
            btnNo.FlatAppearance.BorderColor = Color.PaleVioletRed;
            btnNo.Click += (s, e) => this.Close();

            // Add controls to form
            this.Controls.Add(lblMessage);
            this.Controls.Add(btnYes);
            this.Controls.Add(btnNo);
        }

        private void MakeRoundedEdges()
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 20;
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            this.Region = new Region(path);
        }

        private void dialogue_Load(object sender, EventArgs e)
        {

        }
    }

}

