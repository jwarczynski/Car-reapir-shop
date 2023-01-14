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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEditRole = new System.Windows.Forms.Button();
            this.btnRemoveRole = new System.Windows.Forms.Button();
            this.btnAddRole = new System.Windows.Forms.Button();
            this.maxWageNumeric = new System.Windows.Forms.NumericUpDown();
            this.maxWageLabel = new System.Windows.Forms.Label();
            this.minWageNumeric = new System.Windows.Forms.NumericUpDown();
            this.minWageLabel = new System.Windows.Forms.Label();
            this.roleNameLabel = new System.Windows.Forms.Label();
            this.roleNameTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roleDataGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxWageNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minWageNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.roleDataGrid);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.maxWageNumeric);
            this.splitContainer1.Panel2.Controls.Add(this.maxWageLabel);
            this.splitContainer1.Panel2.Controls.Add(this.minWageNumeric);
            this.splitContainer1.Panel2.Controls.Add(this.minWageLabel);
            this.splitContainer1.Panel2.Controls.Add(this.roleNameLabel);
            this.splitContainer1.Panel2.Controls.Add(this.roleNameTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(872, 302);
            this.splitContainer1.SplitterDistance = 590;
            this.splitContainer1.TabIndex = 0;
            // 
            // roleDataGrid
            // 
            this.roleDataGrid.AllowUserToAddRows = false;
            this.roleDataGrid.AllowUserToDeleteRows = false;
            this.roleDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.roleDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.roleDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roleDataGrid.Location = new System.Drawing.Point(0, 0);
            this.roleDataGrid.MultiSelect = false;
            this.roleDataGrid.Name = "roleDataGrid";
            this.roleDataGrid.RowTemplate.Height = 25;
            this.roleDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.roleDataGrid.Size = new System.Drawing.Size(590, 302);
            this.roleDataGrid.TabIndex = 0;
            this.roleDataGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.roleDataGrid_CellMouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnEditRole);
            this.groupBox1.Controls.Add(this.btnRemoveRole);
            this.groupBox1.Controls.Add(this.btnAddRole);
            this.groupBox1.Location = new System.Drawing.Point(73, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 132);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3, 99);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 22);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEditRole
            // 
            this.btnEditRole.Location = new System.Drawing.Point(3, 73);
            this.btnEditRole.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditRole.Name = "btnEditRole";
            this.btnEditRole.Size = new System.Drawing.Size(102, 22);
            this.btnEditRole.TabIndex = 5;
            this.btnEditRole.Text = "Edytuj...";
            this.btnEditRole.UseVisualStyleBackColor = true;
            this.btnEditRole.Click += new System.EventHandler(this.btnEditRole_Click);
            // 
            // btnRemoveRole
            // 
            this.btnRemoveRole.Location = new System.Drawing.Point(3, 47);
            this.btnRemoveRole.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoveRole.Name = "btnRemoveRole";
            this.btnRemoveRole.Size = new System.Drawing.Size(102, 22);
            this.btnRemoveRole.TabIndex = 4;
            this.btnRemoveRole.Text = "Usuń";
            this.btnRemoveRole.UseVisualStyleBackColor = true;
            this.btnRemoveRole.Click += new System.EventHandler(this.btnRemoveRole_Click);
            // 
            // btnAddRole
            // 
            this.btnAddRole.Location = new System.Drawing.Point(3, 21);
            this.btnAddRole.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(102, 22);
            this.btnAddRole.TabIndex = 2;
            this.btnAddRole.Text = "Dodaj...";
            this.btnAddRole.UseVisualStyleBackColor = true;
            this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
            // 
            // maxWageNumeric
            // 
            this.maxWageNumeric.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.maxWageNumeric.Location = new System.Drawing.Point(137, 100);
            this.maxWageNumeric.Name = "maxWageNumeric";
            this.maxWageNumeric.Size = new System.Drawing.Size(105, 23);
            this.maxWageNumeric.TabIndex = 6;
            // 
            // maxWageLabel
            // 
            this.maxWageLabel.AutoSize = true;
            this.maxWageLabel.Location = new System.Drawing.Point(137, 82);
            this.maxWageLabel.Name = "maxWageLabel";
            this.maxWageLabel.Size = new System.Drawing.Size(105, 15);
            this.maxWageLabel.TabIndex = 5;
            this.maxWageLabel.Text = "placa maksymalna";
            // 
            // minWageNumeric
            // 
            this.minWageNumeric.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.minWageNumeric.Location = new System.Drawing.Point(17, 100);
            this.minWageNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.minWageNumeric.Name = "minWageNumeric";
            this.minWageNumeric.Size = new System.Drawing.Size(105, 23);
            this.minWageNumeric.TabIndex = 4;
            // 
            // minWageLabel
            // 
            this.minWageLabel.AutoSize = true;
            this.minWageLabel.Location = new System.Drawing.Point(17, 82);
            this.minWageLabel.Name = "minWageLabel";
            this.minWageLabel.Size = new System.Drawing.Size(95, 15);
            this.minWageLabel.TabIndex = 3;
            this.minWageLabel.Text = "placa minimalna";
            // 
            // roleNameLabel
            // 
            this.roleNameLabel.AutoSize = true;
            this.roleNameLabel.Location = new System.Drawing.Point(17, 22);
            this.roleNameLabel.Name = "roleNameLabel";
            this.roleNameLabel.Size = new System.Drawing.Size(60, 15);
            this.roleNameLabel.TabIndex = 1;
            this.roleNameLabel.Text = "nazwa roli";
            // 
            // roleNameTextBox
            // 
            this.roleNameTextBox.Location = new System.Drawing.Point(17, 40);
            this.roleNameTextBox.Name = "roleNameTextBox";
            this.roleNameTextBox.Size = new System.Drawing.Size(225, 23);
            this.roleNameTextBox.TabIndex = 0;
            // 
            // EmployeeRoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 302);
            this.Controls.Add(this.splitContainer1);
            this.Name = "EmployeeRoleForm";
            this.Text = "EmployeeRoleForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.roleDataGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
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
        private GroupBox groupBox1;
        private Button btnEditRole;
        private Button btnRemoveRole;
        private Button btnAddRole;
        private DataGridView roleDataGrid;
    }
}