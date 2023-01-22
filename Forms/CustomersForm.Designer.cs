namespace WarsztatSamochodowy.Forms
{
    partial class CustomersForm
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
            this.lvCustomers = new System.Windows.Forms.ListView();
            this.chCustomerName = new System.Windows.Forms.ColumnHeader();
            this.chPhoneNumber = new System.Windows.Forms.ColumnHeader();
            this.chEmailAddress = new System.Windows.Forms.ColumnHeader();
            this.chTaxId = new System.Windows.Forms.ColumnHeader();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.btnEditCustomer = new System.Windows.Forms.Button();
            this.btnRemoveCustomer = new System.Windows.Forms.Button();
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvCustomers
            // 
            this.lvCustomers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCustomerName,
            this.chPhoneNumber,
            this.chEmailAddress,
            this.chTaxId});
            this.lvCustomers.FullRowSelect = true;
            this.lvCustomers.Location = new System.Drawing.Point(12, 12);
            this.lvCustomers.MultiSelect = false;
            this.lvCustomers.Name = "lvCustomers";
            this.lvCustomers.Size = new System.Drawing.Size(628, 426);
            this.lvCustomers.TabIndex = 0;
            this.lvCustomers.UseCompatibleStateImageBehavior = false;
            this.lvCustomers.View = System.Windows.Forms.View.Details;
            this.lvCustomers.ItemActivate += new System.EventHandler(this.lvCustomers_ItemActivate);
            this.lvCustomers.SelectedIndexChanged += new System.EventHandler(this.lvCustomers_SelectedIndexChanged);
            // 
            // chCustomerName
            // 
            this.chCustomerName.Text = "Imię i nazwisko";
            this.chCustomerName.Width = 180;
            // 
            // chPhoneNumber
            // 
            this.chPhoneNumber.Text = "Nr telefonu";
            this.chPhoneNumber.Width = 120;
            // 
            // chEmailAddress
            // 
            this.chEmailAddress.Text = "Adres e-mail";
            this.chEmailAddress.Width = 180;
            // 
            // chTaxId
            // 
            this.chTaxId.Text = "NIP";
            this.chTaxId.Width = 120;
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(646, 12);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(117, 29);
            this.btnAddCustomer.TabIndex = 1;
            this.btnAddCustomer.Text = "Dodaj...";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // btnEditCustomer
            // 
            this.btnEditCustomer.Enabled = false;
            this.btnEditCustomer.Location = new System.Drawing.Point(646, 82);
            this.btnEditCustomer.Name = "btnEditCustomer";
            this.btnEditCustomer.Size = new System.Drawing.Size(117, 29);
            this.btnEditCustomer.TabIndex = 2;
            this.btnEditCustomer.Text = "Edytuj...";
            this.btnEditCustomer.UseVisualStyleBackColor = true;
            this.btnEditCustomer.Click += new System.EventHandler(this.btnEditCustomer_Click);
            // 
            // btnRemoveCustomer
            // 
            this.btnRemoveCustomer.Enabled = false;
            this.btnRemoveCustomer.Location = new System.Drawing.Point(646, 47);
            this.btnRemoveCustomer.Name = "btnRemoveCustomer";
            this.btnRemoveCustomer.Size = new System.Drawing.Size(117, 29);
            this.btnRemoveCustomer.TabIndex = 3;
            this.btnRemoveCustomer.Text = "Usuń";
            this.btnRemoveCustomer.UseVisualStyleBackColor = true;
            this.btnRemoveCustomer.Click += new System.EventHandler(this.btnRemoveCustomer_Click);
            // 
            // btnNewOrder
            // 
            this.btnNewOrder.Location = new System.Drawing.Point(646, 134);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Size = new System.Drawing.Size(117, 50);
            this.btnNewOrder.TabIndex = 4;
            this.btnNewOrder.Text = "Nowe zamówienie...";
            this.btnNewOrder.UseVisualStyleBackColor = true;
            this.btnNewOrder.Click += new System.EventHandler(this.btnNewOrder_Click);
            // 
            // CustomersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 450);
            this.Controls.Add(this.btnNewOrder);
            this.Controls.Add(this.btnRemoveCustomer);
            this.Controls.Add(this.btnEditCustomer);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.lvCustomers);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomersForm";
            this.Text = "Klienci";
            this.Load += new System.EventHandler(this.CustomersForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ListView lvCustomers;
        private ColumnHeader chCustomerName;
        private ColumnHeader chPhoneNumber;
        private ColumnHeader chEmailAddress;
        private ColumnHeader chTaxId;
        private Button btnAddCustomer;
        private Button btnEditCustomer;
        private Button btnRemoveCustomer;
        private Button btnNewOrder;
    }
}