using MySqlConnector;
using System.Data;
using System.Text.RegularExpressions;
using WarsztatSamochodowy.Services;

namespace WarsztatSamochodowy.Forms
{
    public partial class EmployeeForm : Form
    {
        private static readonly string EMPLOYEE_TABLE = "EMPLOYEES";

        private SortedDictionary<string, string> selectedEmployee;
        private SortedDictionary<string, string> updatedEmployee;

        public EmployeeForm()
        {
            InitializeComponent();
            selectedEmployee = new SortedDictionary<string, string>();
            updatedEmployee = new SortedDictionary<string, string>();
            showAll();
        }


        private void showAll()
        {
            List<string> attributesNames = new List<string> { "Imie i Nazwisko", "Płaca", "Etat" };
            try
            {
                DataTable dataTable = DatabaseService.Get().selectAllToTable(EMPLOYEE_TABLE, attributesNames);
                employeesDataGridView.DataSource = dataTable;
                employeesDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                employeesDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                employeesDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            } catch (Exception e)
            {
                MessageBox.Show(e.Message, "Wystąpił błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void addEmployee(SortedDictionary<string, string> employee)
        {
            SortedDictionary<string, string> employeeMap = new SortedDictionary<string, string>();
            employeeMap.Add("fullName", employee["fullName"]);
            employeeMap.Add("wage", employee["wage"].ToString());
            employeeMap.Add("roleName", employee["role"]);

            DatabaseService.Get().insert("Employees", employeeMap);
        }

        private void deleteEmployee()
        {
            DatabaseService.Get().delete(EMPLOYEE_TABLE, selectedEmployee);
        }

        private void updateEmployee()
        {
            DatabaseService.Get().update(EMPLOYEE_TABLE, selectedEmployee, updatedEmployee);
        }

        private void clear()
        {
            roleListBox.ClearSelected();
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            wageTextBox.Text = "";
        }

        private void roleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            roleListBox.Height = 40;
        }

        private void validateEmployee(string firstName, string lastName, string wage)
        {
            validateName(firstName);
            validateName(lastName);
            validateWage(wage);
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
                if (roleListBox.SelectedItem == null)
                {
                    throw new ArgumentException("Należy wybrać etat");
                }

                employeeMap.Add("fullName", firstNameTextBox.Text + " " + lastNameTextBox.Text);
                employeeMap.Add("wage", float.Parse(wageTextBox.Text).ToString());
                employeeMap.Add("role", roleListBox.SelectedItem.ToString());

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

            string? fullName = employeesDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            string? firstName = fullName?.Split(" ")[0];
            string? lastName = fullName?.Split(' ')[1];

            firstNameTextBox.Text = firstName;
            lastNameTextBox.Text = lastName;

            string? wageString = employeesDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            wageTextBox.Text = wageString;

            string? selectedItemString = employeesDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            roleListBox.SelectedItem = selectedItemString;

            selectedEmployee["fullName"] = fullName ?? "";
            selectedEmployee["wage"] = wageString?? "";
            selectedEmployee["roleName"] = selectedItemString?? "";
        }

        private void btnRemoveCustomer_Click(object sender, EventArgs e)
        {
            deleteEmployee();
            showAll();
            clear();
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            string fullName = firstName + " " + lastName;
            string wageString = wageTextBox.Text;

            try
            {
                if(roleListBox.SelectedItem == null)
                {
                    throw new ArgumentException("Należy wybrać etat");
                }

                string? roleName = roleListBox.SelectedItem.ToString();
                updatedEmployee["fullName"] = fullName;
                updatedEmployee["wage"] = wageString;
                updatedEmployee["roleName"] = roleName;

                validateEmployee(firstName, lastName, wageString);

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
