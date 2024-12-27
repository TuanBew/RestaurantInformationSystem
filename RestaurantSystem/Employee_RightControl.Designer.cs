namespace RestaurantSystem
{
    partial class Employee_RightControl
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
            this.employee_dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.employee_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // employee_dataGridView
            // 
            this.employee_dataGridView.BackgroundColor = System.Drawing.Color.PapayaWhip;
            this.employee_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employee_dataGridView.Location = new System.Drawing.Point(17, 18);
            this.employee_dataGridView.Name = "employee_dataGridView";
            this.employee_dataGridView.Size = new System.Drawing.Size(988, 597);
            this.employee_dataGridView.TabIndex = 0;
            this.employee_dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.employee_dataGridView_CellContentClick);
            // 
            // Employee_RightControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.Controls.Add(this.employee_dataGridView);
            this.Name = "Employee_RightControl";
            this.Size = new System.Drawing.Size(1020, 630);
            ((System.ComponentModel.ISupportInitialize)(this.employee_dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView employee_dataGridView;
    }
}
