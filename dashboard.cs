using Spire.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ACT2
{
    public partial class dashboard: Form
    {
        public string userName;
        string filePath = @"C:\Users\ACT-STUDENT\Desktop\act (3)\elai.xlsx";


        public dashboard() // Constructor to receive the name
        {
            InitializeComponent();         

            lblMenResult.Text = Showcount(2, "Male").ToString();
            lblInactiveResult.Text = Showcount(13, "0").ToString();
            lblWomenResult.Text = Showcount(2, "Female").ToString();
            lblActiveResult.Text = Showcount(13, "1").ToString();
            lblBlackResult.Text = Showcount(5, "black").ToString();
            lblRedResult.Text = Showcount(5, "red").ToString();
            lblWhiteResult.Text = Showcount(5, "white").ToString();
            lblGreenResult.Text = Showcount(5, "green").ToString();
            lblBasketballResult.Text = Showcount(3, "basketball").ToString();
            lblVolleyballResult.Text = Showcount(3, "volleyball").ToString();
            lblSoccerResult.Text = Showcount(3, "soccer").ToString();
            lblitresult.Text = Showcount(9, "bsit").ToString();
            lblcsresult.Text = Showcount(9, "bscs").ToString();
            lblCPEresult.Text = Showcount(9, "bsCpE").ToString();
            

            MakePictureBoxCircular(pcbProfile); 
            DrawCircularBorder(pcbProfile, Color.White, 3) ;      
        }

       

        public int Showcount(int c, string v)
        {
            Workbook book = new Workbook();
            book.LoadFromFile(filePath);
            Worksheet shesh = book.Worksheets[0];
            int row = shesh.Rows.Length;
            int counter = 0;


            for (int r = 2; r <= row; r++)
            {
                string value = shesh.Range[r, c].Value.ToLower();
                if (value == v.ToLower())
                {
                    string status = shesh.Range[r, 13].Value; // Assuming column 13 is 'status'
                    if (status == "1") // filter only active records
                    {
                        counter++;
                    }
                    if (status == "0")
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }
        private void MakePictureBoxCircular(PictureBox pic)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pic.Width, pic.Height);
            pic.Region = new Region(path);
        }
        private void DrawCircularBorder(PictureBox pic, Color borderColor, int borderThickness)
        {
            pic.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(borderColor, borderThickness))
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.DrawEllipse(pen, borderThickness / 2, borderThickness / 2, pic.Width - borderThickness, pic.Height - borderThickness);
                }
            };
        }

 
        private void btnActive_Click(object sender, EventArgs e)
        {
            active act = new active();
            act.Show();
            
        }

  

        private void pcbExit_Click(object sender, EventArgs e)
        {
            using (dialogue dialog = new dialogue())
            {
                dialog.ShowDialog();
                if (dialog.UserConfirmedExit)
                {
                    this.Close();
                }
            }
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            log log = new log();
            log.InsertLogs(userName, "Opened the logs form.");
            log.Show();

        }

        private void btnInactive_Click(object sender, EventArgs e)
        {

            inactive acte = new inactive();
            acte.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            login login = new login();
           
        
           log logs = new log();
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                logs.InsertLogs(userName, "User logged out.");
                this.Hide();
                login.Show();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.btnUpdate.Visible = false;
            f1.Show();
            this.Hide();
            
           
        }
    }
}
