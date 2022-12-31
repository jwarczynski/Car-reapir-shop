namespace WarsztatSamochodowy.Forms
{
    partial class CarModelsForm
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
            this.lvModels = new System.Windows.Forms.ListView();
            this.chName = new System.Windows.Forms.ColumnHeader();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnShowManufacturers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvModels
            // 
            this.lvModels.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName});
            this.lvModels.FullRowSelect = true;
            this.lvModels.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvModels.Location = new System.Drawing.Point(12, 12);
            this.lvModels.MultiSelect = false;
            this.lvModels.Name = "lvModels";
            this.lvModels.Size = new System.Drawing.Size(262, 269);
            this.lvModels.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvModels.TabIndex = 0;
            this.lvModels.UseCompatibleStateImageBehavior = false;
            this.lvModels.View = System.Windows.Forms.View.Details;
            this.lvModels.ItemActivate += new System.EventHandler(this.lvModels_ItemActivate);
            this.lvModels.SelectedIndexChanged += new System.EventHandler(this.lvModels_SelectedIndexChanged);
            // 
            // chName
            // 
            this.chName.Text = "Producent i model";
            this.chName.Width = 230;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(280, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 29);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Dodaj...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(280, 47);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(94, 29);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edytuj...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(280, 82);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(94, 29);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Usuń";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnShowManufacturers
            // 
            this.btnShowManufacturers.Location = new System.Drawing.Point(280, 252);
            this.btnShowManufacturers.Name = "btnShowManufacturers";
            this.btnShowManufacturers.Size = new System.Drawing.Size(94, 29);
            this.btnShowManufacturers.TabIndex = 4;
            this.btnShowManufacturers.Text = "Producenci";
            this.btnShowManufacturers.UseVisualStyleBackColor = true;
            this.btnShowManufacturers.Click += new System.EventHandler(this.btnShowManufacturers_Click);
            // 
            // CarModelsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 293);
            this.Controls.Add(this.btnShowManufacturers);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvModels);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CarModelsForm";
            this.Text = "Modele samochodów";
            this.Load += new System.EventHandler(this.CarModelsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ListView lvModels;
        private ColumnHeader chName;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnRemove;
        private Button btnShowManufacturers;
    }
}