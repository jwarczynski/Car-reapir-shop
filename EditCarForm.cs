using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarsztatSamochodowy
{
    public partial class EditCarForm : Form
    {
        public EditCarForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Jeśli podano nieistniejącego producenta i/lub model, zapytaj, czy utworzyć takie wpisy w bazie danych
        }
    }
}
