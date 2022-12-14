using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarsztatSamochodowy.Models;
using WarsztatSamochodowy.Services;

namespace WarsztatSamochodowy.Forms
{

    
    public partial class EmployeeForm : Form
    {
        private static readonly string EMPLOYEE_TABLE = "EMPLOYEES";

        private string connectionString = "server=localhost;user=root;database=warsztat;port=3306;password=password";
        private MySqlConnection mySqlConnection;
        private MySqlCommand mySqlCommand;
        private MySqlDataAdapter sqlDataAdapter;
        private DataTable dataTable;
        private DatabaseService service;

        private SortedDictionary<string, string> selectedEmployee;
        private SortedDictionary<string, string> updatedEmployee;
        public EmployeeForm()
        {
            InitializeComponent();
            setupConnection();
            showAll();
            selectedEmployee = new SortedDictionary<string, string>();
            updatedEmployee = new SortedDictionary<string, string>();
            service = new DatabaseService();
        }

        private void setupConnection()
        {
            mySqlConnection = new MySqlConnection(connectionString);
        }
        private void showAll()
        {
            try
            {
                dataTable = new DataTable();
                mySqlConnection.Open();
                sqlDataAdapter = new MySqlDataAdapter("SELECT * FROM EMPLOYEES", mySqlConnection);
                sqlDataAdapter.Fill(dataTable);
                employeesDataGridView.DataSource = dataTable;
                employeesDataGridView.Columns[0].HeaderText = "Imie i Nazwisko";
                employeesDataGridView.Columns[1].HeaderText = "Płaca";
                employeesDataGridView.Columns[2].HeaderText = "Etat";
                mySqlConnection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Wystąpił błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        private void addEmployee2(Employee employee)
        {
            try
            {
                string commandString = "INSERT INTO EMPLOYEES(fullName, wage, roleName) VALUES('" + employee.fullName + "'," + employee.wage.ToString() + ",'" + employee.role + "')";
                MessageBox.Show(commandString);
                mySqlConnection.Open();
                mySqlCommand = new MySqlCommand(commandString);
                mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
            }
            catch (Exception)
            {

                throw;
            }
            clear();
            showAll();
        }

        private void addEmployee(Employee employee)
        {
            SortedDictionary<string, string> employeeMap = new SortedDictionary<string, string>();
            employeeMap.Add("fullName", employee.fullName);
            employeeMap.Add("wage", employee.wage.ToString());
            employeeMap.Add("roleName",  employee.role);

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
        private void roleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            roleListBox.Height = 40;
            //roleListBox.ClearSelected();
            //string? v = roleListBox.SelectedItem.ToString();
            //string selected = v;
            //MessageBox.Show(v);
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            SortedDictionary<string, string> employeeMap = new SortedDictionary<string, string>();

            Employee employee = new Employee(firstNameTextBox.Text + " " + lastNameTextBox.Text, float.Parse(wageTextBox.Text), roleListBox.SelectedItem.ToString());
            employeeMap.Add("fullName", employee.fullName);
            employeeMap.Add("wage", employee.wage.ToString());
            employeeMap.Add("roleName",  employee.role);


            addEmployee(employee);
            clear();
            showAll();
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

            updatedEmployee["fullName"] = fullName;
            updatedEmployee["wage"] = wageString;
            updatedEmployee["roleName"] = roleName;

            updateEmployee();
            clear();
            showAll();
        }
    }
}
