using MySqlConnector;
using E = MySqlConnector.MySqlErrorCode;

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

        protected bool isFinished = false;

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
            PopulateEmployees();

            if(entryId == null)
            {
                gbEmployee.Enabled = false;
                gbComment.Enabled = false;
                return;
            }

            var entry = DatabaseService.Get().Select(DatabaseService.TABLE_ORDER_ENTRIES,
                new() { ["orderId"] = orderId, ["position"] = entryId },
                new() { "serviceName", "actualCost", "employeeName", "date", "comment" })[0];

            isFinished = !string.IsNullOrWhiteSpace(entry[3]);

            cbService.SelectedItem = entry[0];
            tbCost.Text = !string.IsNullOrWhiteSpace(entry[1]) ? entry[1] : serviceCosts[entry[0]!].ToString();
            ckIndividualPrice.Checked = !string.IsNullOrWhiteSpace(entry[1]);

            cbEmployee.SelectedItem = entry[2];
            
            lblDate.Text = isFinished ? DateTime.Parse(entry[3]!).ToShortDateString() : "nie wykonano";

            tbComment.Text = entry[4];
            
            UpdateButtonsStates();
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

        protected void PopulateEmployees()
        {
            var employees = DatabaseService.Get().Select(DatabaseService.TABLE_EMPLOYEES,
                fields: new() { "fullName" });

            cbEmployee.BeginUpdate();
            cbEmployee.Items.Clear();
            foreach (var employee in employees)
            {
                cbEmployee.Items.Add(employee[0]);
            }
            cbEmployee.EndUpdate();
        }

        protected void UpdateButtonsStates()
        {
            gbService.Enabled = !isFinished;
            cbEmployee.Enabled = !isFinished;
            btnSaveEmployee.Enabled = !isFinished && cbEmployee.SelectedIndex >= 0;
            btnMarkDone.Enabled = !isFinished && cbEmployee.SelectedIndex >= 0;
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

        private void btnSaveEmployee_Click(object sender, EventArgs e)
        {
            if (cbEmployee.SelectedIndex < 0) return;
            string employeeName = cbEmployee.SelectedItem.ToString()!;

            try
            {
                DatabaseService.Get().update(DatabaseService.TABLE_ORDER_ENTRIES,
                    new() { ["orderId"] = orderId, ["position"] = entryId },
                    new() { ["employeeName"] = employeeName });

                btnMarkDone.Enabled = true;
            }catch(MySqlException ex)
            {
                string message = "Nie udało się zapisać pracownika.";
                MessageBox.Show(message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSaveEmployee.Enabled = cbEmployee.SelectedIndex >= 0;
        }

        private void btnMarkDone_Click(object sender, EventArgs e)
        {
            if (cbEmployee.SelectedIndex < 0) return;

            var result = MessageBox.Show("Po oznaczeniu pozycji jako wykonanej, nie będzie można jej już zmodyfikować. Kontynuować?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result != DialogResult.Yes) return;

            try
            {
                DatabaseService.Get().update(DatabaseService.TABLE_ORDER_ENTRIES,
                    new() { ["orderId"] = orderId, ["position"] = entryId },
                    new() { ["isDone"] = "1", ["date"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") });

                isFinished = true;
                lblDate.Text = DateTime.Now.ToShortDateString();
                UpdateButtonsStates();
            }
            catch (MySqlException ex)
            {
                string message = ex.ErrorCode switch {
                    (E)1644 => "W magazynie brakuje niektórych części potrzebnych do wykonania pozycji.",
                    _ => "Nie udało się oznaczyć pozycji jako wykonanej."
                };
                MessageBox.Show(message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveComment_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseService.Get().update(DatabaseService.TABLE_ORDER_ENTRIES,
                    new() { ["orderId"] = orderId, ["position"] = entryId },
                    new() { ["comment"] = tbComment.Text });
            }
            catch (MySqlException ex)
            {
                string message = "Nie udało się zapisać komentarza.";
                MessageBox.Show(message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
