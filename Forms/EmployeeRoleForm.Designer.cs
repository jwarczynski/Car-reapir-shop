namespace WarsztatSamochodowy.Forms
{
    partial class EmployeeRoleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.roleDataGrid = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRemoveRole = new System.Windows.Forms.Button();
            this.btnEditRole = new System.Windows.Forms.Button();
            this.maxWageNumeric = new System.Windows.Forms.NumericUpDown();
            this.maxWageLabel = new System.Windows.Forms.Label();
            this.btnAddRole = new System.Windows.Forms.Button();
            this.minWageNumeric = new System.Windows.Forms.NumericUpDown();
            this.minWageLabel = new System.Windows.Forms.Label();
            this.roleNameLabel = new System.Windows.Forms.Label();
            this.roleNameTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roleDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxWageNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minWageNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.roleDataGrid);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.btnRemoveRole);
            this.splitContainer1.Panel2.Controls.Add(this.btnEditRole);
            this.splitContainer1.Panel2.Controls.Add(this.maxWageNumeric);
            this.splitContainer1.Panel2.Controls.Add(this.maxWageLabel);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddRole);
            this.splitContainer1.Panel2.Controls.Add(this.minWageNumeric);
            this.splitContainer1.Panel2.Controls.Add(this.minWageLabel);
            this.splitContainer1.Panel2.Controls.Add(this.roleNameLabel);
            this.splitContainer1.Panel2.Controls.Add(this.roleNameTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(997, 403);
            this.splitContainer1.SplitterDistance = 674;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // roleDataGrid
            // 
            this.roleDataGrid.AllowUserToAddRows = false;
            this.roleDataGrid.AllowUserToDeleteRows = false;
            this.roleDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.roleDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.roleDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roleDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.roleDataGrid.Location = new System.Drawing.Point(0, 0);
            this.roleDataGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.roleDataGrid.MultiSelect = false;
            this.roleDataGrid.Name = "roleDataGrid";
            this.roleDataGrid.RowHeadersWidth = 51;
            this.roleDataGrid.RowTemplate.Height = 25;
            this.roleDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.roleDataGrid.Size = new System.Drawing.Size(674, 403);
            this.roleDataGrid.TabIndex = 0;
            this.roleDataGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.roleDataGrid_CellMouseClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(19, 249);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(255, 29);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Zamknij";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRemoveRole
            // 
            this.btnRemoveRole.Location = new System.Drawing.Point(19, 214);
            this.btnRemoveRole.Name = "btnRemoveRole";
            this.btnRemoveRole.Size = new System.Drawing.Size(255, 29);
            this.btnRemoveRole.TabIndex = 4;
            this.btnRemoveRole.Text = "Usuń zaznaczoną";
            this.btnRemoveRole.UseVisualStyleBackColor = true;
            this.btnRemoveRole.Click += new System.EventHandler(this.btnRemoveRole_Click);
            // 
            // btnEditRole
            // 
            this.btnEditRole.Location = new System.Drawing.Point(157, 178);
            this.btnEditRole.Name = "btnEditRole";
            this.btnEditRole.Size = new System.Drawing.Size(117, 29);
            this.btnEditRole.TabIndex = 5;
            this.btnEditRole.Text = "Zapisz";
            this.btnEditRole.UseVisualStyleBackColor = true;
            this.btnEditRole.Click += new System.EventHandler(this.btnEditRole_Click);
            // 
            // maxWageNumeric
            // 
            this.maxWageNumeric.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.maxWageNumeric.Location = new System.Drawing.Point(157, 133);
            this.maxWageNumeric.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.maxWageNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.maxWageNumeric.Name = "maxWageNumeric";
            this.maxWageNumeric.Size = new System.Drawing.Size(120, 27);
            this.maxWageNumeric.TabIndex = 6;
            // 
            // maxWageLabel
            // 
            this.maxWageLabel.AutoSize = true;
            this.maxWageLabel.Location = new System.Drawing.Point(157, 109);
            this.maxWageLabel.Name = "maxWageLabel";
            this.maxWageLabel.Size = new System.Drawing.Size(131, 20);
            this.maxWageLabel.TabIndex = 5;
            this.maxWageLabel.Text = "placa maksymalna";
            // 
            // btnAddRole
            // 
            this.btnAddRole.Location = new System.Drawing.Point(19, 178);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(117, 29);
            this.btnAddRole.TabIndex = 2;
            this.btnAddRole.Text = "Dodaj";
            this.btnAddRole.UseVisualStyleBackColor = true;
            this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
            // 
            // minWageNumeric
            // 
            this.minWageNumeric.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.minWageNumeric.Location = new System.Drawing.Point(19, 133);
            this.minWageNumeric.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.minWageNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.minWageNumeric.Name = "minWageNumeric";
            this.minWageNumeric.Size = new System.Drawing.Size(120, 27);
            this.minWageNumeric.TabIndex = 4;
            // 
            // minWageLabel
            // 
            this.minWageLabel.AutoSize = true;
            this.minWageLabel.Location = new System.Drawing.Point(19, 109);
            this.minWageLabel.Name = "minWageLabel";
            this.minWageLabel.Size = new System.Drawing.Size(119, 20);
            this.minWageLabel.TabIndex = 3;
            this.minWageLabel.Text = "placa minimalna";
            // 
            // roleNameLabel
            // 
            this.roleNameLabel.AutoSize = true;
            this.roleNameLabel.Location = new System.Drawing.Point(19, 29);
            this.roleNameLabel.Name = "roleNameLabel";
            this.roleNameLabel.Size = new System.Drawing.Size(77, 20);
            this.roleNameLabel.TabIndex = 1;
            this.roleNameLabel.Text = "nazwa roli";
            // 
            // roleNameTextBox
            // 
            this.roleNameTextBox.Location = new System.Drawing.Point(19, 53);
            this.roleNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.roleNameTextBox.Name = "roleNameTextBox";
            this.roleNameTextBox.Size = new System.Drawing.Size(257, 27);
            this.roleNameTextBox.TabIndex = 0;
            // 
            // EmployeeRoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 403);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EmployeeRoleForm";
            this.Text = "Role pracowników";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.roleDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxWageNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minWageNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView dataGridView1;
        private NumericUpDown maxWageNumeric;
        private Label maxWageLabel;
        private NumericUpDown minWageNumeric;
        private Label minWageLabel;
        private Label roleNameLabel;
        private TextBox roleNameTextBox;
        private Button btnCancel;
        private Button btnEditRole;
        private Button btnRemoveRole;
        private Button btnAddRole;
        private DataGridView roleDataGrid;
    }
}