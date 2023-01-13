namespace WarsztatSamochodowy.Forms
{
    partial class EditServiceForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbPartCounter = new System.Windows.Forms.ListBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lbSelectedParts = new System.Windows.Forms.ListBox();
            this.clbAllParts = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbStandardPrice = new System.Windows.Forms.TextBox();
            this.tbServiceName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBoxSelectedModels = new System.Windows.Forms.ListBox();
            this.chckListBoxAllModels = new System.Windows.Forms.CheckedListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(418, 436);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 29);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Zapisz";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(543, 436);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbPartCounter);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.lbSelectedParts);
            this.groupBox1.Controls.Add(this.clbAllParts);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(11, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(573, 315);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Potrzebne części:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(465, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Zmień Ilość:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(373, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Ilość:";
            // 
            // lbPartCounter
            // 
            this.lbPartCounter.FormattingEnabled = true;
            this.lbPartCounter.ItemHeight = 20;
            this.lbPartCounter.Location = new System.Drawing.Point(373, 60);
            this.lbPartCounter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbPartCounter.Name = "lbPartCounter";
            this.lbPartCounter.Size = new System.Drawing.Size(82, 244);
            this.lbPartCounter.TabIndex = 14;
            this.lbPartCounter.SelectedIndexChanged += new System.EventHandler(this.lbPartCounter_SelectedIndexChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(465, 60);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(94, 27);
            this.numericUpDown1.TabIndex = 13;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // lbSelectedParts
            // 
            this.lbSelectedParts.Enabled = false;
            this.lbSelectedParts.FormattingEnabled = true;
            this.lbSelectedParts.ItemHeight = 20;
            this.lbSelectedParts.Location = new System.Drawing.Point(193, 60);
            this.lbSelectedParts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbSelectedParts.Name = "lbSelectedParts";
            this.lbSelectedParts.Size = new System.Drawing.Size(172, 244);
            this.lbSelectedParts.TabIndex = 12;
            // 
            // clbAllParts
            // 
            this.clbAllParts.CheckOnClick = true;
            this.clbAllParts.FormattingEnabled = true;
            this.clbAllParts.Location = new System.Drawing.Point(13, 60);
            this.clbAllParts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.clbAllParts.Name = "clbAllParts";
            this.clbAllParts.Size = new System.Drawing.Size(173, 224);
            this.clbAllParts.TabIndex = 11;
            this.clbAllParts.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(193, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Wybrane części:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Wszystkie części:";
            // 
            // tbStandardPrice
            // 
            this.tbStandardPrice.Location = new System.Drawing.Point(543, 45);
            this.tbStandardPrice.Name = "tbStandardPrice";
            this.tbStandardPrice.Size = new System.Drawing.Size(180, 27);
            this.tbStandardPrice.TabIndex = 18;
            // 
            // tbServiceName
            // 
            this.tbServiceName.Location = new System.Drawing.Point(331, 45);
            this.tbServiceName.Name = "tbServiceName";
            this.tbServiceName.Size = new System.Drawing.Size(180, 27);
            this.tbServiceName.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(543, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Cena standardowa:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(331, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nazwa usługi:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBoxSelectedModels);
            this.groupBox2.Controls.Add(this.chckListBoxAllModels);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(606, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(378, 315);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dostępna dla modeli samochodów";
            // 
            // listBoxSelectedModels
            // 
            this.listBoxSelectedModels.Enabled = false;
            this.listBoxSelectedModels.FormattingEnabled = true;
            this.listBoxSelectedModels.ItemHeight = 20;
            this.listBoxSelectedModels.Location = new System.Drawing.Point(193, 60);
            this.listBoxSelectedModels.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBoxSelectedModels.Name = "listBoxSelectedModels";
            this.listBoxSelectedModels.Size = new System.Drawing.Size(172, 244);
            this.listBoxSelectedModels.TabIndex = 12;
            // 
            // chckListBoxAllModels
            // 
            this.chckListBoxAllModels.CheckOnClick = true;
            this.chckListBoxAllModels.FormattingEnabled = true;
            this.chckListBoxAllModels.Location = new System.Drawing.Point(13, 60);
            this.chckListBoxAllModels.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chckListBoxAllModels.Name = "chckListBoxAllModels";
            this.chckListBoxAllModels.Size = new System.Drawing.Size(173, 224);
            this.chckListBoxAllModels.TabIndex = 11;
            this.chckListBoxAllModels.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxAllModels_ItemCheck);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(193, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 20);
            this.label9.TabIndex = 3;
            this.label9.Text = "wybrane modele";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "Wszystkie modele";
            // 
            // EditServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 480);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbStandardPrice);
            this.Controls.Add(this.tbServiceName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EditServiceForm";
            this.Text = "EditServiceForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnSave;
        private Button btnCancel;
        private GroupBox groupBox1;
        private Label label6;
        private ListView lvSelectedModels;
        private Label label5;
        private TextBox tbStandardPrice;
        private TextBox tbServiceName;
        private Label label4;
        private Label label1;
        private CheckedListBox checkedListBox1;
        private ListView lvSelectedParts;
        private CheckedListBox clbAllParts;
        private ListBox lbSelectedParts;
        private NumericUpDown numericUpDown1;
        private Label label2;
        private ListBox lbPartCounter;
        private Label label3;
        private GroupBox groupBox2;
        private ListBox listBoxSelectedModels;
        private CheckedListBox chckListBoxAllModels;
        private Label label9;
        private Label label10;
    }
}