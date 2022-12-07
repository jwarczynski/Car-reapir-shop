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
    public partial class CarsListForm : Form
    {
        public CarsListForm()
        {
            InitializeComponent();
        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {
            var editCarForm = new EditCarForm();
            editCarForm.ShowDialog();
        }
    }
}
