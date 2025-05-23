﻿using Spire.Xls;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ACT2
{
    public partial class active : Form
    {
        log logg = new log();
        excelpath path = new excelpath();

        public active()
        {
            InitializeComponent();
            LoadExcelFile();
        }
        string uniqueID;




        public void LoadExcelFile()
        {
            try
            {
                dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgv1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgv1.ColumnHeadersDefaultCellStyle.BackColor = Color.PaleVioletRed;
                dgv1.ColumnHeadersDefaultCellStyle.ForeColor = Color.MistyRose;
                dgv1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgv1.EnableHeadersVisualStyles = false;

                Workbook book = new Workbook();
                book.LoadFromFile(path.path);
                Worksheet sheet = book.Worksheets[0];

                DataTable dt = sheet.ExportDataTable();
                DataView dv = new DataView(dt);
                dv.RowFilter = "Status = '1'";

                dgv1.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Excel file: " + ex.Message);
            }
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int r = dgv1.CurrentCell.RowIndex;
           
            Form1 f1 = new Form1();
            f1.btnAdd.Visible = false;
            this.Hide();
            f1.lblId.Text = r.ToString();
;            f1.txtName.Text = dgv1.Rows[r].Cells[0].Value?.ToString() ?? "";

            string gender = dgv1.Rows[r].Cells[1].Value?.ToString();
            f1.rdoMale.Checked = (gender == "Male");
            f1.rdoFemale.Checked = (gender == "female");

            string hobbyString = dgv1.Rows[r].Cells[2].Value?.ToString() ?? "";
            string[] hobbies = hobbyString.Split(',');
            foreach (string s in hobbies.Select(h => h.Trim()))
            {
                if (s == "Soccer") f1.chkSoccer.Checked = true;
                if (s == "Volleyball") f1.chkVolleyball.Checked = true;
                if (s == "Basketball") f1.chkBasketball.Checked = true;
            }

            if (DateTime.TryParse(dgv1.Rows[r].Cells[3].Value?.ToString(), out DateTime parsedDate))
            {
                f1.dtp1.Value = parsedDate;
            }
            else
            {
                f1.dtp1.Value = DateTime.Today; // fallback
            }
            f1.cbo.SelectedItem = dgv1.Rows[r].Cells[4].Value?.ToString() ?? "";
            f1.txtAddress.Text= dgv1.Rows[r].Cells[5].Value?.ToString() ?? "";
            f1.txtStatus.Text= dgv1.Rows[r].Cells[7].Value?.ToString() ?? "";
            f1.cboCourse.SelectedItem = dgv1.Rows[r].Cells[8].Value?.ToString() ?? "";
            f1.txtEmail.Text = dgv1.Rows[r].Cells[9].Value?.ToString() ?? "";
            f1.txtUsername.Text = dgv1.Rows[r].Cells[10].Value?.ToString() ?? "";
            f1.txtPassword.Text = dgv1.Rows[r].Cells[11].Value?.ToString() ?? "";
            f1.Show();
            f1.lblId.Visible = false;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
          
            log log = new log();
            dashboard ds = new dashboard();
            log.InsertLogs(ds.userName, $"Added a student");
            dgv1.ClearSelection();  
            try
            {
                foreach (DataGridViewRow row in dgv1.Rows)
                {
                    if (row.Cells[0].Value?.ToString().Equals(txtSearch.Text, StringComparison.OrdinalIgnoreCase) == true)
                    {
                        row.Selected = true;
                        dgv1.FirstDisplayedScrollingRowIndex = row.Index;
                        return;
                    }
                }
                MessageBox.Show("Not Found", "Search", MessageBoxButtons.OK);
            }
            catch
            {
                MessageBox.Show("Error during search", "Error", MessageBoxButtons.OK);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            f1.btnUpdate.Visible = false;
            f1.Show();
            this.Hide();
            log log = new log();
            dashboard ds = new dashboard();
            log.InsertLogs(ds.userName,$"Added a student");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgv1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a student to delete.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow selectedrow = dgv1.SelectedRows[0];
                string username = selectedrow.Cells[11].Value.ToString();

                if(string.IsNullOrEmpty(username) )
                {
                    MessageBox.Show("Unable to identify the selected student.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show($"Are you sure you want '{username}' as inactive?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    return;
                }

                Workbook book = new Workbook();
                book.LoadFromFile(path.path);
                Worksheet sheet = book.Worksheets[0];

                bool found = false;
                for (int row = 2; row<=sheet.LastRow; row++)
                {
                    string currentusername = sheet.Range[row, "sheetcolumnsausername"].Value.ToString();

                    if(currentusername == username)
                    {
                        sheet.Range[row, "statuscolumnsasheet"].Value = "0";
                        found = true;
                    }
                }

                book.SaveToFile(path.path, ExcelVersion.Version2016);

                int r = dgv1.CurrentCell.RowIndex + 2;
                //para ni para sa mylogs here na  line//
                mylogs.insertLogs();
               //

               if(found)
                {
                    dgv1.Rows.Remove(selectedrow);

                }
                else
                {
                    MessageBox.Show($"Could not find student with identifier '{username}' in the Excel Sheet.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
            catch(Exception ex) 
            {
             MessageBox.Show($"An error occured while marking the student inactive: {ex.Message}");
            }
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

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            uniqueID = dgv1.CurrentRow.Cells[0].Value.ToString();
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
