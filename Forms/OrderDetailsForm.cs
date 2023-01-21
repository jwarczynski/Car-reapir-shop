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
    public partial class OrderDetailsForm : Form
    {
        protected string? orderId;
        protected string? originalCustomerId;

        protected bool isFinished = false;
        protected string? uneditedComment;

        public OrderDetailsForm(string? orderId, string? customerId = null)
        {
            this.orderId = orderId;
            this.originalCustomerId = customerId;

            InitializeComponent();
            Populate();
        }

        protected void Populate()
        {
            var customers = DatabaseService.Get().Select(DatabaseService.TABLE_CUSTOMERS,
                fields: new() { "customerId", "fullName" });

            cbCustomer.BeginUpdate();
            cbCustomer.Items.Clear();
            foreach (var customer in customers)
            {
                cbCustomer.Items.Add(new CustomerRow(customer[0]!, customer[1]!));
            }
            cbCustomer.EndUpdate();

            var cars = DatabaseService.Get().Select(DatabaseService.TABLE_CARS,
                fields: new() { "licensePlate" });

            cbCar.BeginUpdate();
            cbCar.Items.Clear();
            foreach (var car in cars)
            {
                cbCar.Items.Add(car[0]);
            }
            cbCar.EndUpdate();


            if (orderId == null)
            {
                cbCustomer.SelectedItem = new CustomerRow(originalCustomerId ?? "", "");
                lblAcceptDate.Text = DateTime.Now.ToShortDateString();

                gbComment.Enabled =
                    gbPositions.Enabled =
                    gbActions.Enabled = false;
                return;
            }

            var order = DatabaseService.Get().Select(DatabaseService.TABLE_ORDERS,
                new() { ["id"] = orderId },
                new() { "customerId", "carLicensePlate", "acceptDate", "finishDate", "comment" })[0];

            cbCustomer.SelectedItem = new CustomerRow(order[0]!, "");
            cbCar.SelectedItem = order[1];
            lblAcceptDate.Text = DateTime.Parse(order[2]!).ToShortDateString();
            if (!string.IsNullOrEmpty(order[3]))
            {
                lblFinishDate.Text = DateTime.Parse(order[3]!).ToShortDateString();
                lblStatus.Text = "zakończone";
                isFinished = true;
            } else {
                lblFinishDate.Text = "brak";
                lblStatus.Text = "w trakcie";
            }
            tbOrderComment.Text = uneditedComment = order[4];

            LoadOrderEntries();
        }

        protected void LoadOrderEntries()
        {
            var entries = DatabaseService.Get().Select(DatabaseService.TABLE_ORDER_ENTRIES_VIEW,
                new() { ["orderId"] = orderId },
                new() { "position", "serviceName", "date", "cost", "employeeName", "isDone" });

            decimal totalCost = 0;
            int donePositions = 0;

            lvOrderPositions.BeginUpdate();
            lvOrderPositions.Items.Clear();
            foreach (var entry in entries)
            {
                var fields = entry.ToArray()[1..5];
                if (!string.IsNullOrWhiteSpace(fields[1]))
                    fields[1] = DateTime.Parse(fields[1]!).ToShortDateString();

                var item = new ListViewItem(fields);
                item.Tag = entry.ToArray();
                lvOrderPositions.Items.Add(item);

                totalCost += decimal.Parse(entry[3] ?? "0");
                if (entry[5] != "0") donePositions++;
            }
            lvOrderPositions.EndUpdate();

            lblTotalCost.Text = totalCost.ToString() + " zł";
            lblPositionsFulfilled.Text = $"{donePositions} / {entries.Count}";

            if(!isFinished && donePositions == entries.Count && donePositions > 0)
            {
                btnFulfillOrder.Enabled = true;
            }
            if(donePositions == 0)
            {
                btnCancelOrder.Enabled = true;
            }
            UpdatePositionButtonsState();
        }

        private void btnSaveSubject_Click(object sender, EventArgs e)
        {
            if(cbCustomer.SelectedIndex == -1)
            {
                MessageBox.Show("Wybierz albo utwórz klienta", "Niekompletne dane", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if(cbCar.SelectedIndex == -1)
            {
                MessageBox.Show("Wybierz albo utwórz samochód", "Niekompletne dane", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var db = DatabaseService.Get();
            try
            {
                if(orderId != null)
                {
                    db.update(DatabaseService.TABLE_ORDERS,
                        new() { ["id"] = orderId },
                        new() { ["customerId"] = ((CustomerRow)cbCustomer.SelectedItem).CustomerId,
                            ["carLicensePlate"] = cbCar.SelectedItem.ToString() });
                    MessageBox.Show("Zaktualizowano", "Powodzenie");
                }
                else
                {
                    orderId = db.CallFunction(DatabaseService.FUNC_ADD_ORDER,
                        new()
                        {
                            ((CustomerRow)cbCustomer.SelectedItem).CustomerId,
                            cbCar.SelectedItem.ToString()!
                        })?.ToString();
                    gbComment.Enabled =
                        gbPositions.Enabled =
                        gbActions.Enabled = true;
                    lblStatus.Text = "w trakcie";
                    btnCancelOrder.Enabled = true;
                    UpdatePositionButtonsState();
                }
            }catch(MySqlException ex)
            {
                string message = "Nie udało się zapisać zamówienia do bazy danych.";
                MessageBox.Show(message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditComment_Click(object sender, EventArgs e)
        {
            if (tbOrderComment.ReadOnly)
            {
                tbOrderComment.ReadOnly = false;
                btnSaveComment.Enabled = true;
                btnEditComment.Text = "Anuluj";
            }
            else
            {
                tbOrderComment.Text = uneditedComment;
                tbOrderComment.ReadOnly = true;
                btnSaveComment.Enabled = false;
                btnEditComment.Text = "Edytuj";
            }
        }

        private void btnSaveComment_Click(object sender, EventArgs e)
        {
            try
            {
                string? comment = tbOrderComment.Text;
                if (string.IsNullOrWhiteSpace(comment)) comment = null;

                DatabaseService.Get().update(DatabaseService.TABLE_ORDERS,
                    new() { ["id"] = orderId },
                    new() { ["comment"] = comment });
                uneditedComment = comment;
                tbOrderComment.ReadOnly = true;
                btnSaveComment.Enabled = false;
                btnEditComment.Text = "Edytuj";
            }
            catch (MySqlException ex)
            {
                string message = "Nie udało się zapisać komentarza.";
                MessageBox.Show(message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvOrderPositions_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePositionButtonsState();
        }

        protected void UpdatePositionButtonsState()
        {
            bool isEntryDone = true;
            if (lvOrderPositions.SelectedItems.Count == 1)
            {
                var entry = (string?[])lvOrderPositions.SelectedItems[0].Tag;
                isEntryDone = (entry[5] != "0");
            }

            btnPositionDetails.Enabled = (lvOrderPositions.SelectedItems.Count == 1);
            btnAddPosition.Enabled = !isFinished;
            btnRemovePosition.Enabled = !isFinished && !isEntryDone;
        }

        private void btnRemovePosition_Click(object sender, EventArgs e)
        {
            if (lvOrderPositions.SelectedItems.Count != 1) return;
            var entryItem = lvOrderPositions.SelectedItems[0];
            var entryId = ((string?[])entryItem.Tag)[0];

            try
            {
                DatabaseService.Get().delete(DatabaseService.TABLE_ORDER_ENTRIES,
                    new() { ["orderId"] = orderId, ["position"] = entryId });
                LoadOrderEntries();
            }
            catch (MySqlException ex)
            {
                string message = "Nie udało się usunąć pozycji zamówienia";
                MessageBox.Show(message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class CustomerRow
        {
            public string CustomerId { get; private set; }
            public string CustomerName { get; private set; }

            public CustomerRow(string customerId, string fullName){
                this.CustomerId = customerId;
                this.CustomerName = fullName;
            }

            public override bool Equals(object? obj)
            {
                if(obj is CustomerRow)
                {
                    return this.CustomerId == ((CustomerRow)obj).CustomerId;
                }

                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return int.Parse(CustomerId);
            }

            public override string ToString()
            {
                return CustomerName;
            }
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Czy na pewno chcesz wycofać to zamówienie? Ta operacja jest nieodwracalna", "Wycofanie zamówienia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;
            
            try
            {
                DatabaseService.Get().delete(DatabaseService.TABLE_ORDERS,
                    new() { ["id"] = orderId });
                Close();
            }catch(MySqlException ex)
            {
                string message = "Nie udało się wycofać zamówienia." + ex.Message;
                MessageBox.Show(message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFulfillOrder_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Jeśli oznaczysz to zamówienie jako wykonane, nie będzie można go już zmienić. Kontynuować?", "Wykonanie zamówienia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            try
            {
                DatabaseService.Get().update(DatabaseService.TABLE_ORDERS,
                    new() { ["id"] = orderId },
                    new() { ["finishDate"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") });
                UpdatePositionButtonsState();
                btnFulfillOrder.Enabled = false;
            }
            catch (MySqlException ex)
            {
                string message = "Nie udało się oznaczyć zamówienia jako wykonane. " + ex.Message;
                MessageBox.Show(message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
