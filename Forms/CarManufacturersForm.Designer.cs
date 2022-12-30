namespace WarsztatSamochodowy.Forms
{
    partial class CarManufacturersForm
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
            this.lvManufacturersList = new System.Windows.Forms.ListView();
            this.chName = new System.Windows.Forms.ColumnHeader();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvManufacturersList
            // 
            this.lvManufacturersList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName});
            this.lvManufacturersList.FullRowSelect = true;
            this.lvManufacturersList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvManufacturersList.Location = new System.Drawing.Point(12, 12);
            this.lvManufacturersList.MultiSelect = false;
            this.lvManufacturersList.Name = "lvManufacturersList";
            this.lvManufacturersList.Size = new System.Drawing.Size(230, 254);
            this.lvManufacturersList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvManufacturersList.TabIndex = 0;
            this.lvManufacturersList.UseCompatibleStateImageBehavior = false;
            this.lvManufacturersList.View = System.Windows.Forms.View.Details;
            this.lvManufacturersList.ItemActivate += new System.EventHandler(this.lvManufacturersList_ItemActivate);
            this.lvManufacturersList.SelectedIndexChanged += new System.EventHandler(this.lvManufacturersList_SelectedIndexChanged);
            // 
            // chName
            // 
            this.chName.Text = "Nazwa producenta";
            this.chName.Width = 200;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(248, 12);
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
            this.btnEdit.Location = new System.Drawing.Point(248, 47);
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
            this.btnRemove.Location = new System.Drawing.Point(248, 82);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(94, 29);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Usuń";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(248, 237);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 29);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Zamknij";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // CarManufacturersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 279);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvManufacturersList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CarManufacturersForm";
            this.Text = "Producenci samochodów";
            this.Load += new System.EventHandler(this.CarManufacturersForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ListView lvManufacturersList;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnRemove;
        private Button btnClose;
        private ColumnHeader chName;
    }
}