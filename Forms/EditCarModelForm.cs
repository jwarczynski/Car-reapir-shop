using MySqlConnector;
using E = MySqlConnector.MySqlErrorCode;

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
    public partial class EditCarModelForm : Form
    {
        protected string? manufacturerName;
        protected string? modelName;

        public EditCarModelForm(string? manufacturerName, string? modelName)
        {
            InitializeComponent();

            this.manufacturerName = manufacturerName;
            this.modelName = modelName;
        }

        private void EditCarModelForm_Load(object sender, EventArgs e)
        {
            var db = DatabaseService.Get();
            var manufacturers = db.Select(DatabaseService.TABLE_CAR_MANUFACTURERS,
                fields: new() { "manufacturerName" });

            foreach(var manufacturer in manufacturers)
            {
                cbManufacturer.Items.Add(manufacturer[0]);
            }
            cbManufacturer.SelectedIndex = cbManufacturer.Items.IndexOf(manufacturerName);
            tbModel.Text = modelName ?? "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(cbManufacturer.SelectedIndex == -1)
            {
                MessageBox.Show("Wybierz producenta dla tego modelu.", "Brakuje producenta",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if(string.IsNullOrWhiteSpace(tbModel.Text) )
            {
                MessageBox.Show("Nazwa modelu nie może być pusta.", "Brakuje nazwy modelu",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var db = DatabaseService.Get();
            try
            {
                if(manufacturerName != null && modelName != null)
                {
                    db.update(DatabaseService.TABLE_CAR_MODELS,
                        new() { ["manufacturerName"] = manufacturerName, ["modelName"] = modelName },
                        new() { ["manufacturerName"] = (string)cbManufacturer.SelectedItem, ["modelName"] = tbModel.Text });
                }
                else
                {
                    db.insert(DatabaseService.TABLE_CAR_MODELS,
                        new() { ["manufacturerName"] = (string)cbManufacturer.SelectedItem, ["modelName"] = tbModel.Text });
                }
                Close();
            } catch(MySqlException ex)
            {
                string message = ex.ErrorCode switch
                {
                    E.DuplicateKeyEntry => "Model o podanych właściwościach już istnieje.",
                    _ => $"{ex.Message} (kod błędu: {ex.ErrorCode})"
                };
                MessageBox.Show(message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
