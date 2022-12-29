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

        private SortedDictionary<string, string> selectedService;
        private SortedDictionary<string, string> updatedService;


        public ServiceForm()
        {
            InitializeComponent();
            selectedService = new SortedDictionary<string, string>();
            updatedService = new SortedDictionary<string, string>();
            showAll();
        }
        private void showAll()
        {
            List<string> attributesNames = new List<string> { "Nazwa", "Cena" };
            serviceDataGridView.DataSource = DatabaseService.Get().selectAllToTable(SERVICE_TABLE, attributesNames);
            serviceDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            serviceDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void RefreshTable()
        {
            serviceDataGridView.DataSource = null;
            showAll();
        }
        
        private void btnAddService_Click(object sender, EventArgs e)
        {
            EditServiceForm editServiceForm = new EditServiceForm();
            editServiceForm.ShowDialog();
            RefreshTable();
        }

        private void btnEditSerivce_Click(object sender, EventArgs e)
        {
            string? serviceNameToEdit = serviceDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            string? serviceCostToEdit = serviceDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            if(serviceNameToEdit != null)
            {
                SortedDictionary<string, string> selectedService = new SortedDictionary<string, string>();
                selectedService.Add("name", serviceNameToEdit);
                EditServiceForm editServiceForm = new EditServiceForm(serviceNameToEdit, serviceCostToEdit!);
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
