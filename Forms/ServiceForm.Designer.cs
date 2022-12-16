namespace WarsztatSamochodowy.Forms
{
    partial class ServiceForm
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
            this.serviceDataGridView = new System.Windows.Forms.DataGridView();
            this.label_price = new System.Windows.Forms.Label();
            this.lastNameTextBox = new System.Windows.Forms.RichTextBox();
            this.label_name = new System.Windows.Forms.Label();
            this.firstNameTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEditSerivce = new System.Windows.Forms.Button();
            this.btnRemoveService = new System.Windows.Forms.Button();
            this.btnAddService = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.serviceDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serviceDataGridView
            // 
            this.serviceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.serviceDataGridView.Location = new System.Drawing.Point(12, 14);
            this.serviceDataGridView.Name = "serviceDataGridView";
            this.serviceDataGridView.RowTemplate.Height = 25;
            this.serviceDataGridView.Size = new System.Drawing.Size(271, 424);
            this.serviceDataGridView.TabIndex = 0;
            // 
            // label_price
            // 
            this.label_price.AutoSize = true;
            this.label_price.Location = new System.Drawing.Point(299, 76);
            this.label_price.Name = "label_price";
            this.label_price.Size = new System.Drawing.Size(105, 15);
            this.label_price.TabIndex = 11;
            this.label_price.Text = "Cena standardowa";
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lastNameTextBox.Location = new System.Drawing.Point(299, 94);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(280, 27);
            this.lastNameTextBox.TabIndex = 10;
            this.lastNameTextBox.Text = "";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(299, 16);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(42, 15);
            this.label_name.TabIndex = 9;
            this.label_name.Text = "Nazwa";
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.firstNameTextBox.Location = new System.Drawing.Point(299, 34);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(280, 27);
            this.firstNameTextBox.TabIndex = 8;
            this.firstNameTextBox.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEditSerivce);
            this.groupBox1.Controls.Add(this.btnRemoveService);
            this.groupBox1.Controls.Add(this.btnAddService);
            this.groupBox1.Location = new System.Drawing.Point(464, 332);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(115, 106);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // btnEditSerivce
            // 
            this.btnEditSerivce.Location = new System.Drawing.Point(7, 73);
            this.btnEditSerivce.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditSerivce.Name = "btnEditSerivce";
            this.btnEditSerivce.Size = new System.Drawing.Size(102, 22);
            this.btnEditSerivce.TabIndex = 5;
            this.btnEditSerivce.Text = "Edytuj...";
            this.btnEditSerivce.UseVisualStyleBackColor = true;
            // 
            // btnRemoveService
            // 
            this.btnRemoveService.Location = new System.Drawing.Point(7, 47);
            this.btnRemoveService.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoveService.Name = "btnRemoveService";
            this.btnRemoveService.Size = new System.Drawing.Size(102, 22);
            this.btnRemoveService.TabIndex = 4;
            this.btnRemoveService.Text = "Usuń";
            this.btnRemoveService.UseVisualStyleBackColor = true;
            // 
            // btnAddService
            // 
            this.btnAddService.Location = new System.Drawing.Point(7, 21);
            this.btnAddService.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(102, 22);
            this.btnAddService.TabIndex = 2;
            this.btnAddService.Text = "Dodaj...";
            this.btnAddService.UseVisualStyleBackColor = true;
            // 
            // ServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_price);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.serviceDataGridView);
            this.Name = "ServiceForm";
            this.Text = "ServiceForm";
            ((System.ComponentModel.ISupportInitialize)(this.serviceDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView serviceDataGridView;
        private Label label_price;
        private RichTextBox lastNameTextBox;
        private Label label_name;
        private RichTextBox firstNameTextBox;
        private GroupBox groupBox1;
        private Button btnEditSerivce;
        private Button btnRemoveService;
        private Button btnAddService;
    }
}