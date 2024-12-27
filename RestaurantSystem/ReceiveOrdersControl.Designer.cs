namespace RestaurantSystem
{
    partial class ReceiveOrdersControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flpTables = new System.Windows.Forms.FlowLayoutPanel();
            this.grpOrderDetails = new System.Windows.Forms.GroupBox();
            this.btnMarkReady = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvOrderDetails = new System.Windows.Forms.DataGridView();
            this.lblTableID = new System.Windows.Forms.Label();
            this.txtTableNumber = new System.Windows.Forms.TextBox();
            this.BookingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DishName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpOrderDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // flpTables
            // 
            this.flpTables.BackColor = System.Drawing.Color.Bisque;
            this.flpTables.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpTables.Location = new System.Drawing.Point(0, 0);
            this.flpTables.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpTables.Name = "flpTables";
            this.flpTables.Size = new System.Drawing.Size(640, 864);
            this.flpTables.TabIndex = 0;
            this.flpTables.Paint += new System.Windows.Forms.PaintEventHandler(this.flpTables_Paint);
            // 
            // grpOrderDetails
            // 
            this.grpOrderDetails.BackColor = System.Drawing.Color.Bisque;
            this.grpOrderDetails.Controls.Add(this.btnMarkReady);
            this.grpOrderDetails.Controls.Add(this.label2);
            this.grpOrderDetails.Controls.Add(this.dgvOrderDetails);
            this.grpOrderDetails.Controls.Add(this.lblTableID);
            this.grpOrderDetails.Controls.Add(this.txtTableNumber);
            this.grpOrderDetails.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpOrderDetails.Location = new System.Drawing.Point(646, 0);
            this.grpOrderDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpOrderDetails.Name = "grpOrderDetails";
            this.grpOrderDetails.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpOrderDetails.Size = new System.Drawing.Size(810, 864);
            this.grpOrderDetails.TabIndex = 0;
            this.grpOrderDetails.TabStop = false;
            this.grpOrderDetails.Text = "Orders Detail";
            this.grpOrderDetails.Enter += new System.EventHandler(this.grpOrderDetails_Enter);
            // 
            // btnMarkReady
            // 
            this.btnMarkReady.Location = new System.Drawing.Point(266, 721);
            this.btnMarkReady.Name = "btnMarkReady";
            this.btnMarkReady.Size = new System.Drawing.Size(96, 30);
            this.btnMarkReady.TabIndex = 4;
            this.btnMarkReady.Text = "Ready";
            this.btnMarkReady.UseVisualStyleBackColor = true;
            this.btnMarkReady.Click += new System.EventHandler(this.btnMarkReady_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 688);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mark as Ready";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dgvOrderDetails
            // 
            this.dgvOrderDetails.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.dgvOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BookingID,
            this.DishName,
            this.Quantity,
            this.Price,
            this.OrderStatus,
            this.OrderID});
            this.dgvOrderDetails.Location = new System.Drawing.Point(6, 139);
            this.dgvOrderDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvOrderDetails.Name = "dgvOrderDetails";
            this.dgvOrderDetails.RowHeadersWidth = 51;
            this.dgvOrderDetails.RowTemplate.Height = 24;
            this.dgvOrderDetails.Size = new System.Drawing.Size(791, 481);
            this.dgvOrderDetails.TabIndex = 2;
            this.dgvOrderDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderDetails_CellContentClick);
            // 
            // lblTableID
            // 
            this.lblTableID.AutoSize = true;
            this.lblTableID.Location = new System.Drawing.Point(64, 64);
            this.lblTableID.Name = "lblTableID";
            this.lblTableID.Size = new System.Drawing.Size(43, 16);
            this.lblTableID.TabIndex = 1;
            this.lblTableID.Text = "Table";
            // 
            // txtTableNumber
            // 
            this.txtTableNumber.Location = new System.Drawing.Point(155, 58);
            this.txtTableNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTableNumber.Name = "txtTableNumber";
            this.txtTableNumber.ReadOnly = true;
            this.txtTableNumber.Size = new System.Drawing.Size(100, 22);
            this.txtTableNumber.TabIndex = 0;
            // 
            // BookingID
            // 
            this.BookingID.HeaderText = "Booking ID";
            this.BookingID.MinimumWidth = 6;
            this.BookingID.Name = "BookingID";
            this.BookingID.Width = 125;
            // 
            // DishName
            // 
            this.DishName.HeaderText = "Dish Name";
            this.DishName.MinimumWidth = 6;
            this.DishName.Name = "DishName";
            this.DishName.Width = 125;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 125;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.Width = 125;
            // 
            // OrderStatus
            // 
            this.OrderStatus.HeaderText = "Order Status";
            this.OrderStatus.MinimumWidth = 6;
            this.OrderStatus.Name = "OrderStatus";
            this.OrderStatus.Width = 125;
            // 
            // OrderID
            // 
            this.OrderID.HeaderText = "Order ID";
            this.OrderID.MinimumWidth = 6;
            this.OrderID.Name = "OrderID";
            this.OrderID.Width = 125;
            // 
            // ReceiveOrdersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpOrderDetails);
            this.Controls.Add(this.flpTables);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ReceiveOrdersControl";
            this.Size = new System.Drawing.Size(1456, 864);
            this.grpOrderDetails.ResumeLayout(false);
            this.grpOrderDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpTables;
        private System.Windows.Forms.GroupBox grpOrderDetails;
        private System.Windows.Forms.DataGridView dgvOrderDetails;
        private System.Windows.Forms.Label lblTableID;
        private System.Windows.Forms.TextBox txtTableNumber;
        private System.Windows.Forms.Button btnMarkReady;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookingID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DishName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderID;
    }
}
