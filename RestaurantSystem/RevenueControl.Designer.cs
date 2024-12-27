namespace RestaurantSystem
{
    partial class RevenueControl
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
            this.revenue_dataGridView = new System.Windows.Forms.DataGridView();
            this.totalrevenue_groupbox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.revenue_dataGridView)).BeginInit();
            this.totalrevenue_groupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // revenue_dataGridView
            // 
            this.revenue_dataGridView.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.revenue_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.revenue_dataGridView.Location = new System.Drawing.Point(22, 21);
            this.revenue_dataGridView.Name = "revenue_dataGridView";
            this.revenue_dataGridView.Size = new System.Drawing.Size(973, 494);
            this.revenue_dataGridView.TabIndex = 0;
            this.revenue_dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.revenue_dataGridView_CellContentClick);
            // 
            // totalrevenue_groupbox
            // 
            this.totalrevenue_groupbox.BackColor = System.Drawing.Color.AntiqueWhite;
            this.totalrevenue_groupbox.Controls.Add(this.label1);
            this.totalrevenue_groupbox.Location = new System.Drawing.Point(22, 540);
            this.totalrevenue_groupbox.Name = "totalrevenue_groupbox";
            this.totalrevenue_groupbox.Size = new System.Drawing.Size(973, 67);
            this.totalrevenue_groupbox.TabIndex = 1;
            this.totalrevenue_groupbox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(489, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // RevenueControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.Controls.Add(this.totalrevenue_groupbox);
            this.Controls.Add(this.revenue_dataGridView);
            this.Name = "RevenueControl";
            this.Size = new System.Drawing.Size(1020, 630);
            ((System.ComponentModel.ISupportInitialize)(this.revenue_dataGridView)).EndInit();
            this.totalrevenue_groupbox.ResumeLayout(false);
            this.totalrevenue_groupbox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView revenue_dataGridView;
        private System.Windows.Forms.GroupBox totalrevenue_groupbox;
        private System.Windows.Forms.Label label1;
    }
}
