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
    public partial class PickShoppingListForm : Form
    {
        public string? SelectedListName { get; protected set; } = null;

        public bool FilterFulfillmentState = false;
        public string? SkipListName = null;

        public PickShoppingListForm()
        {
            InitializeComponent();
        }

        private void PickShoppingListForm_Load(object sender, EventArgs e)
        {
            var fulfillFilter = FilterFulfillmentState ? "1" : "0";

            var lists = DatabaseService.Get().Select(DatabaseService.TABLE_SHOPPING_LISTS,
                new() { ["isFulfilled"] = fulfillFilter }, new() { "name" });

            lvShoppingLists.BeginUpdate();
            lvShoppingLists.Items.Clear();
            foreach(var list in lists)
            {
                string name = list[0]!;
                if (name == SkipListName) continue;
                lvShoppingLists.Items.Add(new ListViewItem(name));
            }
            lvShoppingLists.EndUpdate();
        }

        private void lvShoppingLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPick.Enabled = (lvShoppingLists.SelectedItems.Count == 1);
        }

        private void btnPick_Click(object sender, EventArgs e)
        {
            ResolveWithSelectedItem();
        }

        private void lvShoppingLists_ItemActivate(object sender, EventArgs e)
        {
            ResolveWithSelectedItem();
        }

        protected void ResolveWithSelectedItem()
        {
            var selectedItem = lvShoppingLists.SelectedItems[0];
            SelectedListName = selectedItem.Text;
            Close();
        }
    }
}
