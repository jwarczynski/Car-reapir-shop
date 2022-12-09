namespace WarsztatSamochodowy.Forms
{
    partial class WarehouseForm
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
            this.lvPartsList = new System.Windows.Forms.ListView();
            this.chPartName = new System.Windows.Forms.ColumnHeader();
            this.chPartCode = new System.Windows.Forms.ColumnHeader();
            this.chInStock = new System.Windows.Forms.ColumnHeader();
            this.chMaxStock = new System.Windows.Forms.ColumnHeader();
            this.chUnitPrice = new System.Windows.Forms.ColumnHeader();
            this.btnAddPart = new System.Windows.Forms.Button();
            this.btnEditPart = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnShoppingLists = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvPartsList
            // 
            this.lvPartsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPartName,
            this.chPartCode,
            this.chInStock,
            this.chMaxStock,
            this.chUnitPrice});
            this.lvPartsList.Location = new System.Drawing.Point(12, 12);
            this.lvPartsList.Name = "lvPartsList";
            this.lvPartsList.Size = new System.Drawing.Size(695, 426);
            this.lvPartsList.TabIndex = 0;
            this.lvPartsList.UseCompatibleStateImageBehavior = false;
            this.lvPartsList.View = System.Windows.Forms.View.Details;
            // 
            // chPartName
            // 
            this.chPartName.Text = "Nazwa części";
            this.chPartName.Width = 180;
            // 
            // chPartCode
            // 
            this.chPartCode.Text = "Kod części";
            this.chPartCode.Width = 120;
            // 
            // chInStock
            // 
            this.chInStock.Text = "W magazynie";
            this.chInStock.Width = 120;
            // 
            // chMaxStock
            // 
            this.chMaxStock.Text = "Poj. magazynu";
            this.chMaxStock.Width = 120;
            // 
            // chUnitPrice
            // 
            this.chUnitPrice.Text = "Cena jedn.";
            this.chUnitPrice.Width = 120;
            // 
            // btnAddPart
            // 
            this.btnAddPart.Location = new System.Drawing.Point(713, 12);
            this.btnAddPart.Name = "btnAddPart";
            this.btnAddPart.Size = new System.Drawing.Size(94, 29);
            this.btnAddPart.TabIndex = 1;
            this.btnAddPart.Text = "Dodaj...";
            this.btnAddPart.UseVisualStyleBackColor = true;
            this.btnAddPart.Click += new System.EventHandler(this.btnAddPart_Click);
            // 
            // btnEditPart
            // 
            this.btnEditPart.Location = new System.Drawing.Point(713, 91);
            this.btnEditPart.Name = "btnEditPart";
            this.btnEditPart.Size = new System.Drawing.Size(94, 29);
            this.btnEditPart.TabIndex = 2;
            this.btnEditPart.Text = "Edytuj...";
            this.btnEditPart.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(713, 56);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(94, 29);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Usuń";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnShoppingLists
            // 
            this.btnShoppingLists.Location = new System.Drawing.Point(713, 384);
            this.btnShoppingLists.Name = "btnShoppingLists";
            this.btnShoppingLists.Size = new System.Drawing.Size(94, 54);
            this.btnShoppingLists.TabIndex = 4;
            this.btnShoppingLists.Text = "Listy zakupów";
            this.btnShoppingLists.UseVisualStyleBackColor = true;
            this.btnShoppingLists.Click += new System.EventHandler(this.btnShoppingLists_Click);
            // 
            // WarehouseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 450);
            this.Controls.Add(this.btnShoppingLists);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnEditPart);
            this.Controls.Add(this.btnAddPart);
            this.Controls.Add(this.lvPartsList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WarehouseForm";
            this.Text = "Magazyn";
            this.ResumeLayout(false);

        }

        #endregion

        private ListView lvPartsList;
        private ColumnHeader chPartName;
        private ColumnHeader chPartCode;
        private ColumnHeader chInStock;
        private ColumnHeader chMaxStock;
        private ColumnHeader chUnitPrice;
        private Button btnAddPart;
        private Button btnEditPart;
        private Button btnRemove;
        private Button btnShoppingLists;
    }
}