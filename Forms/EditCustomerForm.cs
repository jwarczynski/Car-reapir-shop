using MySqlConnector;

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
    public partial class EditCustomerForm : Form
    {
        protected string? customerId;

        public EditCustomerForm(string? customerId)
        {
            this.customerId = customerId;
            InitializeComponent();
            PopulateInputs();
        }

        protected void PopulateInputs()
        {
            if(customerId == null)
            {
                return;
            }
            var customers = DatabaseService.Get().Select(DatabaseService.TABLE_CUSTOMERS,
                new() { ["customerId"] = customerId },
                new() { "fullName", "phoneNumber", "email", "taxId" });

            if (customers.Count != 1) return;
            var customer = customers[0];

            tbCustomerName.Text = customer[0];
            tbPhoneNumber.Text = customer[1];
            tbEmailAddress.Text = customer[2];
            mtbTaxId.Text = customer[3];
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var db = DatabaseService.Get();
                if(customerId != null)
                {
                    db.update(DatabaseService.TABLE_CUSTOMERS,
                        new() { ["customerId"] = customerId },
                        new() {
                            ["fullName"] = tbCustomerName.Text,
                            ["phoneNumber"] = tbPhoneNumber.Text,
                            ["email"] = tbEmailAddress.Text,
                            ["taxId"] = mtbTaxId.Text
                        });
                }
                else
                {
                    db.insert(DatabaseService.TABLE_CUSTOMERS,
                        new()
                        {
                            ["fullName"] = tbCustomerName.Text,
                            ["phoneNumber"] = tbPhoneNumber.Text,
                            ["email"] = tbEmailAddress.Text,
                            ["taxId"] = mtbTaxId.Text
                        });
                }
                this.Close();
            } catch(MySqlException ex)
            {
                string message = "Nie udało się zapisać klienta do bazy." + ex.Message;
                MessageBox.Show(message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
