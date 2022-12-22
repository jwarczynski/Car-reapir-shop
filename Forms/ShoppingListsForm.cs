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

        private void btnManageList_Click(object sender, EventArgs e)
        {
            var manageShoppingListForm = new ManageShoppingListForm();
            manageShoppingListForm.Show();
        }

        private void ShoppingListsForm_Load(object sender, EventArgs e)
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
        }
    }
}
