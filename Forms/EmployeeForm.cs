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

namespace WarsztatSamochodowy.Forms
{

    
    public partial class EmployeeForm : Form
    {
        private MySqlConnection mySqlConnection;
        private string connectionString = "server=localhost;user=root;database=warsztat;port=3306;password=password";
        private MySqlCommand mySqlCommand;
        private MySqlDataAdapter sqlDataAdapter;
        private DataTable dataTable;
        public EmployeeForm()
        {
            InitializeComponent();
            setupConnection();
            showAll();
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
                mySqlConnection.Close();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
