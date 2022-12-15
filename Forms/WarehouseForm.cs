using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WarsztatSamochodowy.Models;
using WarsztatSamochodowy.Services;

namespace WarsztatSamochodowy.Forms
{
    public partial class WarehouseForm : Form
    {
        public WarehouseForm()
        {
            InitializeComponent();
        }

        private void btnShoppingLists_Click(object sender, EventArgs e)
        {
            var shoppingListsForm = new ShoppingListsForm();
            shoppingListsForm.Show();
        }

        private void btnAddPart_Click(object sender, EventArgs e)
        {
            var editPartForm = new EditPartForm();
            editPartForm.ShowDialog();
        }

        private void WarehouseForm_Load(object sender, EventArgs e)
        {
            var parts = DatabaseService.Get().Select("parts");

            lvPartsList.DataSource = parts;
            lvPartsList.Columns[0].HeaderText = "Kod części";
            lvPartsList.Columns[1].HeaderText = "Nazwa";
            lvPartsList.Columns[2].HeaderText = "Cena jedn.";
            lvPartsList.Columns[3].HeaderText = "W magazynie";
            lvPartsList.Columns[4].HeaderText = "Pojemność magazynu";
            
            foreach(DataGridViewColumn column in lvPartsList.Columns)
                column.ReadOnly = true;
        }
    }
}
