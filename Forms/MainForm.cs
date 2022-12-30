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
            var customersForm = new CustomersForm();
            customersForm.Show();
        }

        private void btnShoppingLists_Click(object sender, EventArgs e)
        {
            var shoppingListsForm = new ShoppingListsForm();
            shoppingListsForm.Show();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            var employeeForm = new EmployeeForm();
            employeeForm.Show();
        }

        private void btn_service_Click(object sender, EventArgs e)
        {
            var ServiceForm = new ServiceForm();
            ServiceForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var warehouseForm = new WarehouseForm();
            warehouseForm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var manufacturersForm = new CarManufacturersForm();
            manufacturersForm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var modelsForm = new CarModelsForm();
            modelsForm.Show();
        }
    }
}
