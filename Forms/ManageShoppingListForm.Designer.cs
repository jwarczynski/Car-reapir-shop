namespace WarsztatSamochodowy.Forms
{
    partial class ManageShoppingListForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.tbListName = new System.Windows.Forms.TextBox();
            this.btnRename = new System.Windows.Forms.Button();
            this.lvListParts = new System.Windows.Forms.ListView();
            this.chPartName = new System.Windows.Forms.ColumnHeader();
            this.chQuantity = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMoveEntry = new System.Windows.Forms.Button();
            this.btnRemoveEntry = new System.Windows.Forms.Button();
            this.btnEditEntry = new System.Windows.Forms.Button();
            this.btnAddEntry = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnMarkFulfilled = new System.Windows.Forms.Button();
            this.lblFulfillText = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nazwa:";
            // 
            // tbListName
            // 
            this.tbListName.Location = new System.Drawing.Point(75, 6);
            this.tbListName.Name = "tbListName";
            this.tbListName.ReadOnly = true;
            this.tbListName.Size = new System.Drawing.Size(330, 27);
            this.tbListName.TabIndex = 1;
            this.tbListName.ReadOnlyChanged += new System.EventHandler(this.tbListName_ReadOnlyChanged);
            this.tbListName.DoubleClick += new System.EventHandler(this.tbListName_DoubleClick);
            this.tbListName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbListName_KeyPress);
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(411, 5);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(94, 29);
            this.btnRename.TabIndex = 2;
            this.btnRename.Text = "Zmień";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // lvListParts
            // 
            this.lvListParts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPartName,
            this.chQuantity});
            this.lvListParts.FullRowSelect = true;
            this.lvListParts.Location = new System.Drawing.Point(6, 26);
            this.lvListParts.MultiSelect = false;
            this.lvListParts.Name = "lvListParts";
            this.lvListParts.Size = new System.Drawing.Size(322, 200);
            this.lvListParts.TabIndex = 3;
            this.lvListParts.UseCompatibleStateImageBehavior = false;
            this.lvListParts.View = System.Windows.Forms.View.Details;
            this.lvListParts.ItemActivate += new System.EventHandler(this.lvListParts_ItemActivate);
            this.lvListParts.SelectedIndexChanged += new System.EventHandler(this.lvListParts_SelectedIndexChanged);
            // 
            // chPartName
            // 
            this.chPartName.Text = "Nazwa części";
            this.chPartName.Width = 240;
            // 
            // chQuantity
            // 
            this.chQuantity.Text = "Sztuk";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMoveEntry);
            this.groupBox1.Controls.Add(this.btnRemoveEntry);
            this.groupBox1.Controls.Add(this.btnEditEntry);
            this.groupBox1.Controls.Add(this.btnAddEntry);
            this.groupBox1.Controls.Add(this.lvListParts);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(493, 232);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zawartość listy";
            // 
            // btnMoveEntry
            // 
            this.btnMoveEntry.Enabled = false;
            this.btnMoveEntry.Location = new System.Drawing.Point(334, 149);
            this.btnMoveEntry.Name = "btnMoveEntry";
            this.btnMoveEntry.Size = new System.Drawing.Size(151, 29);
            this.btnMoveEntry.TabIndex = 7;
            this.btnMoveEntry.Text = "Przenieś pozycję...";
            this.toolTip1.SetToolTip(this.btnMoveEntry, "Możesz przenosić pozycje między listami o tym samym statusie.");
            this.btnMoveEntry.UseVisualStyleBackColor = true;
            this.btnMoveEntry.Click += new System.EventHandler(this.btnMoveEntry_Click);
            // 
            // btnRemoveEntry
            // 
            this.btnRemoveEntry.Enabled = false;
            this.btnRemoveEntry.Location = new System.Drawing.Point(334, 105);
            this.btnRemoveEntry.Name = "btnRemoveEntry";
            this.btnRemoveEntry.Size = new System.Drawing.Size(151, 29);
            this.btnRemoveEntry.TabIndex = 6;
            this.btnRemoveEntry.Text = "Usuń pozycję";
            this.btnRemoveEntry.UseVisualStyleBackColor = true;
            this.btnRemoveEntry.Click += new System.EventHandler(this.btnRemoveEntry_Click);
            // 
            // btnEditEntry
            // 
            this.btnEditEntry.Enabled = false;
            this.btnEditEntry.Location = new System.Drawing.Point(334, 70);
            this.btnEditEntry.Name = "btnEditEntry";
            this.btnEditEntry.Size = new System.Drawing.Size(151, 29);
            this.btnEditEntry.TabIndex = 5;
            this.btnEditEntry.Text = "Edytuj pozycję...";
            this.btnEditEntry.UseVisualStyleBackColor = true;
            this.btnEditEntry.Click += new System.EventHandler(this.btnEditEntry_Click);
            // 
            // btnAddEntry
            // 
            this.btnAddEntry.Location = new System.Drawing.Point(334, 26);
            this.btnAddEntry.Name = "btnAddEntry";
            this.btnAddEntry.Size = new System.Drawing.Size(151, 29);
            this.btnAddEntry.TabIndex = 4;
            this.btnAddEntry.Text = "Dodaj pozycję...";
            this.btnAddEntry.UseVisualStyleBackColor = true;
            this.btnAddEntry.Click += new System.EventHandler(this.btnAddEntry_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnMarkFulfilled);
            this.groupBox2.Controls.Add(this.lblFulfillText);
            this.groupBox2.Location = new System.Drawing.Point(12, 277);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(493, 113);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status listy";
            // 
            // btnMarkFulfilled
            // 
            this.btnMarkFulfilled.Location = new System.Drawing.Point(268, 75);
            this.btnMarkFulfilled.Name = "btnMarkFulfilled";
            this.btnMarkFulfilled.Size = new System.Drawing.Size(217, 29);
            this.btnMarkFulfilled.TabIndex = 0;
            this.btnMarkFulfilled.Text = "Oznacz jako zrealizowaną";
            this.btnMarkFulfilled.UseVisualStyleBackColor = true;
            this.btnMarkFulfilled.Click += new System.EventHandler(this.btnMarkFulfilled_Click);
            // 
            // lblFulfillText
            // 
            this.lblFulfillText.Location = new System.Drawing.Point(7, 23);
            this.lblFulfillText.Name = "lblFulfillText";
            this.lblFulfillText.Size = new System.Drawing.Size(480, 64);
            this.lblFulfillText.TabIndex = 1;
            this.lblFulfillText.Text = "Możesz oznaczyć tę listę jako zrealizowaną. Spowoduje to dodanie wszystkich zawar" +
    "tych na niej części do stanu magazynu. Operacji tej nie da się wycofać.";
            // 
            // ManageShoppingListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 403);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.tbListName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageShoppingListForm";
            this.Text = "Zarządzaj listą zakupów";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox tbListName;
        private Button btnRename;
        private ListView lvListParts;
        private ColumnHeader chPartName;
        private ColumnHeader chQuantity;
        private GroupBox groupBox1;
        private Button btnMoveEntry;
        private ToolTip toolTip1;
        private Button btnRemoveEntry;
        private Button btnEditEntry;
        private Button btnAddEntry;
        private GroupBox groupBox2;
        private Button btnMarkFulfilled;
        private Label lblFulfillText;
    }
}