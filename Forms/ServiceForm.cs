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
            serviceDataGridView.DataSource = service.selectAllToTable(SERVICE_TABLE);
            serviceDataGridView.Columns[0].HeaderText = "Nazwa";
            serviceDataGridView.Columns[1].HeaderText = "Cena";
            serviceDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            serviceDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        private void addservice(SortedDictionary<string, string> Newservice)
        {
            SortedDictionary<string, string> serviceMap = new SortedDictionary<string, string>();
            serviceMap.Add("fullName", service["fullName"]);
            serviceMap.Add("wage", service["age"].ToString());
            serviceMap.Add("roleName", service["role"]);

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
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
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
    }
}
