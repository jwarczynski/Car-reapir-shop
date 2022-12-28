namespace WarsztatSamochodowy.Forms
{
    partial class ShoppingListsForm
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
            this.lvShoppingLists = new System.Windows.Forms.ListView();
            this.chListName = new System.Windows.Forms.ColumnHeader();
            this.chPartsCount = new System.Windows.Forms.ColumnHeader();
            this.chListStatus = new System.Windows.Forms.ColumnHeader();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnManageList = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveAutoList = new System.Windows.Forms.Button();
            this.cbAutoList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvShoppingLists
            // 
            this.lvShoppingLists.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chListName,
            this.chPartsCount,
            this.chListStatus});
            this.lvShoppingLists.FullRowSelect = true;
            this.lvShoppingLists.Location = new System.Drawing.Point(12, 12);
            this.lvShoppingLists.MultiSelect = false;
            this.lvShoppingLists.Name = "lvShoppingLists";
            this.lvShoppingLists.Size = new System.Drawing.Size(476, 426);
            this.lvShoppingLists.TabIndex = 0;
            this.lvShoppingLists.View = System.Windows.Forms.View.Details;
            this.lvShoppingLists.ItemActivate += new System.EventHandler(this.lvShoppingLists_ItemActivate);
            this.lvShoppingLists.SelectedIndexChanged += new System.EventHandler(this.lvShoppingLists_SelectedIndexChanged);
            // 
            // chListName
            // 
            this.chListName.Text = "Nazwa listy";
            this.chListName.Width = 220;
            // 
            // chPartsCount
            // 
            this.chPartsCount.Text = "Liczba pozycji";
            this.chPartsCount.Width = 120;
            // 
            // chListStatus
            // 
            this.chListStatus.Text = "Status";
            this.chListStatus.Width = 120;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(494, 12);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(236, 29);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Nowa lista...";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnManageList
            // 
            this.btnManageList.Enabled = false;
            this.btnManageList.Location = new System.Drawing.Point(494, 47);
            this.btnManageList.Name = "btnManageList";
            this.btnManageList.Size = new System.Drawing.Size(236, 29);
            this.btnManageList.TabIndex = 2;
            this.btnManageList.Text = "Zarządzaj listą...";
            this.btnManageList.UseVisualStyleBackColor = true;
            this.btnManageList.Click += new System.EventHandler(this.btnManageList_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSaveAutoList);
            this.groupBox1.Controls.Add(this.cbAutoList);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(494, 291);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 147);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kontrola stanu magazynu";
            // 
            // btnSaveAutoList
            // 
            this.btnSaveAutoList.Location = new System.Drawing.Point(136, 109);
            this.btnSaveAutoList.Name = "btnSaveAutoList";
            this.btnSaveAutoList.Size = new System.Drawing.Size(94, 29);
            this.btnSaveAutoList.TabIndex = 2;
            this.btnSaveAutoList.Text = "Zapisz";
            this.btnSaveAutoList.UseVisualStyleBackColor = true;
            // 
            // cbAutoList
            // 
            this.cbAutoList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAutoList.FormattingEnabled = true;
            this.cbAutoList.Location = new System.Drawing.Point(6, 75);
            this.cbAutoList.Name = "cbAutoList";
            this.cbAutoList.Size = new System.Drawing.Size(224, 28);
            this.cbAutoList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "W razie niskich zapasów, części zapisywane są na liście:";
            // 
            // ShoppingListsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnManageList);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lvShoppingLists);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShoppingListsForm";
            this.Text = "Listy zakupów";
            this.Load += new System.EventHandler(this.ShoppingListsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ListView lvShoppingLists;
        private ColumnHeader chListName;
        private ColumnHeader chPartsCount;
        private ColumnHeader chListStatus;
        private Button btnCreate;
        private Button btnManageList;
        private GroupBox groupBox1;
        private Button btnSaveAutoList;
        private ComboBox cbAutoList;
        private Label label1;
    }
}