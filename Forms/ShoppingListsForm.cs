using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
