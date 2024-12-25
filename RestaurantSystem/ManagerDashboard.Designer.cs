﻿namespace RestaurantSystem
{
    partial class ManagerDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerDashboard));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlSideBar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnBookTable = new System.Windows.Forms.Button();
            this.pnlRightContent = new System.Windows.Forms.Panel();
            this.flpTables = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlSideBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlSideBar
            // 
            this.pnlSideBar.BackColor = System.Drawing.Color.Tan;
            this.pnlSideBar.Controls.Add(this.button2);
            this.pnlSideBar.Controls.Add(this.button1);
            this.pnlSideBar.Controls.Add(this.label1);
            this.pnlSideBar.Controls.Add(this.btnLogout);
            this.pnlSideBar.Controls.Add(this.btnOrder);
            this.pnlSideBar.Controls.Add(this.btnBookTable);
            this.pnlSideBar.Controls.Add(this.pictureBox1);
            this.pnlSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideBar.Location = new System.Drawing.Point(0, 0);
            this.pnlSideBar.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSideBar.Name = "pnlSideBar";
            this.pnlSideBar.Size = new System.Drawing.Size(150, 630);
            this.pnlSideBar.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Welcome Manager!";
            // 
            // btnLogout
            // 
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Location = new System.Drawing.Point(28, 435);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(93, 27);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Log out";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnOrder
            // 
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.Location = new System.Drawing.Point(0, 334);
            this.btnOrder.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(150, 39);
            this.btnOrder.TabIndex = 2;
            this.btnOrder.Text = "Revenue";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnBookTable
            // 
            this.btnBookTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookTable.Location = new System.Drawing.Point(0, 128);
            this.btnBookTable.Margin = new System.Windows.Forms.Padding(2);
            this.btnBookTable.Name = "btnBookTable";
            this.btnBookTable.Size = new System.Drawing.Size(150, 41);
            this.btnBookTable.TabIndex = 1;
            this.btnBookTable.Text = "Payment";
            this.btnBookTable.UseVisualStyleBackColor = true;
            // 
            // pnlRightContent
            // 
            this.pnlRightContent.BackColor = System.Drawing.Color.Bisque;
            this.pnlRightContent.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRightContent.Location = new System.Drawing.Point(489, 0);
            this.pnlRightContent.Margin = new System.Windows.Forms.Padding(2);
            this.pnlRightContent.Name = "pnlRightContent";
            this.pnlRightContent.Size = new System.Drawing.Size(416, 630);
            this.pnlRightContent.TabIndex = 3;
            // 
            // flpTables
            // 
            this.flpTables.BackColor = System.Drawing.Color.Bisque;
            this.flpTables.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpTables.Location = new System.Drawing.Point(150, 0);
            this.flpTables.Margin = new System.Windows.Forms.Padding(2);
            this.flpTables.Name = "flpTables";
            this.flpTables.Size = new System.Drawing.Size(340, 630);
            this.flpTables.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(0, 196);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 41);
            this.button1.TabIndex = 5;
            this.button1.Text = "Employee";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(0, 265);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 41);
            this.button2.TabIndex = 6;
            this.button2.Text = "Employee";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ManagerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(905, 630);
            this.Controls.Add(this.flpTables);
            this.Controls.Add(this.pnlSideBar);
            this.Controls.Add(this.pnlRightContent);
            this.Name = "ManagerDashboard";
            this.Text = "ManagerDashboard";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlSideBar.ResumeLayout(false);
            this.pnlSideBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlSideBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnBookTable;
        private System.Windows.Forms.Panel pnlRightContent;
        private System.Windows.Forms.FlowLayoutPanel flpTables;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}