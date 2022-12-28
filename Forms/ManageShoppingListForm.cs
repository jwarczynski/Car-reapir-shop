using MySqlConnector;
using E = MySqlConnector.MySqlErrorCode;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WarsztatSamochodowy.Services;

namespace WarsztatSamochodowy.Forms
{
    public partial class ManageShoppingListForm : Form
    {
        protected string? listName;

        public ManageShoppingListForm(string? listName)
        {
            InitializeComponent();

            this.listName = listName;
            FillView();
        }

        protected void FillView()
        {
            tbListName.Text = listName ?? "";
            tbListName.ReadOnly = (listName != null);
            btnAddEntry.Enabled = (listName != null);

            if (listName == null) return;

            var entries = DatabaseService.Get().Select(DatabaseService.TABLE_SHOPPING_LISTS_PARTS_WITH_NAMES,
                new() { ["listName"] = listName }, new() { "partCode", "partName", "quantity" });

            lvListParts.Items.Clear();
            foreach(var entry in entries)
            {
                string[] fields = {
                    $"{entry[1]} (#{entry[0]})",
                    $"{entry[2]}"
                };
                var lvItem = new ListViewItem(fields);
                lvListParts.Items.Add(lvItem);
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            if (tbListName.ReadOnly)
            {
                tbListName.ReadOnly = false;
                return;
            }

            InitiateSaveListName();
        }

        private void tbListName_DoubleClick(object sender, EventArgs e)
        {
            if (!tbListName.ReadOnly) return;
            tbListName.ReadOnly = false;
            tbListName.Select(tbListName.Text.Length, 0);
        }

        private void tbListName_ReadOnlyChanged(object sender, EventArgs e)
        {
            btnRename.Text = tbListName.ReadOnly ? "Zmień" : "Zapisz";
        }

        private void tbListName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tbListName.ReadOnly) return;

            if (e.KeyChar == (char)Keys.Enter)
            {
                InitiateSaveListName();
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Escape && listName != null)
            {
                tbListName.Text = listName;
                tbListName.ReadOnly = true;
                e.Handled = true;
            }
        }

        private void InitiateSaveListName()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tbListName.Text))
                {
                    throw new ArgumentException("Nazwa listy nie może być pusta");
                }

                SaveListName(tbListName.Text);
                tbListName.ReadOnly = true;
                btnAddEntry.Enabled = true;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Niepoprawne dane", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (MySqlException ex)
            {
                string message = ex.ErrorCode switch
                {
                    E.DuplicateKeyEntry => "Lista o podanej nazwie już istnieje.",
                    _ => $"{ex.Message} (kod błędu: {ex.ErrorCode})"
                };
                MessageBox.Show(message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveListName(string newListName)
        {
            var db = DatabaseService.Get();
            
            if(listName != null)
            {
                db.update(DatabaseService.TABLE_SHOPPING_LISTS,
                    new() { ["name"] = listName }, new() { ["name"] = newListName });
            } else
            {
                db.insert(DatabaseService.TABLE_SHOPPING_LISTS,
                    new() { ["name"] = newListName, ["isFulfilled"] = "0" });
            }
            listName = newListName;
        }
    }
}
