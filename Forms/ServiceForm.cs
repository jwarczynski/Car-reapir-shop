using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarsztatSamochodowy.Services;

namespace WarsztatSamochodowy.Forms
{
    public partial class ServiceForm : Form
    {
        private static readonly string SERVICE_TABLE = "services";
        
        private DatabaseService service;

        private SortedDictionary<string, string> selectedService;
        private SortedDictionary<string, string> updatedService;


        public ServiceForm()
        {
            InitializeComponent();
            selectedService = new SortedDictionary<string, string>();
            updatedService = new SortedDictionary<string, string>();
            service = new DatabaseService();
            showAll();
        }
        private void showAll()
        {
            List<string> attributesNames = new List<string> { "Nazwa", "Cena" };
            serviceDataGridView.DataSource = DatabaseService.Get().selectAllToTable(SERVICE_TABLE, attributesNames);
            //serviceDataGridView.Columns[0].HeaderText = "Nazwa";
            //serviceDataGridView.Columns[1].HeaderText = "Cena";
            serviceDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            serviceDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void RefreshTable()
        {
            serviceDataGridView.DataSource = null;
            showAll();
        }
        private void addservice(SortedDictionary<string, string> Newservice)
        {
            SortedDictionary<string, string> serviceMap = new SortedDictionary<string, string>();
            serviceMap.Add("fullName", Newservice["fullName"]);
            serviceMap.Add("wage", Newservice["age"].ToString());
            serviceMap.Add("roleName", Newservice["role"]);

            service.insert("service", serviceMap);
        }

        private void deleteservice()
        {
            service.delete(SERVICE_TABLE, selectedService);
        }

        private void updateservice()
        {
            service.update(SERVICE_TABLE, selectedService, updatedService);
        }

        private void clear()
        {
            //firstNameTextBox.Text = "";
            //lastNameTextBox.Text = "";
        }

        //TODO delete or make sth worthy

        private void validateservice(string firstName, string lastName, string wage)
        {
            validateName(firstName);
            validateName(lastName);
            validateWage(wage);
        }

        private void validateservice(SortedDictionary<string, string> service)
        {
            validateName(service["firstName"]);
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

        private void btnAddService_Click(object sender, EventArgs e)
        {
            EditServiceForm editServiceForm = new EditServiceForm();
            editServiceForm.Show();
        }

        private void btnEditSerivce_Click(object sender, EventArgs e)
        {
            string? serviceNameToEdit = serviceDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            string? serviceCostToEdit = serviceDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            if(serviceNameToEdit != null)
            {
                SortedDictionary<string, string> selectedService = new SortedDictionary<string, string>();
                selectedService.Add("name", serviceNameToEdit);
                EditServiceForm editServiceForm = new EditServiceForm(serviceNameToEdit, serviceCostToEdit);
                editServiceForm.ShowDialog();
                RefreshTable();
            } 
        }

        private void btnRemoveService_Click(object sender, EventArgs e)
        {
            string? serviceNameToDelete = serviceDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            if(serviceNameToDelete != null)
            {
                SortedDictionary<string, string> selectedService = new SortedDictionary<string, string>();
                selectedService.Add("name", serviceNameToDelete);
                DatabaseService.Get().delete(SERVICE_TABLE, selectedService);
                RefreshTable();
            }
        }
    }
}
