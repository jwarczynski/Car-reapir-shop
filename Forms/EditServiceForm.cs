using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        private const string SERVICES_TO_CAR_MODELS = "servicesToCarModels";
        private const string CAR_MODELS_TABLE = "carModels";


        private readonly string? serviceNameToUpdate;
        
        public EditServiceForm()
        {
            InitializeComponent();
            PopulateAllPartsCheckBox();         
            PopulateAllModelsCheckBox();         
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
            PopulateAllModelsCheckBox();         

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

            List<List<string?>> servicesToParts = DatabaseService.Get().Select(SERVICES_TO_CAR_MODELS, whereClause);
            foreach(var serviceToPart in servicesToParts)
            {
                int index = chckListBoxAllModels.Items.IndexOf($"{serviceToPart.ElementAt(0)} ({serviceToPart.ElementAt(1)})");
                chckListBoxAllModels.SetItemChecked(index, true);
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
        private void PopulateAllModelsCheckBox()
        {
            List<List<string?>> models = DatabaseService.Get().Select(CAR_MODELS_TABLE);
            foreach(var model in models)
            {
                chckListBoxAllModels.Items.Add($"{model.ElementAt(0)} ({model.ElementAt(1)})");
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
                newServiceMap.Add("standardCost", float.Parse(serviceCost).ToString(CultureInfo.InvariantCulture));

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

            foreach(var tuple in GetModelsTuples())
            {
                tuple.Add("serviceName", serviceName);
                DatabaseService.Get().insert(SERVICES_TO_CAR_MODELS, tuple);
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
            DatabaseService.Get().delete(SERVICES_TO_CAR_MODELS, servicePartsToDeleteClause);
            foreach(var tuple in GetServicePartsTuples(serviceName))
            {
                DatabaseService.Get().insert(SERVICE_PARTS_TABLE, tuple);
            }

            foreach(var tuple in GetModelsTuples())
            {
                tuple.Add("serviceName", serviceName);
                DatabaseService.Get().insert(SERVICES_TO_CAR_MODELS, tuple);
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

        private List<SortedDictionary<string, string>> GetModelsTuples()
        {
            List<SortedDictionary<string, string>> modelsTuples = new List<SortedDictionary<string, string>>();
            for(int i = 0; i < listBoxSelectedModels.Items.Count; ++i)
            {
                SortedDictionary<string, string> modelManufacturerPair = new SortedDictionary<string, string>();

                string car = listBoxSelectedModels.Items[i].ToString()!;
                string modelName = CommandStringBuildingHelper.GetUntilOrEmpty(car, " (");
                string manufacturer = CommandStringBuildingHelper.GetAfterCharUntilChar(car, "(", ")");

                modelManufacturerPair.Add("modelName", modelName);
                modelManufacturerPair.Add("manufacturerName", manufacturer);
                modelsTuples.Add(modelManufacturerPair);

            }
            return modelsTuples;

        }

        public void UncheckAllItems()
        {
            while (clbAllParts.CheckedIndices.Count > 0)
                clbAllParts.SetItemChecked(clbAllParts.CheckedIndices[0], false);

            //while (chckListBoxAllModels.CheckedIndices.Count > 0)
                //chckListBoxAllModels.SetItemChecked(chckListBoxAllModels.CheckedIndices[0], false);
            for(int i = 0; i < chckListBoxAllModels.Items.Count; ++i)
            {
                chckListBoxAllModels.SetItemChecked(i, false);

            }
        }

        private void clearInputs()
        {
            tbServiceName.Text = "";
            tbStandardPrice.Text = "";
            UncheckAllItems();
            lbSelectedParts.Items.Clear();
            lbPartCounter.Items.Clear();
            listBoxSelectedModels.Items.Clear();
            numericUpDown1.Value = 1;
            tbServiceName.Focus();
        }

        private void validateNewService(string? serivceName, string? serviceCost)
        {
            ValidationService.ValidateName(serivceName);
            ValidationService.ValidateFloat(serviceCost);
        }

        private void checkedListBoxAllModels_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(e.CurrentValue == CheckState.Checked)
            {
                int index = listBoxSelectedModels.Items.IndexOf(chckListBoxAllModels.Items[e.Index].ToString()!);
                listBoxSelectedModels.Items.RemoveAt(index);
                chckListBoxAllModels.SelectedItems.Clear();
            } else
            {
                listBoxSelectedModels.Items.Add(chckListBoxAllModels.Items[e.Index].ToString()!);
                chckListBoxAllModels.SelectedItems.Clear();
            }
        }
        
    }
}
