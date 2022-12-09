﻿namespace WarsztatSamochodowy.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCarManufacturers = new System.Windows.Forms.Button();
            this.btnCarModels = new System.Windows.Forms.Button();
            this.btnAllCars = new System.Windows.Forms.Button();
            this.btnCustomersList = new System.Windows.Forms.Button();
            this.btnShoppingLists = new System.Windows.Forms.Button();
            this.btnWarehouse = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCarManufacturers);
            this.groupBox1.Controls.Add(this.btnCarModels);
            this.groupBox1.Controls.Add(this.btnAllCars);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 133);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Samochody";
            // 
            // btnCarManufacturers
            // 
            this.btnCarManufacturers.Location = new System.Drawing.Point(6, 96);
            this.btnCarManufacturers.Name = "btnCarManufacturers";
            this.btnCarManufacturers.Size = new System.Drawing.Size(184, 29);
            this.btnCarManufacturers.TabIndex = 3;
            this.btnCarManufacturers.Text = "Zarządzaj producentami";
            this.btnCarManufacturers.UseVisualStyleBackColor = true;
            // 
            // btnCarModels
            // 
            this.btnCarModels.Location = new System.Drawing.Point(6, 61);
            this.btnCarModels.Name = "btnCarModels";
            this.btnCarModels.Size = new System.Drawing.Size(184, 29);
            this.btnCarModels.TabIndex = 2;
            this.btnCarModels.Text = "Zarządzaj modelami";
            this.btnCarModels.UseVisualStyleBackColor = true;
            // 
            // btnAllCars
            // 
            this.btnAllCars.Location = new System.Drawing.Point(6, 26);
            this.btnAllCars.Name = "btnAllCars";
            this.btnAllCars.Size = new System.Drawing.Size(184, 29);
            this.btnAllCars.TabIndex = 1;
            this.btnAllCars.Text = "Wyświetl wszystkie";
            this.btnAllCars.UseVisualStyleBackColor = true;
            this.btnAllCars.Click += new System.EventHandler(this.btnAllCars_Click);
            // 
            // btnCustomersList
            // 
            this.btnCustomersList.Location = new System.Drawing.Point(249, 38);
            this.btnCustomersList.Name = "btnCustomersList";
            this.btnCustomersList.Size = new System.Drawing.Size(146, 29);
            this.btnCustomersList.TabIndex = 1;
            this.btnCustomersList.Text = "Lista klientów";
            this.btnCustomersList.UseVisualStyleBackColor = true;
            this.btnCustomersList.Click += new System.EventHandler(this.btnCustomersList_Click);
            // 
            // btnShoppingLists
            // 
            this.btnShoppingLists.Location = new System.Drawing.Point(249, 73);
            this.btnShoppingLists.Name = "btnShoppingLists";
            this.btnShoppingLists.Size = new System.Drawing.Size(146, 29);
            this.btnShoppingLists.TabIndex = 2;
            this.btnShoppingLists.Text = "Listy zakupów";
            this.btnShoppingLists.UseVisualStyleBackColor = true;
            this.btnShoppingLists.Click += new System.EventHandler(this.btnShoppingLists_Click);
            // 
            // btnWarehouse
            // 
            this.btnWarehouse.Location = new System.Drawing.Point(249, 108);
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.Size = new System.Drawing.Size(146, 29);
            this.btnWarehouse.TabIndex = 3;
            this.btnWarehouse.Text = "Magazyn";
            this.btnWarehouse.UseVisualStyleBackColor = true;
            this.btnWarehouse.Click += new System.EventHandler(this.btnWarehouse_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnWarehouse);
            this.Controls.Add(this.btnShoppingLists);
            this.Controls.Add(this.btnCustomersList);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Warsztat samochodowy";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Button btnAllCars;
        private Button btnCarManufacturers;
        private Button btnCarModels;
        private Button btnCustomersList;
        private Button btnShoppingLists;
        private Button btnWarehouse;
    }
}