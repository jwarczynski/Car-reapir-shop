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

using WarsztatSamochodowy.Services;

namespace WarsztatSamochodowy.Forms
{
    public partial class CarModelsForm : Form
    {
        public CarModelsForm()
        {
            InitializeComponent();
        }

        private void btnShowManufacturers_Click(object sender, EventArgs e)
        {
            var carManufacturersForm = new CarManufacturersForm();
            carManufacturersForm.ShowDialog();
            ReloadModels();
        }

        private void CarModelsForm_Load(object sender, EventArgs e)
        {
            ReloadModels();
        }

        protected void ReloadModels()
        {
            var models = DatabaseService.Get().Select(DatabaseService.TABLE_CAR_MODELS,
                fields: new() { "manufacturerName", "modelName" });

            lvModels.BeginUpdate();
            lvModels.Items.Clear();
            foreach (var model in models)
            {
                var item = new ListViewItem($"{model[0]} {model[1]}");
                item.Tag = (model[0]!, model[1]!);
                lvModels.Items.Add(item);
            }
            lvModels.Sort();
            lvModels.EndUpdate();
        }

        private void lvModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = 
                btnRemove.Enabled = (lvModels.SelectedItems.Count == 1);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var editCarModelForm = new EditCarModelForm(null, null);
            editCarModelForm.ShowDialog();
            ReloadModels();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditSelectedItem();
        }

        private void lvModels_ItemActivate(object sender, EventArgs e)
        {
            EditSelectedItem();
        }

        protected void EditSelectedItem()
        {
            if(lvModels.SelectedItems.Count != 1)
            {
                MessageBox.Show("Wybierz model, który chcesz edytować.", "Nic nie wybrano",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var selectedItem = lvModels.SelectedItems[0];
            var (manufacturer, model) = ((string, string))selectedItem.Tag;

            var editCarModelForm = new EditCarModelForm(manufacturer, model);
            editCarModelForm.ShowDialog();
            ReloadModels();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lvModels.SelectedItems.Count != 1)
            {
                MessageBox.Show("Wybierz model, który chcesz edytować.", "Nic nie wybrano",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var selectedItem = lvModels.SelectedItems[0];
            var (manufacturer, model) = ((string, string))selectedItem.Tag;

            try
            {
                DatabaseService.Get().delete(DatabaseService.TABLE_CAR_MODELS,
                    new() { ["manufacturerName"] = manufacturer, ["modelName"] = model });
                selectedItem.Remove();
            } catch(MySqlException ex)
            {
                string message = ex.ErrorCode switch
                {
                    _ => $"{ex.Message} (kod błędu: {ex.ErrorCode})"
                };
                MessageBox.Show(message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
