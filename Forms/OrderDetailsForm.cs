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
            tbOrderComment.Text = order[4];
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
