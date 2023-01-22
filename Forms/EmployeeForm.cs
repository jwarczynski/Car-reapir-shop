using MySqlConnector;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using WarsztatSamochodowy.Services;

namespace WarsztatSamochodowy.Forms
{
    public partial class EmployeeForm : Form
    {
        private static readonly string EMPLOYEE_TABLE = "EMPLOYEES";
        private static readonly string EMPLOYEE_ROLE_TABLE = "EmployeeRoles";

        private static readonly string DUPLICATED_EMPLOYEE_MESSAGE = "Taki praconwik już jest zatrudniony";

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
            roleListBox.Items.Clear();
            List<List<string?>> employeeRoles = DatabaseService.Get().Select(EMPLOYEE_ROLE_TABLE);
            foreach(var employeeRole in employeeRoles)
            {
                roleListBox.Items.Add(employeeRole.ElementAt(0));
            }
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
            DatabaseService.Get().delete(EMPLOYEE_TABLE, new() { ["fullName"] = selectedEmployee["fullName"] });
        }

        private void updateEmployee()
        {
            DatabaseService.Get().update(EMPLOYEE_TABLE, new() { ["fullName"] = selectedEmployee["fullName"] }, updatedEmployee);
        }

        private void clear()
        {
            roleListBox.SelectedIndex = -1;
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            wageTextBox.Text = "";
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
                employeeMap.Add("wage", decimal.Parse(wageTextBox.Text).ToString(CultureInfo.InvariantCulture));
                employeeMap.Add("role", roleListBox.SelectedItem.ToString());

                try
                {
                    addEmployee(employeeMap);
                } catch(MySqlException sqlException)
                {
                    DatabaseService.HandleSqlException(sqlException, DUPLICATED_EMPLOYEE_MESSAGE);
                    return;
                }
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
            var result = MessageBox.Show("Usunięcie pracownika spowoduje, że skasowane zostaną informacje o wykonanych przez niego usługach. Kontynuować?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            try
            {
                deleteEmployee();
            } catch(MySqlException sqlException)
            {
                DatabaseService.HandleSqlException(sqlException, DUPLICATED_EMPLOYEE_MESSAGE);
                return;
            }
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
                if (string.IsNullOrWhiteSpace(fullName))
                {
                    throw new ArgumentException("Należy podać imię i nazwisko pracownika");
                }
                if (!decimal.TryParse(wageString, out _))
                {
                    throw new ArgumentException("Podano niepoprawną wartość płacy");
                }

                string? roleName = roleListBox.SelectedItem.ToString();
                updatedEmployee["fullName"] = fullName;
                updatedEmployee["wage"] = decimal.Parse(wageString).ToString(CultureInfo.InvariantCulture);
                updatedEmployee["roleName"] = roleName;

                validateEmployee(firstName, lastName, wageString);

                try
                {
                    updateEmployee();
                } catch(MySqlException sqlException)
                {
                    DatabaseService.HandleSqlException(sqlException, DUPLICATED_EMPLOYEE_MESSAGE);
                    return;
                }
                clear();
                showAll();
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeRoleForm employeeRoleForm = new EmployeeRoleForm();
            employeeRoleForm.Show();
        }
    }
}
