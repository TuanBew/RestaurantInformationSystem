namespace RestaurantSystem
{
    partial class PaymentManagementControl
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
            this.label_tablename = new System.Windows.Forms.Label();
            this.dataGridView1_payment = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_totalprice = new System.Windows.Forms.Label();
            this.label_bookingid = new System.Windows.Forms.Label();
            this.label_customername = new System.Windows.Forms.Label();
            this.label_notes = new System.Windows.Forms.Label();
            this.label_contactnumber = new System.Windows.Forms.Label();
            this.pay_button = new System.Windows.Forms.Button();
            this.label_warning = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_payment)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_tablename
            // 
            this.label_tablename.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tablename.Location = new System.Drawing.Point(15, 13);
            this.label_tablename.Name = "label_tablename";
            this.label_tablename.Size = new System.Drawing.Size(135, 56);
            this.label_tablename.TabIndex = 9;
            this.label_tablename.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_tablename.Click += new System.EventHandler(this.label_tablename_Click);
            // 
            // dataGridView1_payment
            // 
            this.dataGridView1_payment.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.dataGridView1_payment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1_payment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1_payment.Location = new System.Drawing.Point(15, 299);
            this.dataGridView1_payment.Name = "dataGridView1_payment";
            this.dataGridView1_payment.Size = new System.Drawing.Size(987, 240);
            this.dataGridView1_payment.TabIndex = 10;
            this.dataGridView1_payment.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.groupBox1.Controls.Add(this.label_totalprice);
            this.groupBox1.Controls.Add(this.label_bookingid);
            this.groupBox1.Controls.Add(this.label_customername);
            this.groupBox1.Controls.Add(this.label_notes);
            this.groupBox1.Controls.Add(this.label_contactnumber);
            this.groupBox1.Location = new System.Drawing.Point(15, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(987, 203);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label_totalprice
            // 
            this.label_totalprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_totalprice.Location = new System.Drawing.Point(15, 165);
            this.label_totalprice.Name = "label_totalprice";
            this.label_totalprice.Size = new System.Drawing.Size(623, 23);
            this.label_totalprice.TabIndex = 13;
            this.label_totalprice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_bookingid
            // 
            this.label_bookingid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_bookingid.Location = new System.Drawing.Point(15, 16);
            this.label_bookingid.Name = "label_bookingid";
            this.label_bookingid.Size = new System.Drawing.Size(956, 23);
            this.label_bookingid.TabIndex = 12;
            this.label_bookingid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_bookingid.Click += new System.EventHandler(this.label_bookingid_Click);
            // 
            // label_customername
            // 
            this.label_customername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_customername.Location = new System.Drawing.Point(15, 54);
            this.label_customername.Name = "label_customername";
            this.label_customername.Size = new System.Drawing.Size(623, 23);
            this.label_customername.TabIndex = 12;
            this.label_customername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_customername.Click += new System.EventHandler(this.label_customername_Click);
            // 
            // label_notes
            // 
            this.label_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_notes.Location = new System.Drawing.Point(15, 129);
            this.label_notes.Name = "label_notes";
            this.label_notes.Size = new System.Drawing.Size(623, 23);
            this.label_notes.TabIndex = 11;
            this.label_notes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_contactnumber
            // 
            this.label_contactnumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_contactnumber.Location = new System.Drawing.Point(15, 90);
            this.label_contactnumber.Name = "label_contactnumber";
            this.label_contactnumber.Size = new System.Drawing.Size(623, 23);
            this.label_contactnumber.TabIndex = 10;
            this.label_contactnumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_contactnumber.Click += new System.EventHandler(this.label_contactnumber_Click);
            // 
            // pay_button
            // 
            this.pay_button.BackColor = System.Drawing.Color.SeaShell;
            this.pay_button.Location = new System.Drawing.Point(395, 560);
            this.pay_button.Name = "pay_button";
            this.pay_button.Size = new System.Drawing.Size(194, 52);
            this.pay_button.TabIndex = 14;
            this.pay_button.Text = "PAY";
            this.pay_button.UseVisualStyleBackColor = false;
            this.pay_button.Click += new System.EventHandler(this.pay_button_Click);
            // 
            // label_warning
            // 
            this.label_warning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_warning.ForeColor = System.Drawing.Color.Red;
            this.label_warning.Location = new System.Drawing.Point(329, 64);
            this.label_warning.Name = "label_warning";
            this.label_warning.Size = new System.Drawing.Size(361, 23);
            this.label_warning.TabIndex = 15;
            this.label_warning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PaymentManagementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.Controls.Add(this.label_warning);
            this.Controls.Add(this.pay_button);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1_payment);
            this.Controls.Add(this.label_tablename);
            this.Name = "PaymentManagementControl";
            this.Size = new System.Drawing.Size(1020, 630);
            this.Load += new System.EventHandler(this.PaymentManagementControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_payment)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_tablename;
        private System.Windows.Forms.DataGridView dataGridView1_payment;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_contactnumber;
        private System.Windows.Forms.Label label_notes;
        private System.Windows.Forms.Label label_bookingid;
        private System.Windows.Forms.Label label_totalprice;
        private System.Windows.Forms.Label label_customername;
        private System.Windows.Forms.Button pay_button;
        private System.Windows.Forms.Label label_warning;
    }
}
