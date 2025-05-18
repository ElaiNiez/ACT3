using Spire.Xls;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ACT2
{
    public partial class inactive : Form
    {
        string filePath = @"C:\Users\ACT-STUDENT\Desktop\act (3)\elai.xlsx";

        public inactive()
        {
            InitializeComponent();
            LoadExcelFile();
        }

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
                book.LoadFromFile(filePath);
                Worksheet sheet = book.Worksheets[0];

                DataTable dt = sheet.ExportDataTable();
                DataView dv = new DataView(dt);
                dv.RowFilter = "Status = '0'"; // ✅ Changed from '1' to '0'

                dgv1.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Excel file: " + ex.Message);
            }
        }

        private void dgv1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int r = dgv1.CurrentCell.RowIndex;

            Form1 f1 = new Form1();
            f1.lblId.Text = r.ToString();
            ; f1.txtName.Text = dgv1.Rows[r].Cells[0].Value?.ToString() ?? "";

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
            f1.txtAddress.Text = dgv1.Rows[r].Cells[5].Value?.ToString() ?? "";
            f1.txtStatus.Text = dgv1.Rows[r].Cells[7].Value?.ToString() ?? "";
            f1.cboCourse.SelectedItem = dgv1.Rows[r].Cells[8].Value?.ToString() ?? "";
            f1.txtEmail.Text = dgv1.Rows[r].Cells[9].Value?.ToString() ?? "";
            f1.txtUsername.Text = dgv1.Rows[r].Cells[10].Value?.ToString() ?? "";
            f1.txtPassword.Text = dgv1.Rows[r].Cells[11].Value?.ToString() ?? "";
            f1.Show();
            f1.btnUpdate.Visible = true;
            f1.btnAdd.Visible = false;
            f1.lblId.Visible = false;

            f1.ShowDialog();
        }

        private void pcbExit_Click_1(object sender, EventArgs e)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Workbook book = new Workbook();
                book.LoadFromFile(filePath);
                Worksheet sheet = book.Worksheets[0];

                int rowToDelete = dgv1.CurrentCell.RowIndex + 2; // Adjust for header
                sheet.DeleteRow(rowToDelete);
                book.SaveToFile(filePath, ExcelVersion.Version2016);

                LoadExcelFile(); // Refresh grid
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting row: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            MessageBox.Show("Please use Form1 to add new students.");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
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

        private void btnDelete_Click_1(object sender, EventArgs e)
        {

        }
    }
}
