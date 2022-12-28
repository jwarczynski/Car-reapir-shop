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


            // Validate
            // Save
            tbListName.ReadOnly = true;
        }

        private void tbListName_ReadOnlyChanged(object sender, EventArgs e)
        {
            btnRename.Text = tbListName.ReadOnly ? "Zmień" : "Zapisz";
        }
    }
}
