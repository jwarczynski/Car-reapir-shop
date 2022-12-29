namespace WarsztatSamochodowy.Forms
{
    partial class PickShoppingListForm
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
            this.btnPick = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lvShoppingLists = new System.Windows.Forms.ListView();
            this.chListName = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // btnPick
            // 
            this.btnPick.Enabled = false;
            this.btnPick.Location = new System.Drawing.Point(53, 245);
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(94, 29);
            this.btnPick.TabIndex = 0;
            this.btnPick.Text = "Wybierz";
            this.btnPick.UseVisualStyleBackColor = true;
            this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(153, 245);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lvShoppingLists
            // 
            this.lvShoppingLists.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chListName});
            this.lvShoppingLists.FullRowSelect = true;
            this.lvShoppingLists.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvShoppingLists.Location = new System.Drawing.Point(12, 12);
            this.lvShoppingLists.Name = "lvShoppingLists";
            this.lvShoppingLists.Size = new System.Drawing.Size(235, 227);
            this.lvShoppingLists.TabIndex = 2;
            this.lvShoppingLists.UseCompatibleStateImageBehavior = false;
            this.lvShoppingLists.View = System.Windows.Forms.View.Details;
            this.lvShoppingLists.ItemActivate += new System.EventHandler(this.lvShoppingLists_ItemActivate);
            this.lvShoppingLists.SelectedIndexChanged += new System.EventHandler(this.lvShoppingLists_SelectedIndexChanged);
            // 
            // chListName
            // 
            this.chListName.Text = "Nazwa listy";
            this.chListName.Width = 200;
            // 
            // PickShoppingListForm
            // 
            this.AcceptButton = this.btnPick;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(261, 282);
            this.Controls.Add(this.lvShoppingLists);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPick);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PickShoppingListForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Wybierz listę zakupów";
            this.Load += new System.EventHandler(this.PickShoppingListForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnPick;
        private Button btnCancel;
        private ListView lvShoppingLists;
        private ColumnHeader chListName;
    }
}