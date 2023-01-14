﻿namespace WarsztatSamochodowy.Forms
{
    partial class EmployeeForm
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
            this.employeesDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEditCustomer = new System.Windows.Forms.Button();
            this.btnRemoveCustomer = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.roleListBox = new System.Windows.Forms.ListBox();
            this.firstNameTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lastNameTextBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.wageTextBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mySqlCommandBuilder1 = new MySqlConnector.MySqlCommandBuilder();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.employeesDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // employeesDataGridView
            // 
            this.employeesDataGridView.AllowUserToDeleteRows = false;
            this.employeesDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.employeesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeesDataGridView.Location = new System.Drawing.Point(11, 14);
            this.employeesDataGridView.MultiSelect = false;
            this.employeesDataGridView.Name = "employeesDataGridView";
            this.employeesDataGridView.RowTemplate.Height = 25;
            this.employeesDataGridView.RowTemplate.ReadOnly = true;
            this.employeesDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.employeesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.employeesDataGridView.Size = new System.Drawing.Size(431, 428);
            this.employeesDataGridView.TabIndex = 0;
            this.employeesDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.employeesDataGridView_CellMouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEditCustomer);
            this.groupBox1.Controls.Add(this.btnRemoveCustomer);
            this.groupBox1.Controls.Add(this.btnAddCustomer);
            this.groupBox1.Location = new System.Drawing.Point(621, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 106);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnEditCustomer
            // 
            this.btnEditCustomer.Location = new System.Drawing.Point(3, 73);
            this.btnEditCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditCustomer.Name = "btnEditCustomer";
            this.btnEditCustomer.Size = new System.Drawing.Size(102, 22);
            this.btnEditCustomer.TabIndex = 5;
            this.btnEditCustomer.Text = "Edytuj...";
            this.btnEditCustomer.UseVisualStyleBackColor = true;
            this.btnEditCustomer.Click += new System.EventHandler(this.btnEditCustomer_Click);
            // 
            // btnRemoveCustomer
            // 
            this.btnRemoveCustomer.Location = new System.Drawing.Point(3, 47);
            this.btnRemoveCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoveCustomer.Name = "btnRemoveCustomer";
            this.btnRemoveCustomer.Size = new System.Drawing.Size(102, 22);
            this.btnRemoveCustomer.TabIndex = 4;
            this.btnRemoveCustomer.Text = "Usuń";
            this.btnRemoveCustomer.UseVisualStyleBackColor = true;
            this.btnRemoveCustomer.Click += new System.EventHandler(this.btnRemoveCustomer_Click);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(3, 21);
            this.btnAddCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(102, 22);
            this.btnAddCustomer.TabIndex = 2;
            this.btnAddCustomer.Text = "Dodaj...";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // roleListBox
            // 
            this.roleListBox.FormattingEnabled = true;
            this.roleListBox.ItemHeight = 15;
            this.roleListBox.Items.AddRange(new object[] {
            "junior worker",
            "senior worker"});
            this.roleListBox.Location = new System.Drawing.Point(461, 218);
            this.roleListBox.Name = "roleListBox";
            this.roleListBox.Size = new System.Drawing.Size(120, 34);
            this.roleListBox.TabIndex = 3;
            this.roleListBox.SelectedIndexChanged += new System.EventHandler(this.roleListBox_SelectedIndexChanged);
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.firstNameTextBox.Location = new System.Drawing.Point(461, 34);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(280, 27);
            this.firstNameTextBox.TabIndex = 4;
            this.firstNameTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(461, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Imię";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(461, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nazwisko";
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lastNameTextBox.Location = new System.Drawing.Point(461, 94);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(280, 27);
            this.lastNameTextBox.TabIndex = 6;
            this.lastNameTextBox.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(461, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Płaca";
            // 
            // wageTextBox
            // 
            this.wageTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.wageTextBox.Location = new System.Drawing.Point(461, 157);
            this.wageTextBox.Name = "wageTextBox";
            this.wageTextBox.Size = new System.Drawing.Size(280, 27);
            this.wageTextBox.TabIndex = 10;
            this.wageTextBox.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(461, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Etat";
            // 
            // mySqlCommandBuilder1
            // 
            this.mySqlCommandBuilder1.DataAdapter = null;
            this.mySqlCommandBuilder1.QuotePrefix = "`";
            this.mySqlCommandBuilder1.QuoteSuffix = "`";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(461, 384);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(281, 52);
            this.button1.TabIndex = 12;
            this.button1.Text = "Zarządzają rolami";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.wageTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.roleListBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.employeesDataGridView);
            this.Name = "EmployeeForm";
            this.Text = "Pracownicy";
            ((System.ComponentModel.ISupportInitialize)(this.employeesDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView employeesDataGridView;
        private GroupBox groupBox1;
        private Button btnAddCustomer;
        private Button btnRemoveCustomer;
        private Button btnEditCustomer;
        private ListBox roleListBox;
        private RichTextBox firstNameTextBox;
        private Label label1;
        private Label label2;
        private RichTextBox lastNameTextBox;
        private Label label3;
        private RichTextBox wageTextBox;
        private Label label4;
        private MySqlConnector.MySqlCommandBuilder mySqlCommandBuilder1;
        private Button button1;
    }
}