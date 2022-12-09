using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarsztatSamochodowy.Forms;

namespace WarsztatSamochodowy
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAllCars_Click(object sender, EventArgs e)
        {
            var carsListForm = new CarsListForm();
            carsListForm.Show();
        }

        private void btnCustomersList_Click(object sender, EventArgs e)
        {
            var customersListForm = new CustomersForm();
            customersListForm.Show();
        }

        private void btnShoppingLists_Click(object sender, EventArgs e)
        {
            var shoppingListsForm = new ShoppingListsForm();
            shoppingListsForm.Show();
        }
    }
}
