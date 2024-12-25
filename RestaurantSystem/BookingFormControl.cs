using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RestaurantSystem
{
    public partial class BookingFormControl : UserControl
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RestaurantDB;Integrated Security=True;";
       
        public BookingFormControl()
        {
            InitializeComponent();
        }

        private void BookingFormControl_Load(object sender, EventArgs e)
        {
           
        }

        public void LoadTableDetails(string tableID, string status)
        {
            ClearForm();

            txtTableNumber.Text = tableID;
            txtStatus.Text = status;

            if (status == "Empty") return;

            // Fetch booking details for reserved/occupied tables
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Bookings WHERE TableID = @TableID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TableID", tableID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtCustomerName.Text = reader["CustomerName"].ToString();
                    txtContactNumber.Text = reader["ContactNumber"].ToString();
                    dtpBookingTime.Value = Convert.ToDateTime(reader["BookingTime"]);
                    nudPeopleCount.Value = Convert.ToInt32(reader["PeopleCount"]);
                    txtNotes.Text = reader["Notes"].ToString();
                }
                con.Close();
            }
        }

        private void ClearForm()
        {
            txtTableNumber.Clear();
            txtStatus.Clear();
            txtCustomerName.Clear();
            txtContactNumber.Clear();
            dtpBookingTime.Value = DateTime.Now;
            nudPeopleCount.Value = 0;
            txtNotes.Clear();
        }


        private void btnSaveBooking_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Insert booking details into the Bookings table
                    string bookingQuery = @"
                INSERT INTO Bookings (TableID, CustomerName, ContactNumber, BookingTime, PeopleCount, Notes, Status)
                VALUES (@TableID, @CustomerName, @ContactNumber, @BookingTime, @PeopleCount, @Notes, 'Active')";

                    SqlCommand bookingCmd = new SqlCommand(bookingQuery, con);
                    bookingCmd.Parameters.AddWithValue("@TableID", txtTableNumber.Text);
                    bookingCmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    bookingCmd.Parameters.AddWithValue("@ContactNumber", txtContactNumber.Text);
                    bookingCmd.Parameters.AddWithValue("@BookingTime", dtpBookingTime.Value);
                    bookingCmd.Parameters.AddWithValue("@PeopleCount", nudPeopleCount.Value);
                    bookingCmd.Parameters.AddWithValue("@Notes", txtNotes.Text);

                    con.Open();
                    bookingCmd.ExecuteNonQuery();

                    // Update the table status in the Tables table to "Reserved"
                    string updateTableQuery = @"
                UPDATE Tables
                SET Status = 'Reserved'
                WHERE TableID = @TableID";

                    SqlCommand updateTableCmd = new SqlCommand(updateTableQuery, con);
                    updateTableCmd.Parameters.AddWithValue("@TableID", txtTableNumber.Text);
                    updateTableCmd.ExecuteNonQuery();

                    con.Close();
                }

                MessageBox.Show("Booking saved successfully! The table has been reserved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh the table grid in the WaiterDashboard
                var dashboard = (WaiterDashboard)this.ParentForm;
                dashboard.LoadTableGrid(); // Reload the tables to reflect the updated status
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancelBooking_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Ensure the table is Reserved
                if (txtStatus.Text != "Reserved")
                {
                    MessageBox.Show("Only reserved tables can be cancelled. Occupied tables cannot be cancelled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Delete the booking from the Bookings table
                    string deleteBookingQuery = "DELETE FROM Bookings WHERE TableID = @TableID";
                    SqlCommand deleteBookingCmd = new SqlCommand(deleteBookingQuery, con);
                    deleteBookingCmd.Parameters.AddWithValue("@TableID", txtTableNumber.Text);

                    // Update the table status in the Tables table to "Empty"
                    string updateTableQuery = "UPDATE Tables SET Status = 'Empty' WHERE TableID = @TableID";
                    SqlCommand updateTableCmd = new SqlCommand(updateTableQuery, con);
                    updateTableCmd.Parameters.AddWithValue("@TableID", txtTableNumber.Text);

                    con.Open();
                    deleteBookingCmd.ExecuteNonQuery();
                    updateTableCmd.ExecuteNonQuery();
                    con.Close();
                }

                MessageBox.Show("Booking cancelled successfully! The table is now empty.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh the table grid in the WaiterDashboard
                var dashboard = (WaiterDashboard)this.ParentForm;
                dashboard.LoadTableGrid(); // Reload the tables to reflect the updated status

                // Clear the form
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cancelling booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
