using Spire.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ACT2
{
    public partial class log : Form
    {
        excelpath path = new excelpath();

        public log()
        {
            InitializeComponent();
            LoadExcelFile();
        }


        public void InsertLogs(string user, string message)
        {
            Workbook book = new Workbook();
            book.LoadFromFile(path.path);
            Worksheet shesh = book.Worksheets[1];

            int lastRow = shesh.LastRow + 1; // Get the next empty row
            shesh.Range[lastRow, 1].Value = user;
            shesh.Range[lastRow, 2].Value = message;
            shesh.Range[lastRow, 3].Value = DateTime.Now.ToString("MM/dd/yyyy");
            shesh.Range[lastRow, 4].Value = DateTime.Now.ToString("hh:mm:ss tt");

            book.SaveToFile(path.path, ExcelVersion.Version2016);

            LoadExcelFile();
        }

        public void LoadExcelFile()
        {
            Workbook book = new Workbook();
            book.LoadFromFile(path.path);
            Worksheet shesh = book.Worksheets[1];

            DataTable dt = shesh.ExportDataTable(shesh.FirstRow, shesh.FirstColumn, shesh.LastRow, shesh.LastColumn, true);
            dgvLog.DataSource = dt;

            dgvLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLog.ColumnHeadersDefaultCellStyle.BackColor = Color.PaleVioletRed;
            dgvLog.ColumnHeadersDefaultCellStyle.ForeColor = Color.MistyRose;
            dgvLog.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvLog.EnableHeadersVisualStyles = false;
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

        private void dgvLog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
