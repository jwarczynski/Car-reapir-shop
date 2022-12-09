namespace WarsztatSamochodowy.Forms
{
    partial class CarsListForm
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
            this.lvCars = new System.Windows.Forms.ListView();
            this.chLicencePlate = new System.Windows.Forms.ColumnHeader();
            this.chManufacturer = new System.Windows.Forms.ColumnHeader();
            this.chModel = new System.Windows.Forms.ColumnHeader();
            this.btnAddCar = new System.Windows.Forms.Button();
            this.btnRemoveCar = new System.Windows.Forms.Button();
            this.btnEditCar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvCars
            // 
            this.lvCars.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chLicencePlate,
            this.chManufacturer,
            this.chModel});
            this.lvCars.Location = new System.Drawing.Point(12, 12);
            this.lvCars.Name = "lvCars";
            this.lvCars.Size = new System.Drawing.Size(488, 426);
            this.lvCars.TabIndex = 0;
            this.lvCars.UseCompatibleStateImageBehavior = false;
            this.lvCars.View = System.Windows.Forms.View.Details;
            // 
            // chLicencePlate
            // 
            this.chLicencePlate.Text = "Numer rejestracyjny";
            this.chLicencePlate.Width = 180;
            // 
            // chManufacturer
            // 
            this.chManufacturer.Text = "Producent";
            this.chManufacturer.Width = 120;
            // 
            // chModel
            // 
            this.chModel.Text = "Model";
            this.chModel.Width = 120;
            // 
            // btnAddCar
            // 
            this.btnAddCar.Location = new System.Drawing.Point(506, 12);
            this.btnAddCar.Name = "btnAddCar";
            this.btnAddCar.Size = new System.Drawing.Size(94, 29);
            this.btnAddCar.TabIndex = 1;
            this.btnAddCar.Text = "Dodaj...";
            this.btnAddCar.UseVisualStyleBackColor = true;
            // 
            // btnRemoveCar
            // 
            this.btnRemoveCar.Location = new System.Drawing.Point(506, 47);
            this.btnRemoveCar.Name = "btnRemoveCar";
            this.btnRemoveCar.Size = new System.Drawing.Size(94, 29);
            this.btnRemoveCar.TabIndex = 2;
            this.btnRemoveCar.Text = "Usuń";
            this.btnRemoveCar.UseVisualStyleBackColor = true;
            // 
            // btnEditCar
            // 
            this.btnEditCar.Location = new System.Drawing.Point(506, 82);
            this.btnEditCar.Name = "btnEditCar";
            this.btnEditCar.Size = new System.Drawing.Size(94, 29);
            this.btnEditCar.TabIndex = 3;
            this.btnEditCar.Text = "Edytuj...";
            this.btnEditCar.UseVisualStyleBackColor = true;
            this.btnEditCar.Click += new System.EventHandler(this.btnEditCar_Click);
            // 
            // CarsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 450);
            this.Controls.Add(this.btnEditCar);
            this.Controls.Add(this.btnRemoveCar);
            this.Controls.Add(this.btnAddCar);
            this.Controls.Add(this.lvCars);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CarsListForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Lista samochodów";
            this.ResumeLayout(false);

        }

        #endregion

        private ListView lvCars;
        private ColumnHeader chLicencePlate;
        private ColumnHeader chManufacturer;
        private ColumnHeader chModel;
        private Button btnAddCar;
        private Button btnRemoveCar;
        private Button btnEditCar;
    }
}