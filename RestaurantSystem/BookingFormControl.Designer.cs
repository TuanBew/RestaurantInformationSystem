namespace RestaurantSystem
{
    partial class BookingFormControl
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
            this.lblTableNumber = new System.Windows.Forms.Label();
            this.lblSeats = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblBookingTime = new System.Windows.Forms.Label();
            this.txtTableNumber = new System.Windows.Forms.TextBox();
            this.txtSeats = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtContactNumber = new System.Windows.Forms.TextBox();
            this.btnSaveBooking = new System.Windows.Forms.Button();
            this.btnCancelBooking = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.dtpBookingTime = new System.Windows.Forms.DateTimePicker();
            this.lblPeopleCount = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.nudPeopleCount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudPeopleCount)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTableNumber
            // 
            this.lblTableNumber.AutoSize = true;
            this.lblTableNumber.Location = new System.Drawing.Point(28, 52);
            this.lblTableNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTableNumber.Name = "lblTableNumber";
            this.lblTableNumber.Size = new System.Drawing.Size(74, 13);
            this.lblTableNumber.TabIndex = 0;
            this.lblTableNumber.Text = "Table Number";
            // 
            // lblSeats
            // 
            this.lblSeats.AutoSize = true;
            this.lblSeats.Location = new System.Drawing.Point(28, 91);
            this.lblSeats.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSeats.Name = "lblSeats";
            this.lblSeats.Size = new System.Drawing.Size(86, 13);
            this.lblSeats.TabIndex = 1;
            this.lblSeats.Text = "Number of Seats";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(28, 176);
            this.lblCustomerName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(82, 13);
            this.lblCustomerName.TabIndex = 2;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // lblBookingTime
            // 
            this.lblBookingTime.AutoSize = true;
            this.lblBookingTime.Location = new System.Drawing.Point(28, 262);
            this.lblBookingTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBookingTime.Name = "lblBookingTime";
            this.lblBookingTime.Size = new System.Drawing.Size(30, 13);
            this.lblBookingTime.TabIndex = 3;
            this.lblBookingTime.Text = "Time";
            // 
            // txtTableNumber
            // 
            this.txtTableNumber.Location = new System.Drawing.Point(141, 47);
            this.txtTableNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTableNumber.Name = "txtTableNumber";
            this.txtTableNumber.ReadOnly = true;
            this.txtTableNumber.Size = new System.Drawing.Size(76, 20);
            this.txtTableNumber.TabIndex = 4;
            // 
            // txtSeats
            // 
            this.txtSeats.Location = new System.Drawing.Point(141, 86);
            this.txtSeats.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSeats.Name = "txtSeats";
            this.txtSeats.Size = new System.Drawing.Size(76, 20);
            this.txtSeats.TabIndex = 5;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(141, 171);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(76, 20);
            this.txtCustomerName.TabIndex = 6;
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.Location = new System.Drawing.Point(141, 210);
            this.txtContactNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.Size = new System.Drawing.Size(76, 20);
            this.txtContactNumber.TabIndex = 7;
            // 
            // btnSaveBooking
            // 
            this.btnSaveBooking.Location = new System.Drawing.Point(34, 395);
            this.btnSaveBooking.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSaveBooking.Name = "btnSaveBooking";
            this.btnSaveBooking.Size = new System.Drawing.Size(82, 49);
            this.btnSaveBooking.TabIndex = 8;
            this.btnSaveBooking.Text = "Save Booking";
            this.btnSaveBooking.UseVisualStyleBackColor = true;
            this.btnSaveBooking.Click += new System.EventHandler(this.btnSaveBooking_Click);
            // 
            // btnCancelBooking
            // 
            this.btnCancelBooking.Location = new System.Drawing.Point(164, 395);
            this.btnCancelBooking.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancelBooking.Name = "btnCancelBooking";
            this.btnCancelBooking.Size = new System.Drawing.Size(76, 49);
            this.btnCancelBooking.TabIndex = 9;
            this.btnCancelBooking.Text = "Cancel Booking";
            this.btnCancelBooking.UseVisualStyleBackColor = true;
            this.btnCancelBooking.Click += new System.EventHandler(this.btnCancelBooking_Click_1);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(141, 127);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(76, 20);
            this.txtStatus.TabIndex = 11;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(28, 132);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(67, 13);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Table Status";
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Location = new System.Drawing.Point(28, 213);
            this.lblContact.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(84, 13);
            this.lblContact.TabIndex = 14;
            this.lblContact.Text = "Contact Number";
            // 
            // dtpBookingTime
            // 
            this.dtpBookingTime.Location = new System.Drawing.Point(141, 258);
            this.dtpBookingTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpBookingTime.Name = "dtpBookingTime";
            this.dtpBookingTime.Size = new System.Drawing.Size(151, 20);
            this.dtpBookingTime.TabIndex = 15;
            // 
            // lblPeopleCount
            // 
            this.lblPeopleCount.AutoSize = true;
            this.lblPeopleCount.Location = new System.Drawing.Point(28, 307);
            this.lblPeopleCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPeopleCount.Name = "lblPeopleCount";
            this.lblPeopleCount.Size = new System.Drawing.Size(92, 13);
            this.lblPeopleCount.TabIndex = 17;
            this.lblPeopleCount.Text = "Number of People";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(28, 349);
            this.lblNotes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(35, 13);
            this.lblNotes.TabIndex = 19;
            this.lblNotes.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(141, 346);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(76, 20);
            this.txtNotes.TabIndex = 18;
            // 
            // nudPeopleCount
            // 
            this.nudPeopleCount.Location = new System.Drawing.Point(141, 302);
            this.nudPeopleCount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudPeopleCount.Name = "nudPeopleCount";
            this.nudPeopleCount.Size = new System.Drawing.Size(90, 20);
            this.nudPeopleCount.TabIndex = 20;
            // 
            // BookingFormControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.Controls.Add(this.nudPeopleCount);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblPeopleCount);
            this.Controls.Add(this.dtpBookingTime);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnCancelBooking);
            this.Controls.Add(this.btnSaveBooking);
            this.Controls.Add(this.txtContactNumber);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.txtSeats);
            this.Controls.Add(this.txtTableNumber);
            this.Controls.Add(this.lblBookingTime);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.lblSeats);
            this.Controls.Add(this.lblTableNumber);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "BookingFormControl";
            this.Size = new System.Drawing.Size(480, 570);
            this.Load += new System.EventHandler(this.BookingFormControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPeopleCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTableNumber;
        private System.Windows.Forms.Label lblSeats;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblBookingTime;
        private System.Windows.Forms.TextBox txtTableNumber;
        private System.Windows.Forms.TextBox txtSeats;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtContactNumber;
        private System.Windows.Forms.Button btnSaveBooking;
        private System.Windows.Forms.Button btnCancelBooking;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.DateTimePicker dtpBookingTime;
        private System.Windows.Forms.Label lblPeopleCount;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.NumericUpDown nudPeopleCount;
    }
}
