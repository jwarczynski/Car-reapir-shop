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
            var customers = DatabaseService.Get().Select(DatabaseService.TABLE_CUSTOMERS,
                fields: new() { "customerId", "fullName", "phoneNumber", "email", "taxId" });

            foreach (var customer in customers)
            {
                var item = new ListViewItem(customer.ToArray()[1..]);
                item.Tag = customer[0];
                lvCustomers.Items.Add(item);
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            var editCustomerForm = new EditCustomerForm(null);
            editCustomerForm.ShowDialog();
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if(lvCustomers.SelectedItems.Count != 1) return;
            var customerId = lvCustomers.SelectedItems[0].Tag.ToString();
            var editCustomerForm = new EditCustomerForm(customerId);
            editCustomerForm.ShowDialog();
        }
    }
}
