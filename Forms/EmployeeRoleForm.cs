using MySqlConnector;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarsztatSamochodowy.Services;

namespace WarsztatSamochodowy.Forms
{
    public partial class EmployeeRoleForm : Form
    {
        private const string EMPLOYEE_ROLES_TABLE = "employeeRoles";
        private const int ROLE_NAME_MAX_LENGHT = 20;

        string? roleNameToEdit;
        string? minWageToEdit;
        string? maxWageToEdit;

        private SortedDictionary<string, string> selectedRole;
        private SortedDictionary<string, string> updatedRole;

        public EmployeeRoleForm()
        {
            InitializeComponent();
            showAllRoles();
            selectedRole = new SortedDictionary<string, string>();
            updatedRole = new SortedDictionary<string, string>();
        }

        private void showAllRoles()
        {
            List<string> attributesNames = new List<string> { "Nazwa", "płaca minimalna", "płaca maksymalna" };
            roleDataGrid.DataSource = DatabaseService.Get().selectAllToTable(EMPLOYEE_ROLES_TABLE, attributesNames);
            roleDataGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            roleDataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            roleDataGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        private void RefreshTable()
        {
            roleDataGrid.DataSource = null;
            showAllRoles();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
           
        private void btnAddRole_Click(object sender, EventArgs e)
        {
            string? roleName = roleNameTextBox.Text;
            string minWage = minWageNumeric.Value.ToString();
            string maxWage = maxWageNumeric.Value.ToString();

            if(minWageNumeric.Value > maxWageNumeric.Value)
            {
                MessageBox.Show("płaca minimalna nie może być wyższa od maksymalnej");
                return;
            }

            if(roleName == null)
            {
                MessageBox.Show("rola musi posiadać nazwę");
                return;
            } else
            {
                SortedDictionary<string, string> roleMap = new SortedDictionary<string, string>();
                roleMap.Add("roleName", roleName);
                roleMap.Add("minimumWage", minWage);
                roleMap.Add("maximumWage", maxWage);

                try
                {
                    DatabaseService.Get().insert(EMPLOYEE_ROLES_TABLE, roleMap!);
                    showAllRoles();
                } catch(MySqlException sqlException)
                {
                    if(sqlException.ErrorCode == MySqlErrorCode.DuplicateKeyEntry)
                    {
                        MessageBox.Show("Istnieje już rola o podanej nazwie");
                    }
                }
            }

        }

        private void btnEditRole_Click(object sender, EventArgs e)
        {
            if(roleNameToEdit != null)
            {
                string newRoleName = roleNameTextBox.Text;
                //TODO validate roleName
                if (!IsValidRoleName(newRoleName))
                {
                    MessageBox.Show("niepoprawna nazwa roli");
                    return;
                }
                if(minWageNumeric.Value > maxWageNumeric.Value)
                {
                    MessageBox.Show("płaca minimalna nie może być większa od maksymalnej");
                    return;
                }
                string newMinWage = minWageNumeric.Value.ToString(CultureInfo.InvariantCulture);
                string newMaxWage = maxWageNumeric.Value.ToString(CultureInfo.InvariantCulture);

                SortedDictionary<string, string?> oldRole = new SortedDictionary<string, string?>();
                oldRole.Add("roleName", roleNameToEdit);

                SortedDictionary<string, string?> newRole = new SortedDictionary<string, string?>();
                newRole.Add("roleName", newRoleName);
                newRole.Add("minimumWage", newMinWage);
                newRole.Add("maximumWage", newMaxWage);

                try
                {
                    DatabaseService.Get().update(EMPLOYEE_ROLES_TABLE, oldRole, newRole);
                } catch(MySqlException sqlException)
                {
                    if(sqlException.ErrorCode == MySqlErrorCode.DuplicateKeyEntry)
                    {
                        MessageBox.Show("Istnieje już rola o podanej nazwie");
                        return;
                    }
                    else
                    {
                        MessageBox.Show(sqlException.Message);
                        return;
                    }
                }
                ClearInputs();
                RefreshTable();
            }
        }

        private void ClearInputs()
        {
            roleNameTextBox.Text = "";
        }

        private void roleDataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            roleNameToEdit = roleDataGrid.SelectedRows[0].Cells[0].Value.ToString();
            minWageToEdit = roleDataGrid.SelectedRows[0].Cells[1].Value.ToString();
            maxWageToEdit = roleDataGrid.SelectedRows[0].Cells[2].Value.ToString();

            roleNameTextBox.Text = roleNameToEdit;
            minWageNumeric.Value = (decimal)float.Parse(minWageToEdit!);
            maxWageNumeric.Value = (decimal)float.Parse(maxWageToEdit!);
        }

        private bool IsValidRoleName(string? roleName)
        {
            if(roleName == null)
            {
                return false;
            }
            if(roleName == "")
            {
                return false;
            }
            if(roleName.Length > ROLE_NAME_MAX_LENGHT)
            {
                return false;
            }
            return true;
        }

        private void btnRemoveRole_Click(object sender, EventArgs e)
        {
            if(roleNameToEdit != null)
            {
                SortedDictionary<string, string> roleToDelete = new SortedDictionary<string, string>();
                roleToDelete.Add("roleName", roleNameToEdit);
                try
                {
                    DatabaseService.Get().delete(EMPLOYEE_ROLES_TABLE, roleToDelete);
                    showAllRoles();
                }
                catch(MySqlException exception)
                {
                    if(exception.ErrorCode == MySqlErrorCode.RowIsReferenced2)
                    {
                        MessageBox.Show("Nie można usunąc roli, która jest przypisana do pracownika");
                    }
                    else
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }

        }
    }
}
