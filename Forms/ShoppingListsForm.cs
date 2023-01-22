using MySqlConnector;

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
            RefreshButtonsStates();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var manageShoppingListForm = new ManageShoppingListForm(null);
            manageShoppingListForm.ShowDialog();
            ReloadLists();
        }

        private void btnManageList_Click(object sender, EventArgs e)
        {
            EditSelectedList();
        }

        private void lvShoppingLists_ItemActivate(object sender, EventArgs e)
        {
            EditSelectedList();
            RefreshButtonsStates();
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
            var listName = (string)selectedItem.Tag;

            var manageShoppingListForm = new ManageShoppingListForm(listName);
            manageShoppingListForm.ShowDialog();
            ReloadLists();
        }

        private void ReloadLists()
        {
            var db = DatabaseService.Get();
            var rows = db.Select(DatabaseService.TABLE_SHOPPING_LISTS_WITH_PART_COUNT,
                fields: new() { "name", "partsCount", "isFulfilled" });

            if (rows == null) return;

            cbAutoList.BeginUpdate();
            cbAutoList.Items.Clear();
            cbAutoList.Items.Add("(żadna)");

            lvShoppingLists.BeginUpdate();
            lvShoppingLists.Items.Clear();
            foreach (var row in rows)
            {
                string?[] fields = row.ToArray();
                if (fields[2] != "0")
                {
                    fields[2] = "Zrealizowana";
                }
                else
                {
                    fields[2] = "Oczekująca";
                    cbAutoList.Items.Add(fields[0]);
                }

                var lvItem = new ListViewItem(fields)
                {
                    Tag = fields[0]
                };
                lvShoppingLists.Items.Add(lvItem);
            }
            lvShoppingLists.EndUpdate();
            cbAutoList.EndUpdate();

            var autolist = db.CallFunction(DatabaseService.FUNC_GET_AUTO_SHOPPING_LIST_NAME, new())!.ToString();
            cbAutoList.SelectedItem = autolist;
            if(cbAutoList.SelectedIndex < 0) cbAutoList.SelectedIndex = 0;

            RefreshButtonsStates();
        }

        private void RefreshButtonsStates()
        {
            bool isSingleSelected = (lvShoppingLists.SelectedItems.Count == 1);
            btnManageList.Enabled = isSingleSelected;

            if(!isSingleSelected)
            {
                btnDeleteList.Enabled = false;
            }
            else
            {
                var selectedItem = lvShoppingLists.SelectedItems[0];
                var entriesCount = selectedItem.SubItems[1].Text;
                btnDeleteList.Enabled = (entriesCount == "0");
            }
        }

        private void btnDeleteList_Click(object sender, EventArgs e)
        {
            if(lvShoppingLists.SelectedItems.Count != 1)
            {
                MessageBox.Show("Wybierz listę, którą chcesz usunąć.", "Nic nie wybrano");
                return;
            }

            var selectedItem = lvShoppingLists.SelectedItems[0];
            var entriesCount = selectedItem.SubItems[1].Text;
            if(entriesCount != "0")
            {
                MessageBox.Show("Wybrana lista nie jest pusta. Aby ją usunąć, przenieś z niej wszystkie pozycje na inną listę.", "Lista jest niepusta");
                return;
            }

            var listName = (string)selectedItem.Tag;

            try
            {
                DatabaseService.Get().delete(DatabaseService.TABLE_SHOPPING_LISTS,
                    new() { ["name"] = listName });
                selectedItem.Remove();
            }
            catch(MySqlException ex)
            {
                string message = ex.ErrorCode switch
                {
                    _ => $"{ex.Message} (kod błędu: {ex.ErrorCode})"
                };
                MessageBox.Show(message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveAutoList_Click(object sender, EventArgs e)
        {
            var autolistName = cbAutoList.SelectedItem.ToString();
            if (cbAutoList.SelectedIndex <= 0) autolistName = "";

            try
            {
                DatabaseService.Get().CallProcedure(
                    DatabaseService.PROC_SET_AUTO_SHOPPING_LIST_NAME,
                    new() { autolistName });
            }
            catch (MySqlException ex)
            {
                string message = "Nie udało się zmienić automatycznej listy zakupów.";
                MessageBox.Show(message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
