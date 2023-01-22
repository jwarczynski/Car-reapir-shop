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
    public partial class CarsListForm : Form
    {
        public CarsListForm()
        {
            InitializeComponent();
        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {
            EditSelectedItem();
        }

        private void CarsListForm_Load(object sender, EventArgs e)
        {
            ReloadCars();
        }

        private void lvCars_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddCar.Enabled = btnRemoveCar.Enabled = (lvCars.SelectedItems.Count == 1);
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            var editCarlForm = new EditCarForm(null, null, null);
            editCarlForm.ShowDialog();
            ReloadCars();
        }

        protected void ReloadCars()
        {
            var cars = DatabaseService.Get().Select(DatabaseService.TABLE_CARS,
                fields: new() { "licensePlate", "modelName", "manufacturerName" });

            lvCars.BeginUpdate();
            lvCars.Items.Clear();
            foreach (var car in cars)
            {
                var item = new ListViewItem(car.ToArray());
                //var item = new ListViewItem($"{car[0]} {car[1]}, {car[2]}");
                item.Tag = (car[0]!, car[1]!, car[2]!);
                lvCars.Items.Add(item);
            }
            lvCars.Sort();
            lvCars.EndUpdate();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditSelectedItem();
        }

        private void lvCars_ItemActivate(object sender, EventArgs e)
        {
            EditSelectedItem();
        }

        protected void EditSelectedItem()
        {
            if(lvCars.SelectedItems.Count != 1)
            {
                MessageBox.Show("Wybierz samochód, który chcesz edytować.", "Nic nie wybrano",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var selectedItem = lvCars.SelectedItems[0];
            var (licensePlate, model, manufacturer) = ((string, string, string))selectedItem.Tag;

            var editCarForm = new EditCarForm(licensePlate, model, manufacturer);
            editCarForm.ShowDialog();
            ReloadCars();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lvCars.SelectedItems.Count != 1)
            {
                MessageBox.Show("Wybierz samochód, który chcesz edytować.", "Nic nie wybrano",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var selectedItem = lvCars.SelectedItems[0];
            var (licensePlate, manufacturer, model) = ((string, string, string))selectedItem.Tag;

            try
            {
                DatabaseService.Get().delete(DatabaseService.TABLE_CARS,
                    new() { ["licensePlate"] = licensePlate });

                selectedItem.Remove();
            } catch(MySqlException ex)
            {
                string message = ex.ErrorCode switch
                {
                    E.RowIsReferenced2 => "Nie można usunąć samochodu, bo dotyczą go istniejące zamówienia.",
                    _ => $"{ex.Message} (kod błędu: {ex.ErrorCode})"
                };
                MessageBox.Show(message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
