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
            this.lblTableNumber.Location = new System.Drawing.Point(38, 64);
            this.lblTableNumber.Name = "lblTableNumber";
            this.lblTableNumber.Size = new System.Drawing.Size(94, 16);
            this.lblTableNumber.TabIndex = 0;
            this.lblTableNumber.Text = "Table Number";
            // 
            // lblSeats
            // 
            this.lblSeats.AutoSize = true;
            this.lblSeats.Location = new System.Drawing.Point(38, 112);
            this.lblSeats.Name = "lblSeats";
            this.lblSeats.Size = new System.Drawing.Size(107, 16);
            this.lblSeats.TabIndex = 1;
            this.lblSeats.Text = "Number of Seats";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(38, 216);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(104, 16);
            this.lblCustomerName.TabIndex = 2;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // lblBookingTime
            // 
            this.lblBookingTime.AutoSize = true;
            this.lblBookingTime.Location = new System.Drawing.Point(38, 323);
            this.lblBookingTime.Name = "lblBookingTime";
            this.lblBookingTime.Size = new System.Drawing.Size(38, 16);
            this.lblBookingTime.TabIndex = 3;
            this.lblBookingTime.Text = "Time";
            // 
            // txtTableNumber
            // 
            this.txtTableNumber.Location = new System.Drawing.Point(188, 58);
            this.txtTableNumber.Name = "txtTableNumber";
            this.txtTableNumber.ReadOnly = true;
            this.txtTableNumber.Size = new System.Drawing.Size(100, 22);
            this.txtTableNumber.TabIndex = 4;
            // 
            // txtSeats
            // 
            this.txtSeats.Location = new System.Drawing.Point(188, 106);
            this.txtSeats.Name = "txtSeats";
            this.txtSeats.Size = new System.Drawing.Size(100, 22);
            this.txtSeats.TabIndex = 5;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(188, 210);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(100, 22);
            this.txtCustomerName.TabIndex = 6;
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.Location = new System.Drawing.Point(188, 259);
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.Size = new System.Drawing.Size(100, 22);
            this.txtContactNumber.TabIndex = 7;
            // 
            // btnSaveBooking
            // 
            this.btnSaveBooking.Location = new System.Drawing.Point(45, 486);
            this.btnSaveBooking.Name = "btnSaveBooking";
            this.btnSaveBooking.Size = new System.Drawing.Size(109, 60);
            this.btnSaveBooking.TabIndex = 8;
            this.btnSaveBooking.Text = "Save Booking";
            this.btnSaveBooking.UseVisualStyleBackColor = true;
            this.btnSaveBooking.Click += new System.EventHandler(this.btnSaveBooking_Click);
            // 
            // btnCancelBooking
            // 
            this.btnCancelBooking.Location = new System.Drawing.Point(219, 486);
            this.btnCancelBooking.Name = "btnCancelBooking";
            this.btnCancelBooking.Size = new System.Drawing.Size(101, 60);
            this.btnCancelBooking.TabIndex = 9;
            this.btnCancelBooking.Text = "Cancel Booking";
            this.btnCancelBooking.UseVisualStyleBackColor = true;
            this.btnCancelBooking.Click += new System.EventHandler(this.btnCancelBooking_Click_1);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(188, 156);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(100, 22);
            this.txtStatus.TabIndex = 11;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(38, 162);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(83, 16);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Table Status";
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Location = new System.Drawing.Point(38, 262);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(103, 16);
            this.lblContact.TabIndex = 14;
            this.lblContact.Text = "Contact Number";
            // 
            // dtpBookingTime
            // 
            this.dtpBookingTime.Location = new System.Drawing.Point(188, 318);
            this.dtpBookingTime.Name = "dtpBookingTime";
            this.dtpBookingTime.Size = new System.Drawing.Size(200, 22);
            this.dtpBookingTime.TabIndex = 15;
            // 
            // lblPeopleCount
            // 
            this.lblPeopleCount.AutoSize = true;
            this.lblPeopleCount.Location = new System.Drawing.Point(38, 378);
            this.lblPeopleCount.Name = "lblPeopleCount";
            this.lblPeopleCount.Size = new System.Drawing.Size(116, 16);
            this.lblPeopleCount.TabIndex = 17;
            this.lblPeopleCount.Text = "Number of People";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(38, 429);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(43, 16);
            this.lblNotes.TabIndex = 19;
            this.lblNotes.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(188, 426);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(100, 22);
            this.txtNotes.TabIndex = 18;
            // 
            // nudPeopleCount
            // 
            this.nudPeopleCount.Location = new System.Drawing.Point(188, 372);
            this.nudPeopleCount.Name = "nudPeopleCount";
            this.nudPeopleCount.Size = new System.Drawing.Size(120, 22);
            this.nudPeopleCount.TabIndex = 20;
            // 
            // BookingFormControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Name = "BookingFormControl";
            this.Size = new System.Drawing.Size(640, 701);
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
