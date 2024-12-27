namespace RestaurantSystem
{
    partial class ChefDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChefDashboard));
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnImportHistory = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnReceiveOrders = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.pnlRightContent = new System.Windows.Forms.Panel();
            this.flpTables = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlMainContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.Tan;
            this.pnlSidebar.Controls.Add(this.label1);
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Controls.Add(this.btnImportHistory);
            this.pnlSidebar.Controls.Add(this.btnInventory);
            this.pnlSidebar.Controls.Add(this.btnReceiveOrders);
            this.pnlSidebar.Controls.Add(this.pictureBox1);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(150, 630);
            this.pnlSidebar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 104);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Welcome Chef!";
            // 
            // btnLogout
            // 
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Location = new System.Drawing.Point(38, 398);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(71, 25);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnImportHistory
            // 
            this.btnImportHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportHistory.Location = new System.Drawing.Point(0, 305);
            this.btnImportHistory.Margin = new System.Windows.Forms.Padding(2);
            this.btnImportHistory.Name = "btnImportHistory";
            this.btnImportHistory.Size = new System.Drawing.Size(150, 32);
            this.btnImportHistory.TabIndex = 3;
            this.btnImportHistory.Text = "Import History";
            this.btnImportHistory.UseVisualStyleBackColor = true;
            this.btnImportHistory.Click += new System.EventHandler(this.btnImportHistory_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventory.Location = new System.Drawing.Point(0, 243);
            this.btnInventory.Margin = new System.Windows.Forms.Padding(2);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(150, 32);
            this.btnInventory.TabIndex = 2;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnReceiveOrders
            // 
            this.btnReceiveOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceiveOrders.Location = new System.Drawing.Point(0, 173);
            this.btnReceiveOrders.Margin = new System.Windows.Forms.Padding(2);
            this.btnReceiveOrders.Name = "btnReceiveOrders";
            this.btnReceiveOrders.Size = new System.Drawing.Size(150, 36);
            this.btnReceiveOrders.TabIndex = 1;
            this.btnReceiveOrders.Text = "Receive Orders";
            this.btnReceiveOrders.UseVisualStyleBackColor = true;
            this.btnReceiveOrders.Click += new System.EventHandler(this.btnReceiveOrders_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.Controls.Add(this.pnlRightContent);
            this.pnlMainContent.Controls.Add(this.flpTables);
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(150, 0);
            this.pnlMainContent.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(756, 630);
            this.pnlMainContent.TabIndex = 2;
            // 
            // pnlRightContent
            // 
            this.pnlRightContent.BackColor = System.Drawing.Color.Bisque;
            this.pnlRightContent.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRightContent.Location = new System.Drawing.Point(340, 0);
            this.pnlRightContent.Margin = new System.Windows.Forms.Padding(2);
            this.pnlRightContent.Name = "pnlRightContent";
            this.pnlRightContent.Size = new System.Drawing.Size(416, 630);
            this.pnlRightContent.TabIndex = 3;
            // 
            // flpTables
            // 
            this.flpTables.BackColor = System.Drawing.Color.Bisque;
            this.flpTables.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpTables.Location = new System.Drawing.Point(0, 0);
            this.flpTables.Margin = new System.Windows.Forms.Padding(2);
            this.flpTables.Name = "flpTables";
            this.flpTables.Size = new System.Drawing.Size(340, 630);
            this.flpTables.TabIndex = 2;
            // 
            // ChefDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 630);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.pnlSidebar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ChefDashboard";
            this.Text = "ChefDashboard";
            this.Load += new System.EventHandler(this.ChefDashboard_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlMainContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnImportHistory;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnReceiveOrders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Panel pnlRightContent;
        private System.Windows.Forms.FlowLayoutPanel flpTables;
    }
}