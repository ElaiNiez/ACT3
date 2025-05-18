using Spire.Xls;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ACT2
{
    public partial class Form1 : Form
    {
        active f2 = new active();
       excelpath path = new excelpath();
       
        public Form1()
        {
            InitializeComponent();
            MakePictureBoxCircular(pcbProfile);
            DrawCircularBorder(pcbProfile, Color.White, 3);
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
        public bool isValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            try
            {

                string pattern = @"^[^@\s]+@gmail\.com$";
                return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblId.Text); // assuming lblId is the row number to update
            string errorMessages = checkEmpty();
            string pattern = @"^[a-zA-Z0-9._%+-]+@(gmail\.com)$";

            if (!string.IsNullOrEmpty(errorMessages))
            {
                MessageBox.Show(this.checkEmpty());
                return;
            }
            string name = txtName.Text.Trim();
            string gender = rdoMale.Checked ? rdoMale.Text : (rdoFemale.Checked ? rdoFemale.Text : "");

            string hobbies = "";
            if (chkSoccer.Checked) hobbies += chkSoccer.Text + "; ";
            if (chkVolleyball.Checked) hobbies += chkVolleyball.Text + "; ";
            if (chkBasketball.Checked) hobbies += chkBasketball.Text + "; ";
            hobbies = hobbies.Trim();

            string birthday = dtp1.Text.Trim();
            string color = cbo.Text.Trim();
            string address = txtAddress.Text.Trim();
            string age = txtAge.Text.Trim();
            string course = cboCourse.Text.Trim();
            string email = txtEmail.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string saying = txtStatus.Text.Trim();

            Workbook book = new Workbook();
            book.LoadFromFile(path.path);
            Worksheet sheet = book.Worksheets[0];

            int updateRow = id + 2; // because 1st row is headers

            sheet.Range[updateRow, 1].Value = name;
            sheet.Range[updateRow, 2].Value = gender;
            sheet.Range[updateRow, 3].Value = hobbies;
            sheet.Range[updateRow, 4].Value = birthday;
            sheet.Range[updateRow, 5].Value = color;
            sheet.Range[updateRow, 6].Value = address;
            sheet.Range[updateRow, 7].Value = age;
            sheet.Range[updateRow, 8].Value = saying;
            sheet.Range[updateRow, 9].Value = course;
            sheet.Range[updateRow, 10].Value = email;
            sheet.Range[updateRow, 11].Value = username;
            sheet.Range[updateRow, 12].Value = password;
            sheet.Range[updateRow, 14].Value = lblPathPic.Text;

            book.SaveToFile(path.path, ExcelVersion.Version2016);
            f2.LoadExcelFile();
            string errorMsg = checkEmpty();
            if (!string.IsNullOrEmpty(errorMsg))
            {
                MessageBox.Show(errorMsg, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // If no errors, proceed
            MessageBox.Show("Form submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            MessageBox.Show("Successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();
            active active = new active();
            active.Show();
            this.Hide();
        }
        public string checkEmpty()
        {
            string errors = "";

            foreach (Control c in Controls)
            {
                // TextBox check
                if (c is TextBox tb && string.IsNullOrWhiteSpace(tb.Text))
                {
                    errors += $"{tb.Name} is empty. Please fill it in.\n";
                }

                // ComboBox check
                else if (c is ComboBox cmb && cmb.SelectedIndex == -1)
                {
                    errors += "Please select a course.\n";
                }
            }

            // Check if at least one CheckBox (for hobbies) is checked
            bool hasChecked = Controls.OfType<CheckBox>().Any(cb => cb.Checked);
            if (!hasChecked)
            {
                errors += "Please select at least one hobby.\n";
            }

            // Gender RadioButtons check
            if (!rdoMale.Checked && !rdoFemale.Checked)
            {
                errors += "Please select a gender.\n";
            }

            return errors.Trim();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            string errorMsg = checkEmpty();
            if (!string.IsNullOrEmpty(errorMsg))
            {
                MessageBox.Show(errorMsg, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

    

        private void ClearForm()
        {
           
            txtName.Clear();
            rdoMale.Checked = false;
            rdoFemale.Checked = false;
            chkBasketball.Checked = false;
            chkVolleyball.Checked = false;
            chkSoccer.Checked = false;
            cbo.Text = null;
            cboCourse = null;
            txtStatus.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            lblPathPic.Text = null;
            txtUsername.Clear();
            dtp1.Text = null;
        }

       
        private void btnSave_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a Picture";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(openFileDialog.FileName);
               // pcbProfile.Image = Image.FromFile(openFileDialog.FileName);
               //pcbProfile.Text = openFileDialog.FileName;
                lblPathPic.Text = openFileDialog.FileName;
                MessageBox.Show("Image selected successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No image selected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       
        private void dtp1_ValueChanged(object sender, EventArgs e)
        {
            DateTime birthdate = dtp1.Value;
            DateTime today = DateTime.Today;
            int age = today.Year - birthdate.Year;
            if (birthdate.Date > today.AddYears(-age))
            {
                age--;
            }
            txtAge.Text = age.ToString();
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
    }
}
