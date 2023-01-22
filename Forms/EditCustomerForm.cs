using MySqlConnector;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using WarsztatSamochodowy.Services;

namespace WarsztatSamochodowy.Forms
{
    public partial class EditCustomerForm : Form
    {
        protected string? customerId;

        public EditCustomerForm(string? customerId, string? suggestedFullName = null)
        {
            this.customerId = customerId;
            InitializeComponent();
            PopulateInputs();

            if(suggestedFullName != null)
            {
                tbCustomerName.Text = suggestedFullName;
            }
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
            if (string.IsNullOrWhiteSpace(tbCustomerName.Text) || !Regex.IsMatch(tbCustomerName.Text, @"\w+ \w+"))
            {
                MessageBox.Show("Podaj imię i nazwisko klienta", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(tbPhoneNumber.Text) || !Regex.IsMatch(tbPhoneNumber.Text, @"\+?[-0-9 ]{5,15}"))
            {
                MessageBox.Show("Podaj numer telefonu klienta", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbEmailAddress.Text) && !Regex.IsMatch(tbEmailAddress.Text, @"[A-Za-z0-9\-.+_]+@[A-Za-z0-9\-.+_]+"))
            {
                MessageBox.Show("Podaj poprawny adres e-mail klienta", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Regex.IsMatch(mtbTaxId.Text, @"\d") && !mtbTaxId.MaskCompleted)
            {
                MessageBox.Show("Podaj poprawny NIP klienta", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string? emailAddress = string.IsNullOrWhiteSpace(tbEmailAddress.Text) ? null : tbEmailAddress.Text;
            string? taxId = mtbTaxId.MaskCompleted ? mtbTaxId.Text : null;

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
                            ["email"] = emailAddress,
                            ["taxId"] = taxId
                        });
                }
                else
                {
                    db.insert(DatabaseService.TABLE_CUSTOMERS,
                        new()
                        {
                            ["fullName"] = tbCustomerName.Text,
                            ["phoneNumber"] = tbPhoneNumber.Text,
                            ["email"] = emailAddress,
                            ["taxId"] = taxId
                        });
                }
                this.Close();
            } catch(MySqlException ex)
            {
                string message = "Nie udało się zapisać klienta do bazy.";
                MessageBox.Show(message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
