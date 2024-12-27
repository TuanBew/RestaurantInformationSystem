namespace RestaurantSystem
{
    partial class ImportHistoryControl
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
            this.dgvImportHistory = new System.Windows.Forms.DataGridView();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.txtTotalRevenue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DateOfImport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnConfirmDateSelection = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvImportHistory
            // 
            this.dgvImportHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImportHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateOfImport,
            this.TotalCost});
            this.dgvImportHistory.Location = new System.Drawing.Point(31, 24);
            this.dgvImportHistory.Name = "dgvImportHistory";
            this.dgvImportHistory.RowHeadersWidth = 51;
            this.dgvImportHistory.RowTemplate.Height = 24;
            this.dgvImportHistory.Size = new System.Drawing.Size(387, 233);
            this.dgvImportHistory.TabIndex = 0;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(666, 56);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 22);
            this.dtpStartDate.TabIndex = 1;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(666, 130);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 22);
            this.dtpEndDate.TabIndex = 2;
            // 
            // txtTotalRevenue
            // 
            this.txtTotalRevenue.Location = new System.Drawing.Point(666, 199);
            this.txtTotalRevenue.Name = "txtTotalRevenue";
            this.txtTotalRevenue.ReadOnly = true;
            this.txtTotalRevenue.Size = new System.Drawing.Size(200, 22);
            this.txtTotalRevenue.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(522, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Start date filter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(522, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "End date filter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(522, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Total Revenue";
            // 
            // DateOfImport
            // 
            this.DateOfImport.DataPropertyName = "DateOfImport";
            this.DateOfImport.HeaderText = "Date of Import";
            this.DateOfImport.MinimumWidth = 6;
            this.DateOfImport.Name = "DateOfImport";
            this.DateOfImport.Width = 125;
            // 
            // TotalCost
            // 
            this.TotalCost.DataPropertyName = "TotalCost";
            this.TotalCost.HeaderText = "Total Cost";
            this.TotalCost.MinimumWidth = 6;
            this.TotalCost.Name = "TotalCost";
            this.TotalCost.Width = 125;
            // 
            // btnConfirmDateSelection
            // 
            this.btnConfirmDateSelection.Location = new System.Drawing.Point(608, 256);
            this.btnConfirmDateSelection.Name = "btnConfirmDateSelection";
            this.btnConfirmDateSelection.Size = new System.Drawing.Size(116, 49);
            this.btnConfirmDateSelection.TabIndex = 7;
            this.btnConfirmDateSelection.Text = "Confirm Date";
            this.btnConfirmDateSelection.UseVisualStyleBackColor = true;
            this.btnConfirmDateSelection.Click += new System.EventHandler(this.btnConfirmDateSelection_Click);
            // 
            // ImportHistoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnConfirmDateSelection);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotalRevenue);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.dgvImportHistory);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ImportHistoryControl";
            this.Size = new System.Drawing.Size(964, 342);
            this.Load += new System.EventHandler(this.ImportHistoryControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvImportHistory;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.TextBox txtTotalRevenue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfImport;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCost;
        private System.Windows.Forms.Button btnConfirmDateSelection;
    }
}
