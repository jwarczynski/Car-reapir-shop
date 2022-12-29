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
            this.serviceDataGridView.AllowUserToAddRows = false;
            this.serviceDataGridView.AllowUserToDeleteRows = false;
            this.serviceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.serviceDataGridView.Location = new System.Drawing.Point(12, 14);
            this.serviceDataGridView.Name = "serviceDataGridView";
            this.serviceDataGridView.ReadOnly = true;
            this.serviceDataGridView.RowTemplate.Height = 25;
            this.serviceDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.serviceDataGridView.Size = new System.Drawing.Size(271, 424);
            this.serviceDataGridView.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEditSerivce);
            this.groupBox1.Controls.Add(this.btnRemoveService);
            this.groupBox1.Controls.Add(this.btnAddService);
            this.groupBox1.Location = new System.Drawing.Point(299, 14);
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
            this.btnEditSerivce.Click += new System.EventHandler(this.btnEditSerivce_Click);
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
            this.btnRemoveService.Click += new System.EventHandler(this.btnRemoveService_Click);
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
            this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
            // 
            // ServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.serviceDataGridView);
            this.Name = "ServiceForm";
            this.Text = "ServiceForm";
            ((System.ComponentModel.ISupportInitialize)(this.serviceDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView serviceDataGridView;
        private GroupBox groupBox1;
        private Button btnEditSerivce;
        private Button btnRemoveService;
        private Button btnAddService;
    }
}