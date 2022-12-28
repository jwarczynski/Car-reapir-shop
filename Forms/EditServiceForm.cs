using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarsztatSamochodowy.Services;
using WarsztatSamochodowy.Utils;

namespace WarsztatSamochodowy.Forms
{
    public partial class EditServiceForm : Form
    {
        private const string PARTS_TABLE = "parts";
        private const string SERVICES_TABLE = "services";
        private const string SERVICE_PARTS_TABLE = "serviceParts";
        private const string SERVICES_PARTS_VIEW = "servicesPartsView";

        private readonly string? serviceNameToUpdate;
        
        public EditServiceForm()
        {
            InitializeComponent();
            PopulateAllPartsCheckBox();         
        }

        public EditServiceForm(string serviceNameToUpdate, string serviceCostToUpdate)
        {
            this.serviceNameToUpdate = serviceNameToUpdate;
            InitializeComponent();
            PopulateInputs(serviceCostToUpdate);
        }

        private void PopulateInputs(string serviceCost)
        {
            PopulateAllPartsCheckBox();         
            tbServiceName.Text = serviceNameToUpdate;
            tbStandardPrice.Text = serviceCost;

            SortedDictionary<string, string> whereClause = new SortedDictionary<string, string>();
            whereClause.Add("serviceName", serviceNameToUpdate!);
            List<List<string?>> parts = DatabaseService.Get().Select(SERVICES_PARTS_VIEW, whereClause);

            foreach(var part in parts)
            {
                int index = clbAllParts.Items.IndexOf($"{part.ElementAt(1)} (#{part.ElementAt(2)})");
                clbAllParts.SetItemChecked(index, true);
                lbPartCounter.Items[lbPartCounter.Items.Count - 1] = part.ElementAt(3)!;
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(e.CurrentValue == CheckState.Checked)
            {
                int index = lbSelectedParts.Items.IndexOf(clbAllParts.Items[e.Index].ToString()!);
                lbSelectedParts.Items.RemoveAt(index);
                lbPartCounter.Items.RemoveAt(index);
                clbAllParts.SelectedItems.Clear();
            } else
            {
                lbSelectedParts.Items.Add(clbAllParts.Items[e.Index].ToString()!);
                lbPartCounter.Items.Add(1);
                clbAllParts.SelectedItems.Clear();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if(lbPartCounter.SelectedItem != null)
            {
                lbPartCounter.Items[lbPartCounter.SelectedIndex] = numericUpDown1.Value;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void PopulateAllPartsCheckBox()
        {
            List<List<string?>> parts = DatabaseService.Get().Select(PARTS_TABLE);
            foreach(var part in parts)
            {
                clbAllParts.Items.Add($"{part.ElementAt(1)} (#{part.ElementAt(0)})");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SortedDictionary<string, string> newServiceMap= new SortedDictionary<string, string>();
            string? serviceName = tbServiceName.Text;
            string? serviceCost = tbStandardPrice.Text;

            try
            {
                validateNewService(serviceName, serviceCost);
                newServiceMap.Add("name", serviceName);
                newServiceMap.Add("standardCost", serviceCost);

                if(serviceNameToUpdate == null)
                {
                    insertNewService(serviceName, newServiceMap);
                } else
                {
                    updateService(serviceName, newServiceMap);
                }

                clearInputs();
                MessageBox.Show("Usługa została zapisana");

            } catch(ArgumentException ae)
            {
                MessageBox.Show(ae.Message);
            }
        }

        private void insertNewService(string serviceName, SortedDictionary<string, string> newServiceMap)
        {
            DatabaseService.Get().insert(SERVICES_TABLE, newServiceMap);

            //insert into serviceParts
            foreach(var tuple in GetServicePartsTuples(serviceName))
            {
                DatabaseService.Get().insert(SERVICE_PARTS_TABLE, tuple);
            }
        }

        private void updateService(string serviceName, SortedDictionary<string, string> updatedServiceMap)
        {
            SortedDictionary<string, string> updatedServiceConditions = new SortedDictionary<string, string>();
            updatedServiceConditions.Add("name", serviceNameToUpdate!);
            DatabaseService.Get().update(SERVICES_TABLE, updatedServiceConditions, updatedServiceMap);

            SortedDictionary<string, string> servicePartsToDeleteClause = new SortedDictionary<string, string>();
            servicePartsToDeleteClause.Add("serviceName", serviceName);

            DatabaseService.Get().delete(SERVICE_PARTS_TABLE, servicePartsToDeleteClause);
            foreach(var tuple in GetServicePartsTuples(serviceName))
            {
                DatabaseService.Get().insert(SERVICE_PARTS_TABLE, tuple);
            }
        }

        private List<SortedDictionary<string, string>> GetServicePartsTuples(string serviceName)
        {
            List<SortedDictionary<string, string>> servicePartsTuples = new List<SortedDictionary<string, string>>();
            for(int i = 0; i < lbSelectedParts.Items.Count; ++i)
            {
                SortedDictionary<string, string> partMap = new SortedDictionary<string, string>();

                string part = lbSelectedParts.Items[i].ToString()!;
                string partName = CommandStringBuildingHelper.GetUntilOrEmpty(part, " (#");
                string partCode = CommandStringBuildingHelper.GetAfterCharUntilChar(part, "#", ")");
                string quantity = lbPartCounter.Items[i].ToString()!;

                partMap.Add("serviceName", serviceName);
                partMap.Add("partPartCode", partCode);
                partMap.Add("quantity", quantity);
                servicePartsTuples.Add(partMap);

            }
            return servicePartsTuples;

        }

        public void UncheckAllItems()
        {
            while (clbAllParts.CheckedIndices.Count > 0)
                clbAllParts.SetItemChecked(clbAllParts.CheckedIndices[0], false);
        }

        private void clearInputs()
        {
            tbServiceName.Text = "";
            tbStandardPrice.Text = "";
            UncheckAllItems();
            lbSelectedParts.Items.Clear();
            lbPartCounter.Items.Clear();
            numericUpDown1.Value = 1;
            tbServiceName.Focus();
        }

        private void validateNewService(string? serivceName, string? serviceCost)
        {
            ValidationService.ValidateName(serivceName);
            ValidationService.ValidateFloat(serviceCost);
        }
    }
}
