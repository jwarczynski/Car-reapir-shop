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
    public partial class PickPartForm : Form
    {
        public string? PartCode { get; protected set; }
        public string? SelectedPartLabel { get; protected set; }
        public int Quantity { get; protected set; }

        protected Dictionary<string, string> parts = new();

        public PickPartForm(string? partCode, int quantity = 1)
        {
            InitializeComponent();
            PartCode = partCode;
            Quantity = quantity;
        }

        private void PickPartForm_Load(object sender, EventArgs e)
        {
            LoadParts();
            numQuantity.Value = Quantity;
        }

        protected void LoadParts()
        {
            var parts = DatabaseService.Get().Select(DatabaseService.TABLE_PARTS,
                fields: new() { "name", "partCode" });

            cbParts.BeginUpdate();
            foreach (var part in parts)
            {
                var text = $"{part[0]} (#{part[1]})";
                cbParts.Items.Add(text);
                this.parts[text] = part[1]!;

                if (part[1] == PartCode)
                {
                    cbParts.SelectedItem = text;
                    SelectedPartLabel = text;
                }
            }
            cbParts.EndUpdate();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var selected = (string?)cbParts.SelectedItem;
            if(selected == null)
            {
                MessageBox.Show("Wybierz część z listy rozwijanej.", "Nie wybrano części", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            PartCode = parts[selected];
            SelectedPartLabel = selected;
            Quantity = (int)numQuantity.Value;
            Close();
        }
    }
}
