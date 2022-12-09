namespace WarsztatSamochodowy.Forms
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

        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            var warehouseForm = new WarehouseForm();
            warehouseForm.Show();
        }
    }
}