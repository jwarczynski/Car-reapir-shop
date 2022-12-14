using MySqlConnector;
using System.Data;
using System.Text.RegularExpressions;
using WarsztatSamochodowy.Services;

namespace WarsztatSamochodowy.Forms
{
    public partial class EmployeeForm : Form
    {
        private static readonly string EMPLOYEE_TABLE = "EMPLOYEES";

        //private string connectionString = "server=localhost;user=root;database=warsztat;port=3306;password=password";
        //private MySqlConnection mySqlConnection;
        //private MySqlCommand mySqlCommand;
        //private MySqlDataAdapter sqlDataAdapter;
        //private DataTable dataTable;
        private DatabaseService service;

        private SortedDictionary<string, string> selectedEmployee;
        private SortedDictionary<string, string> updatedEmployee;

        public EmployeeForm()
        {
            InitializeComponent();
            setupConnection();
            selectedEmployee = new SortedDictionary<string, string>();
            updatedEmployee = new SortedDictionary<string, string>();
            service = new DatabaseService();
            showAll();
        }

        private void setupConnection()
        {
            //mySqlConnection = new MySqlConnection(connectionString);
        }

        private void showAll()
        {
            try
            {
                //dataTable = new DataTable();
                //mySqlConnection.Open();
                //sqlDataAdapter = new MySqlDataAdapter("SELECT * FROM EMPLOYEES", mySqlConnection);
                //sqlDataAdapter.Fill(dataTable);
                employeesDataGridView.DataSource = service.selectAllToTable(EMPLOYEE_TABLE);
                //employeesDataGridView.DataSource = dataTable;
                //List<SortedDictionary<string,string>> l = new List<SortedDictionary<string,string>>();
                //SortedDictionary<string, string> d = new SortedDictionary<string, string>();
                //l.Add(d);
                //d.Add("name", "Adam");
                //d.Add("LastName", "Padam");
                //d.Add("placa", "5");
                //dataTable.Load(l);
                //employeesDataGridView.DataSource = dataTable;
                employeesDataGridView.Columns[0].HeaderText = "Imie i Nazwisko";
                employeesDataGridView.Columns[1].HeaderText = "Płaca";
                employeesDataGridView.Columns[2].HeaderText = "Etat";
                employeesDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                employeesDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                employeesDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //mySqlConnection.Close();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void addEmployee(SortedDictionary<string, string> employee)
        {
            SortedDictionary<string, string> employeeMap = new SortedDictionary<string, string>();
            employeeMap.Add("fullName", employee["fullName"]);
            employeeMap.Add("wage", employee["age"].ToString());
            employeeMap.Add("roleName", employee["role"]);

            service.insert("Employees", employeeMap);
        }

        private void deleteEmployee()
        {
            service.delete(EMPLOYEE_TABLE, selectedEmployee);
        }

        private void updateEmployee()
        {
            service.update(EMPLOYEE_TABLE, selectedEmployee, updatedEmployee);
        }

        private void clear()
        {
            roleListBox.ClearSelected();
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            wageTextBox.Text = "";
        }

        //TODO delete or make sth worthy
        private void roleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            roleListBox.Height = 40;
            //roleListBox.ClearSelected();
            //string? v = roleListBox.SelectedItem.ToString();
            //string selected = v;
            //MessageBox.Show(v);
        }

        private void validateEmployee(string firstName, string lastName, string wage)
        {
            validateName(firstName);
            validateName(lastName);
            validateWage(wage);
        }

        private void validateEmployee(SortedDictionary<string, string> employee)
        {
            validateName(employee["firstName"]);
            validateName("lastName");
            validateWage("age");
        }

        private void validateWage(string wage)
        {
            try
            {
                float.Parse(wage);
            }
            catch (FormatException)
            {
                throw new ArgumentException("Podano niepoprawną wartość płacy");
            }
        }

        private bool validateName(string name)
        {
            string validNameRegex = @"^[A-ZŻŹĆĄŚĘŁÓŃ][a-zżźćńółęąś]{1,19}$";
            Regex nameRegex = new Regex(validNameRegex);
            if (nameRegex.IsMatch(name))
            {
                return true;
            }

            throw new ArgumentException("Imię oraz nazwisko powinny zaczynać się wileką literą i posiadać maksymalnie 20 znaków");
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            SortedDictionary<string, string> employeeMap = new SortedDictionary<string, string>();

            try
            {
                validateEmployee(firstNameTextBox.Text, lastNameTextBox.Text, wageTextBox.Text);

                //Employee employee = new Employee(firstNameTextBox.Text + " " + lastNameTextBox.Text, float.Parse(wageTextBox.Text), roleListBox.SelectedItem.ToString());
                employeeMap.Add("fullName", firstNameTextBox.Text + " " + lastNameTextBox.Text);
                employeeMap.Add("wage", float.Parse(wageTextBox.Text).ToString());
                employeeMap.Add("roleName", float.Parse(wageTextBox.Text).ToString());

                addEmployee(employeeMap);
                clear();
                showAll();
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message);
            }
        }

        private void employeesDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SortedDictionary<string, string> employeeMap = new SortedDictionary<string, string>();

            string fullName = employeesDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            string firstName = fullName.Split(" ")[0];
            string lastName = fullName.Split(' ')[1];

            firstNameTextBox.Text = firstName;
            lastNameTextBox.Text = lastName;

            string wageString = employeesDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            wageTextBox.Text = wageString;

            string selectedItemString = employeesDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            roleListBox.SelectedItem = selectedItemString;

            selectedEmployee["fullName"] = fullName;
            selectedEmployee["wage"] = wageString;
            selectedEmployee["roleName"] = selectedItemString;
        }

        private void btnRemoveCustomer_Click(object sender, EventArgs e)
        {
            deleteEmployee();
            showAll();
            clear();
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            string fullName = firstNameTextBox.Text + " " + lastNameTextBox.Text;
            string wageString = wageTextBox.Text;
            string roleName = roleListBox.SelectedItem.ToString();

            try
            {
                updatedEmployee["fullName"] = fullName;
                updatedEmployee["wage"] = wageString;
                updatedEmployee["roleName"] = roleName;

                validateEmployee(updatedEmployee);

                updateEmployee();
                clear();
                showAll();
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message);
            }

        }
    }
}
