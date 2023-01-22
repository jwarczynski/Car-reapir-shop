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
    public partial class EditCarForm : Form
    {
        protected string? licensePlate;
        protected string? manufacturerName;
        protected string? modelName;

        public EditCarForm(string? licensePlate, string? modelName, string? manufacturerName)
        {
            InitializeComponent();
            this.licensePlate = licensePlate;
            this.manufacturerName = manufacturerName;
            this.modelName = modelName;
        }
        private void EditCarForm_Load(object sender, EventArgs e)
        {
            var db = DatabaseService.Get();
            var manufacturers = db.Select(DatabaseService.TABLE_CAR_MANUFACTURERS,
                fields: new() { "manufacturerName" });

            foreach(var manufacturer in manufacturers)
            {
                cbManufacturer.Items.Add(manufacturer[0]);
            }

            var models = db.Select(DatabaseService.TABLE_CAR_MODELS,
                fields: new() { "modelName" });

            foreach(var model in models)
            {
                cbModel.Items.Add(model[0]);
            }

            cbManufacturer.SelectedIndex = cbManufacturer.Items.IndexOf(manufacturerName);
            cbModel.SelectedIndex = cbModel.Items.IndexOf(modelName);
            tbLicencePlate.Text = licensePlate ?? "";
        }

        private bool isRequiredDataFilled()
        {
            if(cbManufacturer.SelectedIndex == -1)
            {
                MessageBox.Show("Wybierz producenta dla tego sampchodu.", "Brakuje producenta",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if(cbModel.SelectedIndex == -1)
            {
                MessageBox.Show("Wybierz model dla tego samochodu.", "Brakuje modelu",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if(string.IsNullOrWhiteSpace(tbLicencePlate.Text) )
            {
                MessageBox.Show("Numer rejestracyjny nie może być pusty.", "Brakuje numeru rehestracyjnego",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!isRequiredDataFilled())
            {
                return;
            }
            var db = DatabaseService.Get();
            try
            {
                if(licensePlate != null && manufacturerName != null && modelName != null)
                {
                    UpdateCar(db);
                }
                else
                {
                    AddNewCar(db);
                }
                Close();
            } catch(MySqlException ex)
            {
                string message = ex.ErrorCode switch
                {
                    E.DuplicateKeyEntry => "Samochód o podanych właściwościach już istnieje.",
                    E.NoReferencedRow2 => "Nie istnieje z w bazie model samochodu produkowany przez wybranego producenta",
                    _ => $"{ex.Message} (kod błędu: {ex.ErrorCode})"
                };
                MessageBox.Show(message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Jeśli podano nieistniejącego producenta i/lub model, zapytaj, czy utworzyć takie wpisy w bazie danych
        }

        private void UpdateCar(DatabaseService db)
        {
            db.update(DatabaseService.TABLE_CARS,
                new() { ["licensePlate"] = licensePlate, ["manufacturerName"] = manufacturerName, ["modelName"] = modelName },
                new() { ["manufacturerName"] = (string)cbManufacturer.SelectedItem,
                        ["modelName"] = (string)cbModel.SelectedItem,
                        ["licensePlate"] = tbLicencePlate.Text 
                      });
        }

        private void AddNewCar(DatabaseService db)
        {
            db.insert(DatabaseService.TABLE_CARS,
                new() { ["manufacturerName"] = (string)cbManufacturer.SelectedItem,
                        ["modelName"] = (string)cbModel.SelectedItem,
                        ["licensePlate"] = tbLicencePlate.Text 
                      });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
