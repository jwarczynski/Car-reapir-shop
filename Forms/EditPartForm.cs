﻿using MySqlConnector;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WarsztatSamochodowy.Services;

namespace WarsztatSamochodowy.Forms
{
    public partial class EditPartForm : Form
    {
        protected string? partCode;
        protected List<(string, string)> originalCarModels = new();

        public EditPartForm(string? partCode)
        {
            InitializeComponent();

            this.partCode = partCode;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
                Close();
            } catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Błąd wartości", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditPartForm_Load(object sender, EventArgs e)
        {
            PopulateInputs();
        }

        private void PopulateInputs()
        {
            ClearInputs();

            if (partCode != null)
            {
                SortedDictionary<string, string> condition = new();
                condition["partCode"] = partCode;

                var parts = DatabaseService.Get().Select(DatabaseService.TABLE_PARTS, condition,
                    new() { "name", "partCode", "currentlyInStock", "maxInStock", "cost" });

                if (parts.Count == 0)
                {
                    MessageBox.Show($"Część o kodzie '{partCode}' nie istnieje", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }
                var fields = parts[0];

                tbPartName.Text = fields[0]?.ToString() ?? "";
                tbPartCode.Text = fields[1]?.ToString() ?? "";
                tbMaxInStock.Text = fields[3]?.ToString() ?? "";
                tbUnitPrice.Text = fields[4]?.ToString() ?? "";


                var selectedModels = DatabaseService.Get().Select(DatabaseService.TABLE_PARTS_CAR_MODELS,
                    new() { ["partCode"] = partCode },
                    new() { "manufacturerName", "modelName" });
                foreach (var model in selectedModels)
                {
                    var item = new ListViewItem($"{model[0]} {model[1]}");
                    var modelTuple = (model[0]!, model[1]!);
                    item.Tag = modelTuple;
                    originalCarModels.Add(modelTuple);
                    lvSelectedModels.Items.Add(item);
                }
                lvSelectedModels.Sort();
            }

            var carModels = DatabaseService.Get().Select(DatabaseService.TABLE_CAR_MODELS,
                fields: new() { "manufacturerName", "modelName" });
            foreach (var model in carModels)
            {
                var modelTuple = (model[0]!, model[1]!);
                if (originalCarModels.Contains(modelTuple)) continue;

                var item = new ListViewItem($"{model[0]} {model[1]}");
                item.Tag = modelTuple;
                lvAllModels.Items.Add(item);
            }
            lvAllModels.Sort();
        }

        private void ClearInputs()
        {
            tbPartName.Text = "";
            tbPartCode.Text = "";
            tbMaxInStock.Text = "";
            tbUnitPrice.Text = "";
        }

        private void lvAllModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPickPart.Enabled = (lvAllModels.SelectedItems.Count > 0);
        }

        private void lvSelectedModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnUnpickPart.Enabled = (lvSelectedModels.SelectedItems.Count > 0);
        }

        private void btnPickPart_Click(object sender, EventArgs e)
        {
            MoveSelectedItemsBetween(lvAllModels, lvSelectedModels);
        }

        private void btnUnpickPart_Click(object sender, EventArgs e)
        {
            MoveSelectedItemsBetween(lvSelectedModels, lvAllModels);
        }

        private void lvAllModels_ItemActivate(object sender, EventArgs e)
        {
            MoveSelectedItemsBetween(lvAllModels, lvSelectedModels);
        }

        private void lvSelectedModels_ItemActivate(object sender, EventArgs e)
        {
            MoveSelectedItemsBetween(lvSelectedModels, lvAllModels);
        }

        private void MoveSelectedItemsBetween(ListView from, ListView to)
        {
            var selectedItems = from.SelectedItems;
            foreach (ListViewItem item in selectedItems)
            {
                var newItem = new ListViewItem(item.Text);
                newItem.Tag = item.Tag;
                to.Items.Add(newItem);
                item.Remove();
            }
            from.Sort();
            to.Sort();
        }

        private void Save()
        {
            var db = DatabaseService.Get();

            if (!int.TryParse(tbMaxInStock.Text, out int maxInStock))
            {
                throw new ArgumentException("Podaj poprawną liczbę całkowitą w polu 'Pojemność magazynu'.");
            }
            if (!double.TryParse(tbUnitPrice.Text, out double cost))
            {
                throw new ArgumentException("Podaj poprawną liczbę w polu 'Cena jednostkowa'.");
            }

            if(partCode != null)
            {
                db.update(DatabaseService.TABLE_PARTS,
                    new () { ["partCode"] = partCode },
                    new () {
                        ["partCode"] = tbPartCode.Text,
                        ["name"] = tbPartName.Text,
                        ["maxInStock"] = maxInStock.ToString(CultureInfo.InvariantCulture),
                        ["cost"] = cost.ToString(CultureInfo.InvariantCulture)
                    });
            }
            else
            {
                db.insert(DatabaseService.TABLE_PARTS,
                    new() {
                        ["partCode"] = tbPartCode.Text,
                        ["name"] = tbPartName.Text,
                        ["maxInStock"] = maxInStock.ToString(CultureInfo.InvariantCulture),
                        ["cost"] = cost.ToString(CultureInfo.InvariantCulture)
                    });
            }
            partCode = tbPartCode.Text;

            var selectedModels = lvSelectedModels.Items;
            foreach(ListViewItem selectedModel in selectedModels)
            {
                var modelTuple = ((string, string))selectedModel.Tag;
                if (originalCarModels.Remove(modelTuple)) continue;

                db.insert(DatabaseService.TABLE_PARTS_CAR_MODELS,
                    new() { ["partCode"] = partCode, ["manufacturerName"] = modelTuple.Item1, ["modelName"] = modelTuple.Item2 });
            }
            foreach(var modelTuple in originalCarModels)
            {
                db.delete(DatabaseService.TABLE_PARTS_CAR_MODELS,
                    new() { ["partCode"] = partCode, ["manufacturerName"] = modelTuple.Item1, ["modelName"] = modelTuple.Item2 });
            }
        }
    }
}
