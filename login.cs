using Spire.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACT2
{
    public partial class login : Form
    {
        excelpath path= new excelpath();
        log log = new log();
        Color defaultColor;
        
        dashboard ds = new dashboard();

        public login()
        {

            InitializeComponent();
            pcbshow.Visible = false;
            txtPassword.UseSystemPasswordChar = true; // hide password by default
            defaultColor = txtUsername.BackColor; // store default color
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            
            Workbook book = new Workbook();
            book.LoadFromFile(path.path);
            Worksheet shesh = book.Worksheets[0];
            int row = shesh.Rows.Length;

            bool isLoggedIn = false;

            for (int i = 2; i <= row; i++)
            {
                if (shesh.Range[i, 11].Value == txtUsername.Text && shesh.Range[i, 12].Value == txtPassword.Text)
                {
                    
                    ds.pcbProfile.Image = Image.FromFile(shesh.Range[i, 14].Value.ToString());
                    
                    log.InsertLogs(shesh.Range[i,1].Value , " logged in.");
                    ds.lblUsername.Text = shesh.Range[i, 1].Value.ToString();
                    isLoggedIn = true;
                    break;
                }
                else
                {
                    isLoggedIn = false;
                }

            }
            if (isLoggedIn)
            {
                ds.Show();
                this.Hide();
                txtPassword.Text = "";
                txtUsername.Text = "";
            }
            else
            {
                txtUsername.Text = "Invalid Username";
                txtPassword.Text = "Invalid Password";

                txtUsername.BackColor = Color.Red;
                txtPassword.BackColor = Color.Red;

                txtPassword.UseSystemPasswordChar = false; // show text if invalid
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Invalid Username")
                txtUsername.Text = "";

            txtUsername.BackColor = defaultColor; // reset to default color
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Invalid Password")
                txtPassword.Text = "";

            txtPassword.BackColor = defaultColor; // reset to default color

            txtPassword.UseSystemPasswordChar = true; // re-hide password as you type
        }

        private void pcbhide_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false; // show password
            pcbhide.Visible = false;
            pcbshow.Visible = true;
        }

       

        private void pictureBox2_Click(object sender, EventArgs e)
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

        private void btnSign_MouseHover(object sender, EventArgs e)
        {
            btnSign.BackColor = default;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Form1 f1 = new Form1();
                f1.btnUpdate.Visible = false;
                f1.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);

            }
        }

        private void pcbshow_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true; // hide password
            pcbshow.Visible = false;
            pcbhide.Visible = true;
        }
    }
}

