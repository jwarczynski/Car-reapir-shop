namespace WarsztatSamochodowy.Forms
{
    partial class EditOrderEntryForm
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
            this.gbEmployee = new System.Windows.Forms.GroupBox();
            this.btnMarkDone = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveEmployee = new System.Windows.Forms.Button();
            this.cbEmployee = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbComment = new System.Windows.Forms.GroupBox();
            this.btnSaveComment = new System.Windows.Forms.Button();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.gbService = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ckIndividualPrice = new System.Windows.Forms.CheckBox();
            this.tbCost = new System.Windows.Forms.TextBox();
            this.btnSaveService = new System.Windows.Forms.Button();
            this.cbService = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbEmployee.SuspendLayout();
            this.gbComment.SuspendLayout();
            this.gbService.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEmployee
            // 
            this.gbEmployee.Controls.Add(this.btnMarkDone);
            this.gbEmployee.Controls.Add(this.lblDate);
            this.gbEmployee.Controls.Add(this.label2);
            this.gbEmployee.Controls.Add(this.btnSaveEmployee);
            this.gbEmployee.Controls.Add(this.cbEmployee);
            this.gbEmployee.Controls.Add(this.label1);
            this.gbEmployee.Location = new System.Drawing.Point(268, 12);
            this.gbEmployee.Name = "gbEmployee";
            this.gbEmployee.Size = new System.Drawing.Size(413, 116);
            this.gbEmployee.TabIndex = 0;
            this.gbEmployee.TabStop = false;
            this.gbEmployee.Text = "Wykonawca";
            // 
            // btnMarkDone
            // 
            this.btnMarkDone.Enabled = false;
            this.btnMarkDone.Location = new System.Drawing.Point(207, 80);
            this.btnMarkDone.Name = "btnMarkDone";
            this.btnMarkDone.Size = new System.Drawing.Size(200, 29);
            this.btnMarkDone.TabIndex = 5;
            this.btnMarkDone.Text = "Oznacz jako wykonane";
            this.btnMarkDone.UseVisualStyleBackColor = true;
            this.btnMarkDone.Click += new System.EventHandler(this.btnMarkDone_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(130, 57);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(100, 20);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "nie wykonano";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Data wykonania:";
            // 
            // btnSaveEmployee
            // 
            this.btnSaveEmployee.Location = new System.Drawing.Point(313, 26);
            this.btnSaveEmployee.Name = "btnSaveEmployee";
            this.btnSaveEmployee.Size = new System.Drawing.Size(94, 29);
            this.btnSaveEmployee.TabIndex = 2;
            this.btnSaveEmployee.Text = "Zapisz";
            this.btnSaveEmployee.UseVisualStyleBackColor = true;
            this.btnSaveEmployee.Click += new System.EventHandler(this.btnSaveEmployee_Click);
            // 
            // cbEmployee
            // 
            this.cbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmployee.FormattingEnabled = true;
            this.cbEmployee.Location = new System.Drawing.Point(91, 26);
            this.cbEmployee.Name = "cbEmployee";
            this.cbEmployee.Size = new System.Drawing.Size(216, 28);
            this.cbEmployee.TabIndex = 1;
            this.cbEmployee.SelectedIndexChanged += new System.EventHandler(this.cbEmployee_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pracownik:";
            // 
            // gbComment
            // 
            this.gbComment.Controls.Add(this.btnSaveComment);
            this.gbComment.Controls.Add(this.tbComment);
            this.gbComment.Location = new System.Drawing.Point(268, 134);
            this.gbComment.Name = "gbComment";
            this.gbComment.Size = new System.Drawing.Size(413, 125);
            this.gbComment.TabIndex = 1;
            this.gbComment.TabStop = false;
            this.gbComment.Text = "Komentarz";
            // 
            // btnSaveComment
            // 
            this.btnSaveComment.Location = new System.Drawing.Point(313, 90);
            this.btnSaveComment.Name = "btnSaveComment";
            this.btnSaveComment.Size = new System.Drawing.Size(94, 29);
            this.btnSaveComment.TabIndex = 11;
            this.btnSaveComment.Text = "Zapisz";
            this.btnSaveComment.UseVisualStyleBackColor = true;
            this.btnSaveComment.Click += new System.EventHandler(this.btnSaveComment_Click);
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(6, 26);
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(401, 58);
            this.tbComment.TabIndex = 0;
            // 
            // gbService
            // 
            this.gbService.Controls.Add(this.groupBox4);
            this.gbService.Controls.Add(this.btnSaveService);
            this.gbService.Controls.Add(this.cbService);
            this.gbService.Controls.Add(this.label3);
            this.gbService.Location = new System.Drawing.Point(12, 12);
            this.gbService.Name = "gbService";
            this.gbService.Size = new System.Drawing.Size(250, 247);
            this.gbService.TabIndex = 2;
            this.gbService.TabStop = false;
            this.gbService.Text = "Usługa";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ckIndividualPrice);
            this.groupBox4.Controls.Add(this.tbCost);
            this.groupBox4.Location = new System.Drawing.Point(6, 80);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(238, 94);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Cena";
            // 
            // ckIndividualPrice
            // 
            this.ckIndividualPrice.AutoSize = true;
            this.ckIndividualPrice.Location = new System.Drawing.Point(6, 26);
            this.ckIndividualPrice.Name = "ckIndividualPrice";
            this.ckIndividualPrice.Size = new System.Drawing.Size(157, 24);
            this.ckIndividualPrice.TabIndex = 7;
            this.ckIndividualPrice.Text = "Indywidualna cena:";
            this.ckIndividualPrice.UseVisualStyleBackColor = true;
            this.ckIndividualPrice.CheckedChanged += new System.EventHandler(this.ckIndividualPrice_CheckedChanged);
            // 
            // tbCost
            // 
            this.tbCost.Location = new System.Drawing.Point(28, 56);
            this.tbCost.Name = "tbCost";
            this.tbCost.ReadOnly = true;
            this.tbCost.Size = new System.Drawing.Size(204, 27);
            this.tbCost.TabIndex = 9;
            // 
            // btnSaveService
            // 
            this.btnSaveService.Location = new System.Drawing.Point(150, 212);
            this.btnSaveService.Name = "btnSaveService";
            this.btnSaveService.Size = new System.Drawing.Size(94, 29);
            this.btnSaveService.TabIndex = 10;
            this.btnSaveService.Text = "Zapisz";
            this.btnSaveService.UseVisualStyleBackColor = true;
            this.btnSaveService.Click += new System.EventHandler(this.btnSaveService_Click);
            // 
            // cbService
            // 
            this.cbService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbService.FormattingEnabled = true;
            this.cbService.Location = new System.Drawing.Point(6, 46);
            this.cbService.Name = "cbService";
            this.cbService.Size = new System.Drawing.Size(238, 28);
            this.cbService.TabIndex = 6;
            this.cbService.SelectedIndexChanged += new System.EventHandler(this.cbService_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nazwa usługi:";
            // 
            // EditOrderEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 268);
            this.Controls.Add(this.gbService);
            this.Controls.Add(this.gbComment);
            this.Controls.Add(this.gbEmployee);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditOrderEntryForm";
            this.Text = "Pozycja zamówienia";
            this.Load += new System.EventHandler(this.EditOrderEntryForm_Load);
            this.gbEmployee.ResumeLayout(false);
            this.gbEmployee.PerformLayout();
            this.gbComment.ResumeLayout(false);
            this.gbComment.PerformLayout();
            this.gbService.ResumeLayout(false);
            this.gbService.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox gbEmployee;
        private Button btnMarkDone;
        private Label lblDate;
        private Label label2;
        private Button btnSaveEmployee;
        private ComboBox cbEmployee;
        private Label label1;
        private GroupBox gbComment;
        private GroupBox gbService;
        private Button btnSaveService;
        private TextBox tbCost;
        private CheckBox ckIndividualPrice;
        private ComboBox cbService;
        private Label label3;
        private GroupBox groupBox4;
        private Button btnSaveComment;
        private TextBox tbComment;
    }
}