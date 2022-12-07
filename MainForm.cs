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
    }
}