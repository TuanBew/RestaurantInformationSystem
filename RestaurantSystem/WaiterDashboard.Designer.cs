namespace RestaurantSystem
{
    partial class WaiterDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaiterDashboard));
            this.pnlSideBar = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnBookTable = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlTableGrid = new System.Windows.Forms.Panel();
            this.pnlRightContent = new System.Windows.Forms.Panel();
            this.flpTables = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlTableGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSideBar
            // 
            this.pnlSideBar.BackColor = System.Drawing.Color.Tan;
            this.pnlSideBar.Controls.Add(this.label1);
            this.pnlSideBar.Controls.Add(this.btnLogout);
            this.pnlSideBar.Controls.Add(this.btnOrder);
            this.pnlSideBar.Controls.Add(this.btnBookTable);
            this.pnlSideBar.Controls.Add(this.pictureBox1);
            this.pnlSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideBar.Location = new System.Drawing.Point(0, 0);
            this.pnlSideBar.Name = "pnlSideBar";
            this.pnlSideBar.Size = new System.Drawing.Size(200, 776);
            this.pnlSideBar.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Location = new System.Drawing.Point(38, 535);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(124, 33);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Log out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click_1);
            // 
            // btnOrder
            // 
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.Location = new System.Drawing.Point(0, 327);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(200, 48);
            this.btnOrder.TabIndex = 2;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click_1);
            // 
            // btnBookTable
            // 
            this.btnBookTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookTable.Location = new System.Drawing.Point(0, 222);
            this.btnBookTable.Name = "btnBookTable";
            this.btnBookTable.Size = new System.Drawing.Size(200, 50);
            this.btnBookTable.TabIndex = 1;
            this.btnBookTable.Text = "Book Table";
            this.btnBookTable.UseVisualStyleBackColor = true;
            this.btnBookTable.Click += new System.EventHandler(this.btnBookTable_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlTableGrid
            // 
            this.pnlTableGrid.BackColor = System.Drawing.Color.LightGray;
            this.pnlTableGrid.Controls.Add(this.pnlRightContent);
            this.pnlTableGrid.Controls.Add(this.flpTables);
            this.pnlTableGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTableGrid.Location = new System.Drawing.Point(200, 0);
            this.pnlTableGrid.Name = "pnlTableGrid";
            this.pnlTableGrid.Size = new System.Drawing.Size(874, 776);
            this.pnlTableGrid.TabIndex = 1;
            // 
            // pnlRightContent
            // 
            this.pnlRightContent.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRightContent.Location = new System.Drawing.Point(320, 0);
            this.pnlRightContent.Name = "pnlRightContent";
            this.pnlRightContent.Size = new System.Drawing.Size(554, 776);
            this.pnlRightContent.TabIndex = 1;
            this.pnlRightContent.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlRightContent_Paint);
            // 
            // flpTables
            // 
            this.flpTables.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpTables.Location = new System.Drawing.Point(0, 0);
            this.flpTables.Name = "flpTables";
            this.flpTables.Size = new System.Drawing.Size(453, 776);
            this.flpTables.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Welcome Waiter!";
            // 
            // WaiterDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 776);
            this.Controls.Add(this.pnlTableGrid);
            this.Controls.Add(this.pnlSideBar);
            this.Name = "WaiterDashboard";
            this.Text = "WaiterDashboard";
            this.Load += new System.EventHandler(this.WaiterDashboard_Load);
            this.pnlSideBar.ResumeLayout(false);
            this.pnlSideBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlTableGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSideBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnBookTable;
        private System.Windows.Forms.Panel pnlTableGrid;
        private System.Windows.Forms.Panel pnlRightContent;
        private System.Windows.Forms.FlowLayoutPanel flpTables;
        private System.Windows.Forms.Label label1;
    }
}