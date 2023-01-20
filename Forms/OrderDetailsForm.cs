using MySqlConnector;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            } else {
                lblFinishDate.Text = "brak";
                lblStatus.Text = "w trakcie";
            }
            tbOrderComment.Text = uneditedComment = order[4];
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
                    MessageBox.Show("Dodano zamówienie", "Powodzenie");
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
    }
}
