using MySqlConnector;
using E = MySqlConnector.MySqlErrorCode;

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
    public partial class CustomersForm : Form
    {
        public CustomersForm()
        {
            InitializeComponent();
        }

        private void CustomersForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        protected void LoadCustomers()
        {
            var customers = DatabaseService.Get().Select(DatabaseService.TABLE_CUSTOMERS,
                fields: new() { "customerId", "fullName", "phoneNumber", "email", "taxId" });

            lvCustomers.BeginUpdate();
            lvCustomers.Items.Clear();
            foreach (var customer in customers)
            {
                var item = new ListViewItem(customer.ToArray()[1..]);
                item.Tag = customer[0];
                lvCustomers.Items.Add(item);
            }
            lvCustomers.EndUpdate();

            UpdateButtonsState();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            var editCustomerForm = new EditCustomerForm(null);
            editCustomerForm.ShowDialog();
            LoadCustomers();
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            EditSelectedCustomer();
        }

        private void lvCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }

        protected void UpdateButtonsState()
        {
            btnEditCustomer.Enabled = lvCustomers.SelectedItems.Count == 1;
            btnRemoveCustomer.Enabled = lvCustomers.SelectedItems.Count == 1;
        }

        private void lvCustomers_ItemActivate(object sender, EventArgs e)
        {
            EditSelectedCustomer();
        }

        protected void EditSelectedCustomer()
        {
            if (lvCustomers.SelectedItems.Count != 1) return;
            var customerId = lvCustomers.SelectedItems[0].Tag.ToString();
            var editCustomerForm = new EditCustomerForm(customerId);
            editCustomerForm.ShowDialog();
            LoadCustomers();
        }

        private void btnRemoveCustomer_Click(object sender, EventArgs e)
        {
            if (lvCustomers.SelectedItems.Count != 1) return;
            var selectedItem = lvCustomers.SelectedItems[0];
            var customerId = selectedItem.Tag.ToString();

            try
            {
                DatabaseService.Get().delete(DatabaseService.TABLE_CUSTOMERS,
                    new() { ["customerId"] = customerId });
                selectedItem.Remove();
            } catch (MySqlException ex)
            {
                string message =  ex.ErrorCode switch {
                    _ => $"Nie udało się usunąć klienta. (Kod błędu: ${ex.ErrorCode})"
                };
                MessageBox.Show(message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            string? customerId = null;
            if(lvCustomers.SelectedItems.Count == 1)
                customerId = (string?)lvCustomers.SelectedItems[0].Tag;

            var orderDetailsForm = new OrderDetailsForm(null, customerId);
            orderDetailsForm.ShowDialog();
        }
    }
}
