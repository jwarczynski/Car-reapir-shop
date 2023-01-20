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
    public partial class OrdersForm : Form
    {
        public OrdersForm()
        {
            InitializeComponent();
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        protected void LoadOrders()
        {
            var orders = DatabaseService.Get().Select(DatabaseService.TABLE_ORDERS_VIEW,
                fields: new() { "orderId", "carLicensePlate", "customerName", "acceptDate", "finishDate" });

            lvOrders.BeginUpdate();
            lvOrders.Items.Clear();
            foreach (var order in orders)
            {
                var fields = order.ToArray()[1..];
                if (!string.IsNullOrEmpty(fields[2]))
                    fields[2] = DateTime.Parse(fields[2]!).ToShortDateString();
                if (!string.IsNullOrEmpty(fields[3]))
                    fields[3] = DateTime.Parse(fields[3]!).ToShortDateString();

                var item = new ListViewItem(fields);
                item.Tag = order[0];
                lvOrders.Items.Add(item);
            }
            lvOrders.EndUpdate();
        }

        private void lvOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDetails.Enabled = lvOrders.SelectedItems.Count == 1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var orderDetailsForm = new OrderDetailsForm(null);
            orderDetailsForm.ShowDialog();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (lvOrders.SelectedItems.Count != 1) return;

            var orderId = (string?)lvOrders.SelectedItems[0].Tag;
            var orderDetailsForm = new OrderDetailsForm(orderId);
            orderDetailsForm.ShowDialog();
        }
    }
}
