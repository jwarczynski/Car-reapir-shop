using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WarsztatSamochodowy.Services;

namespace WarsztatSamochodowy.Forms
{
    public partial class EditPartForm : Form
    {
        protected string? partCode;

        public EditPartForm(string? partCode)
        {
            InitializeComponent();
            this.partCode = partCode;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditPartForm_Load(object sender, EventArgs e)
        {
            PopulateInputs();
        }

        private void PopulateInputs()
        {
            ClearInputs();
            if (partCode == null) return;

            SortedDictionary<string, string> condition = new();
            condition["partCode"] = partCode;

            var parts = DatabaseService.Get().Select(DatabaseService.TABLE_PARTS, condition);
            var fields = parts[0];

            if (fields == null)
            {
                MessageBox.Show($"Część o kodzie '{partCode}' nie istnieje", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            tbPartName.Text = fields[1]?.ToString() ?? "";
            tbPartCode.Text = fields[0]?.ToString() ?? "";
            tbMaxInStock.Text = fields[4]?.ToString() ?? "";
            tbUnitPrice.Text = fields[2]?.ToString() ?? "";
        }

        private void ClearInputs()
        {
            tbPartName.Text = "";
            tbPartCode.Text = "";
            tbMaxInStock.Text = "";
            tbUnitPrice.Text = "";
        }
    }
}
