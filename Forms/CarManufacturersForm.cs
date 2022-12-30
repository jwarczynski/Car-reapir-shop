using Microsoft.VisualBasic;

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
    public partial class CarManufacturersForm : Form
    {
        public CarManufacturersForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CarManufacturersForm_Load(object sender, EventArgs e)
        {
            var manufacturers = DatabaseService.Get().Select(DatabaseService.TABLE_CAR_MANUFACTURERS,
                fields: new() { "manufacturerName" });

            lvManufacturersList.BeginUpdate();
            lvManufacturersList.Items.Clear();
            foreach(var manufacturer in manufacturers)
            {
                string name = manufacturer[0]!;
                lvManufacturersList.Items.Add(new ListViewItem(name));
            }
            lvManufacturersList.Sort();
            lvManufacturersList.EndUpdate();
        }

        private void lvManufacturersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled =
                btnRemove.Enabled = (lvManufacturersList.SelectedItems.Count == 1);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string manufacturerName = Interaction.InputBox("Podaj nazwę producenta, którego chcesz dodać", "Dodaj producenta");
            if (string.IsNullOrEmpty(manufacturerName)) return;

            try
            {
                DatabaseService.Get().insert(DatabaseService.TABLE_CAR_MANUFACTURERS,
                    new() { ["manufacturerName"] = manufacturerName });
                lvManufacturersList.Items.Add(new ListViewItem(manufacturerName));
                lvManufacturersList.Sort();
            } catch(MySqlException ex)
            {
                string message = ex.ErrorCode switch
                {
                    E.DuplicateKeyEntry => "Producent o podanej nazwie już istnieje.",
                    _ => $"{ex.Message} (kod błędu: {ex.ErrorCode})"
                };
                MessageBox.Show(message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditSelectedItem();
        }

        private void lvManufacturersList_ItemActivate(object sender, EventArgs e)
        {
            EditSelectedItem();
        }

        protected void EditSelectedItem()
        {
            if (lvManufacturersList.SelectedItems.Count != 1)
            {
                MessageBox.Show("Wybierz producenta, którego chcesz edytować.", "Nic nie wybrano",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var selectedItem = lvManufacturersList.SelectedItems[0];
            var selectedManufacturer = selectedItem.Text;

            string manufacturerName = Interaction.InputBox($"Podaj nową nazwę dla producenta „{selectedManufacturer}”",
                "Edytuj producenta", selectedManufacturer);
            if (manufacturerName == selectedManufacturer || manufacturerName == "") return;

            if (string.IsNullOrWhiteSpace(manufacturerName))
            {
                MessageBox.Show("Nazwa producenta nie może być pusta", "Niewłaściwa nazwa",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DatabaseService.Get().update(DatabaseService.TABLE_CAR_MANUFACTURERS,
                    new() { ["manufacturerName"] = selectedManufacturer },
                    new() { ["manufacturerName"] = manufacturerName });

                selectedItem.Text = manufacturerName;
                lvManufacturersList.Sort();
            }
            catch (MySqlException ex)
            {
                string message = ex.ErrorCode switch
                {
                    E.DuplicateKeyEntry => "Producent o podanej nazwie już istnieje.",
                    _ => $"{ex.Message} (kod błędu: {ex.ErrorCode})"
                };
                MessageBox.Show(message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lvManufacturersList.SelectedItems.Count != 1)
            {
                MessageBox.Show("Wybierz producenta, którego chcesz usunąć.", "Nic nie wybrano",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var selectedItem = lvManufacturersList.SelectedItems[0];
            var selectedManufacturer = selectedItem.Text;

            try
            {
                var db = DatabaseService.Get();
                var modelCount = (int?)db.CallFunction(DatabaseService.FUNC_COUNT_MODELS_BY_MANUFACTURER,
                    new() { selectedManufacturer });

                if(modelCount != 0 && modelCount != null)
                {
                    var result = MessageBox.Show($"W bazie danych istnieje {modelCount} modeli tego producenta. Jeśli skasujesz producenta, usunięte zostaną również te modele. Czy kontynuować?",
                        "Potwierdź kaskadowe usuwanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No) return;
                }

                db.delete(DatabaseService.TABLE_CAR_MANUFACTURERS,
                    new() { ["manufacturerName"] = selectedManufacturer });

                selectedItem.Remove();
                lvManufacturersList.Sort();
            }
            catch (MySqlException ex)
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
