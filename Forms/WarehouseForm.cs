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
            var editPartForm = new EditPartForm(null);
            editPartForm.ShowDialog();
            ReloadParts();
        }

        private void btnEditPart_Click(object sender, EventArgs e)
        {
            EditSelectedPart();
        }

        private void lvPartsList_ItemActivate(object sender, EventArgs e)
        {
            EditSelectedPart();
        }

        private void WarehouseForm_Load(object sender, EventArgs e)
        {
            ReloadParts();
        }

        private void lvPartsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEditPart.Enabled = (lvPartsList.SelectedItems.Count == 1);
        }

        private void EditSelectedPart()
        {
            var selectedItems = lvPartsList.SelectedItems;
            if (selectedItems.Count != 1)
            {
                MessageBox.Show("Wybierz część, którą chcesz edytować.", "Nic nie wybrano", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var selectedItem = selectedItems[0];
            var partCodeSubItem = selectedItem.SubItems[1];
            var partCode = partCodeSubItem.Text;

            var editPartForm = new EditPartForm(partCode);
            editPartForm.ShowDialog();
            ReloadParts();
        }

        private void ReloadParts()
        {
            var parts = DatabaseService.Get().Select(DatabaseService.TABLE_PARTS, null,
                new() { "name", "partCode", "currentlyInStock", "maxInStock", "cost" });

            if (parts == null) return;

            lvPartsList.Items.Clear();
            foreach (var part in parts)
            {
                var lvItem = new ListViewItem(part.ToArray());
                lvPartsList.Items.Add(lvItem);
            }
        }
    }
}
