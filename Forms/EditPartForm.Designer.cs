namespace WarsztatSamochodowy.Forms
{
    partial class EditPartForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPartName = new System.Windows.Forms.TextBox();
            this.tbPartCode = new System.Windows.Forms.TextBox();
            this.tbMaxInStock = new System.Windows.Forms.TextBox();
            this.tbUnitPrice = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUnpickPart = new System.Windows.Forms.Button();
            this.btnPickPart = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lvSelectedModels = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.label5 = new System.Windows.Forms.Label();
            this.lvAllModels = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nazwa części:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kod części:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pojemność magazynu:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cena jednostkowa:";
            // 
            // tbPartName
            // 
            this.tbPartName.Location = new System.Drawing.Point(182, 12);
            this.tbPartName.Name = "tbPartName";
            this.tbPartName.Size = new System.Drawing.Size(180, 27);
            this.tbPartName.TabIndex = 4;
            // 
            // tbPartCode
            // 
            this.tbPartCode.Location = new System.Drawing.Point(182, 45);
            this.tbPartCode.Name = "tbPartCode";
            this.tbPartCode.Size = new System.Drawing.Size(180, 27);
            this.tbPartCode.TabIndex = 5;
            // 
            // tbMaxInStock
            // 
            this.tbMaxInStock.Location = new System.Drawing.Point(182, 78);
            this.tbMaxInStock.Name = "tbMaxInStock";
            this.tbMaxInStock.Size = new System.Drawing.Size(180, 27);
            this.tbMaxInStock.TabIndex = 6;
            // 
            // tbUnitPrice
            // 
            this.tbUnitPrice.Location = new System.Drawing.Point(182, 111);
            this.tbUnitPrice.Name = "tbUnitPrice";
            this.tbUnitPrice.Size = new System.Drawing.Size(180, 27);
            this.tbUnitPrice.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUnpickPart);
            this.groupBox1.Controls.Add(this.btnPickPart);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lvSelectedModels);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lvAllModels);
            this.groupBox1.Location = new System.Drawing.Point(12, 144);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 270);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pasuje do samochodów:";
            // 
            // btnUnpickPart
            // 
            this.btnUnpickPart.Enabled = false;
            this.btnUnpickPart.Location = new System.Drawing.Point(210, 81);
            this.btnUnpickPart.Name = "btnUnpickPart";
            this.btnUnpickPart.Size = new System.Drawing.Size(94, 29);
            this.btnUnpickPart.TabIndex = 10;
            this.btnUnpickPart.Text = "<< Usuń";
            this.btnUnpickPart.UseVisualStyleBackColor = true;
            this.btnUnpickPart.Click += new System.EventHandler(this.btnUnpickPart_Click);
            // 
            // btnPickPart
            // 
            this.btnPickPart.Enabled = false;
            this.btnPickPart.Location = new System.Drawing.Point(210, 46);
            this.btnPickPart.Name = "btnPickPart";
            this.btnPickPart.Size = new System.Drawing.Size(94, 29);
            this.btnPickPart.TabIndex = 9;
            this.btnPickPart.Text = "Dodaj >>";
            this.btnPickPart.UseVisualStyleBackColor = true;
            this.btnPickPart.Click += new System.EventHandler(this.btnPickPart_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(310, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Wybrane modele:";
            // 
            // lvSelectedModels
            // 
            this.lvSelectedModels.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvSelectedModels.FullRowSelect = true;
            this.lvSelectedModels.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvSelectedModels.Location = new System.Drawing.Point(310, 46);
            this.lvSelectedModels.Name = "lvSelectedModels";
            this.lvSelectedModels.Size = new System.Drawing.Size(200, 218);
            this.lvSelectedModels.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvSelectedModels.TabIndex = 2;
            this.lvSelectedModels.UseCompatibleStateImageBehavior = false;
            this.lvSelectedModels.View = System.Windows.Forms.View.Details;
            this.lvSelectedModels.ItemActivate += new System.EventHandler(this.lvSelectedModels_ItemActivate);
            this.lvSelectedModels.SelectedIndexChanged += new System.EventHandler(this.lvSelectedModels_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Model";
            this.columnHeader2.Width = 170;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Wszystkie modele:";
            // 
            // lvAllModels
            // 
            this.lvAllModels.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvAllModels.FullRowSelect = true;
            this.lvAllModels.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvAllModels.Location = new System.Drawing.Point(4, 46);
            this.lvAllModels.Name = "lvAllModels";
            this.lvAllModels.Size = new System.Drawing.Size(200, 218);
            this.lvAllModels.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvAllModels.TabIndex = 0;
            this.lvAllModels.UseCompatibleStateImageBehavior = false;
            this.lvAllModels.View = System.Windows.Forms.View.Details;
            this.lvAllModels.ItemActivate += new System.EventHandler(this.lvAllModels_ItemActivate);
            this.lvAllModels.SelectedIndexChanged += new System.EventHandler(this.lvAllModels_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Model";
            this.columnHeader1.Width = 170;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(435, 420);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(335, 420);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 29);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Zapisz";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // EditPartForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(539, 458);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbUnitPrice);
            this.Controls.Add(this.tbMaxInStock);
            this.Controls.Add(this.tbPartCode);
            this.Controls.Add(this.tbPartName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditPartForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Część";
            this.Load += new System.EventHandler(this.EditPartForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox tbPartName;
        private TextBox tbPartCode;
        private TextBox tbMaxInStock;
        private TextBox tbUnitPrice;
        private GroupBox groupBox1;
        private Button btnUnpickPart;
        private Button btnPickPart;
        private Label label6;
        private ListView lvSelectedModels;
        private Label label5;
        private ListView lvAllModels;
        private Button btnCancel;
        private Button btnSave;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
    }
}