using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WarsztatSamochodowy.Services;

namespace WarsztatSamochodowy.Forms
{
    public partial class ShoppingListsForm : Form
    {
        public ShoppingListsForm()
        {
            InitializeComponent();
        }

        private void ShoppingListsForm_Load(object sender, EventArgs e)
        {
            ReloadLists();
        }

        private void lvShoppingLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshEditButtonState();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var manageShoppingListForm = new ManageShoppingListForm(null);
            manageShoppingListForm.ShowDialog();
        }

        private void btnManageList_Click(object sender, EventArgs e)
        {
            EditSelectedList();
        }

        private void lvShoppingLists_ItemActivate(object sender, EventArgs e)
        {
            EditSelectedList();
            RefreshEditButtonState();
        }

        private void EditSelectedList()
        {
            var selectedItems = lvShoppingLists.SelectedItems;
            if (selectedItems.Count != 1)
            {
                MessageBox.Show("Wybierz listę, którą chcesz edytować.", "Nic nie wybrano", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var selectedItem = selectedItems[0];
            var listNameSubItem = selectedItem.SubItems[0];
            var listName = listNameSubItem.Text;

            var manageShoppingListForm = new ManageShoppingListForm(listName);
            manageShoppingListForm.ShowDialog();
            ReloadLists();
        }

        private void ReloadLists()
        {
            var rows = DatabaseService.Get().Select(DatabaseService.TABLE_SHOPPING_LISTS_WITH_PART_COUNT,
                fields: new() { "name", "partsCount", "isFulfilled" });

            if (rows == null) return;

            lvShoppingLists.Items.Clear();
            foreach (var row in rows)
            {
                string?[] fields = row.ToArray();
                if (fields[2] != "0")
                    fields[2] = "Zrealizowana";
                else
                    fields[2] = "Oczekująca";

                var lvItem = new ListViewItem(fields);
                lvShoppingLists.Items.Add(lvItem);
            }
            RefreshEditButtonState();
        }

        private void RefreshEditButtonState()
        {
            btnManageList.Enabled = (lvShoppingLists.SelectedItems.Count == 1);
        }
    }
}
