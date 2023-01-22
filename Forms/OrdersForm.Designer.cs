namespace WarsztatSamochodowy.Forms
{
    partial class OrdersForm
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
            this.lvOrders = new System.Windows.Forms.ListView();
            this.chLicensePlate = new System.Windows.Forms.ColumnHeader();
            this.chCustomer = new System.Windows.Forms.ColumnHeader();
            this.chPlacedOn = new System.Windows.Forms.ColumnHeader();
            this.chFinishedOn = new System.Windows.Forms.ColumnHeader();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvOrders
            // 
            this.lvOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chLicensePlate,
            this.chCustomer,
            this.chPlacedOn,
            this.chFinishedOn});
            this.lvOrders.FullRowSelect = true;
            this.lvOrders.Location = new System.Drawing.Point(12, 12);
            this.lvOrders.MultiSelect = false;
            this.lvOrders.Name = "lvOrders";
            this.lvOrders.Size = new System.Drawing.Size(664, 398);
            this.lvOrders.TabIndex = 0;
            this.lvOrders.UseCompatibleStateImageBehavior = false;
            this.lvOrders.View = System.Windows.Forms.View.Details;
            this.lvOrders.ItemActivate += new System.EventHandler(this.lvOrders_ItemActivate);
            this.lvOrders.SelectedIndexChanged += new System.EventHandler(this.lvOrders_SelectedIndexChanged);
            // 
            // chLicensePlate
            // 
            this.chLicensePlate.Text = "Numer rejestracyjny";
            this.chLicensePlate.Width = 150;
            // 
            // chCustomer
            // 
            this.chCustomer.Text = "Klient";
            this.chCustomer.Width = 180;
            // 
            // chPlacedOn
            // 
            this.chPlacedOn.Text = "Data wpłynięcia";
            this.chPlacedOn.Width = 120;
            // 
            // chFinishedOn
            // 
            this.chFinishedOn.Text = "Data końca";
            this.chFinishedOn.Width = 120;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(682, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 29);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Dodaj...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.Enabled = false;
            this.btnDetails.Location = new System.Drawing.Point(682, 47);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(94, 29);
            this.btnDetails.TabIndex = 2;
            this.btnDetails.Text = "Szczegóły...";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // OrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 422);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvOrders);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrdersForm";
            this.Text = "Zamówienia";
            this.Load += new System.EventHandler(this.OrdersForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ListView lvOrders;
        private ColumnHeader chLicensePlate;
        private ColumnHeader chCustomer;
        private ColumnHeader chPlacedOn;
        private ColumnHeader chFinishedOn;
        private Button btnAdd;
        private Button btnDetails;
    }
}