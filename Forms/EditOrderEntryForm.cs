using MySqlConnector;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WarsztatSamochodowy.Services;

namespace WarsztatSamochodowy.Forms
{
    public partial class EditOrderEntryForm : Form
    {
        protected string carLicensePlate;
        protected string orderId;
        protected string? entryId;

        protected Dictionary<string, decimal> serviceCosts;

        public EditOrderEntryForm(string carLicensePlate, string orderId, string? entryId)
        {
            this.carLicensePlate = carLicensePlate;
            this.orderId = orderId;
            this.entryId = entryId;

            InitializeComponent();
        }

        private void EditOrderEntryForm_Load(object sender, EventArgs e)
        {
            PopulateServices();

            if(entryId == null)
            {
                gbEmployee.Enabled = false;
                gbComment.Enabled = false;
                return;
            }

            var entry = DatabaseService.Get().Select(DatabaseService.TABLE_ORDER_ENTRIES,
                new() { ["orderId"] = orderId, ["position"] = entryId },
                new() { "serviceName", "actualCost", "employeeName", "date", "isDone", "comment" })[0];

            cbService.SelectedItem = entry[0];
            tbCost.Text = !string.IsNullOrWhiteSpace(entry[1]) ? entry[1] : serviceCosts[entry[0]!].ToString();
            ckIndividualPrice.Checked = !string.IsNullOrWhiteSpace(entry[1]);
        }

        protected void PopulateServices()
        {
            var services = DatabaseService.Get().Select(DatabaseService.TABLE_SERVICES_FOR_CAR,
                new() { ["licensePlate"] = carLicensePlate },
                new() { "serviceName", "standardCost" });

            serviceCosts = new();
            cbService.BeginUpdate();
            cbService.Items.Clear();
            foreach(var service in services)
            {
                serviceCosts[service[0]!] = decimal.Parse(service[1]!);
                cbService.Items.Add(service[0]);
            }
            cbService.EndUpdate();
        }

        private void ckIndividualPrice_CheckedChanged(object sender, EventArgs e)
        {
            tbCost.ReadOnly = !ckIndividualPrice.Checked;
            if(tbCost.ReadOnly)
            {
                tbCost.Text = serviceCosts[cbService.SelectedItem.ToString()!].ToString();
            }
        }

        private void cbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!ckIndividualPrice.Checked && cbService.SelectedIndex >= 0)
            {
                tbCost.Text = serviceCosts[cbService.SelectedItem.ToString()!].ToString();
            }
        }

        private void btnSaveService_Click(object sender, EventArgs e)
        {
            if(cbService.SelectedIndex < 0)
            {
                MessageBox.Show("Wybierz usługę.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string serviceName = cbService.SelectedItem.ToString()!;

            string? actualCost = null;
            if(ckIndividualPrice.Checked)
            {
                if(!float.TryParse(tbCost.Text, out float price))
                {
                    MessageBox.Show("Podano niepoprawną cenę.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                actualCost = price.ToString(CultureInfo.InvariantCulture);
            }

            var db = DatabaseService.Get();
            try
            {
                if (entryId != null)
                {
                    db.update(DatabaseService.TABLE_ORDER_ENTRIES,
                        new() { ["orderId"] = orderId, ["position"] = entryId },
                        new() { ["serviceName"] = serviceName, ["actualCost"] = actualCost });
                }
                else
                {
                    entryId = db.CallFunction(DatabaseService.FUNC_ADD_ORDER_ENTRY,
                        new() { orderId, serviceName, actualCost })!.ToString();
                    gbComment.Enabled = true;
                    gbEmployee.Enabled = true;
                }
            } catch(MySqlException ex)
            {
                string message = "Nie udało się zapisać usługi związanej z pozycją zamówienia.";
                MessageBox.Show(message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
