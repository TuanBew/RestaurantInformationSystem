using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantSystem
{
    public partial class PaymentManagementControl : UserControl
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RestaurantDB;Integrated Security=True;";
        private UserControl currentForm;

        public DataTable BookingData { get; set; } // For storing booking and order details
        public string TableID { get; set; } // For the table number
        public decimal TotalAmount { get; set; } // For the total payment amount


        public PaymentManagementControl()
        {
            InitializeComponent();
        }



        private void label_tablename_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PaymentManagementControl_Load(object sender, EventArgs e)
        {
            if (BookingData != null && BookingData.Rows.Count > 0)
            {
                // Populate labels
                label_tablename.Text = $"TABLE {TableID}";
                label_bookingid.Text = $"Booking ID: {BookingData.Rows[0]["BookingID"]}";
                label_customername.Text = $"Customer: {BookingData.Rows[0]["CustomerName"]}";
                label_contactnumber.Text = $"Contact: {BookingData.Rows[0]["ContactNumber"]}";
                label_notes.Text = $"Notes: {BookingData.Rows[0]["Notes"]}";

                // Add BookingTime to BookingData if not already retrieved
                if (!BookingData.Columns.Contains("BookingTime"))
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string query = @"
                            SELECT 
                                b.BookingID,
                                b.CustomerName,
                                b.ContactNumber,
                                b.Notes,
                                b.BookingTime,
                                o.OrderID,
                                m.Name AS DishName,
                                m.Category,
                                od.Quantity,
                                od.Price,
                                o.OrderStatus
                            FROM 
                                Bookings b
                            LEFT JOIN 
                                Orders o ON b.BookingID = o.BookingID
                            LEFT JOIN 
                                OrderDetails od ON o.OrderID = od.OrderID
                            LEFT JOIN 
                                Menu m ON od.MenuItemID = m.MenuItemID
                            WHERE 
                                b.TableID = @TableID AND b.Status = 'Active';
                        ";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@TableID", TableID);
                        cmd.Parameters.AddWithValue("@BookingID", BookingData.Rows[0]["BookingID"]);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable tempData = new DataTable();
                        adapter.Fill(tempData);

                        if (tempData.Rows.Count > 0)
                        {
                            BookingData.Columns.Add("BookingTime", typeof(DateTime));
                            BookingData.Rows[0]["BookingTime"] = tempData.Rows[0]["BookingTime"];
                        }
                    }
                }

                // Bind data to DataGridView
                dataGridView1_payment.DataSource = BookingData;

                // Ensure column headers are set correctly
                dataGridView1_payment.Columns["OrderID"].HeaderText = "Order ID";
                dataGridView1_payment.Columns["DishName"].HeaderText = "Name of Dish";
                dataGridView1_payment.Columns["Category"].HeaderText = "Category";
                dataGridView1_payment.Columns["Quantity"].HeaderText = "Quantity";
                dataGridView1_payment.Columns["Price"].HeaderText = "Price";
                dataGridView1_payment.Columns["OrderStatus"].HeaderText = "Order Status";

                // Add new column for BookingTime
                if (dataGridView1_payment.Columns.Contains("BookingTime"))
                {
                    dataGridView1_payment.Columns["BookingTime"].HeaderText = "Booking Time";
                }

                // Display total amount
                label_totalprice.Text = $"Total: {TotalAmount:C}";

                // Enable Pay button only if all orders are ready
                bool allReady = BookingData.AsEnumerable().All(row => row["OrderStatus"].ToString() == "Ready");
                pay_button.Enabled = allReady;
                label_warning.Text = allReady ? "" : "ALL ORDERS MUST BE READY";
            }
        }


        private void label_bookingid_Click(object sender, EventArgs e)
        {

        }

        private void label_customername_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label_contactnumber_Click(object sender, EventArgs e)
        {

        }

        private async void pay_button_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlTransaction transaction = con.BeginTransaction();

                    try
                    {
                        // Update Table status to "Empty"
                        string updateTableQuery = "UPDATE Tables SET Status = 'Empty' WHERE TableID = @TableID";
                        SqlCommand cmdUpdateTable = new SqlCommand(updateTableQuery, con, transaction);
                        cmdUpdateTable.Parameters.AddWithValue("@TableID", TableID);
                        cmdUpdateTable.ExecuteNonQuery();

                        // Update Booking status to "Completed"
                        string updateBookingQuery = "UPDATE Bookings SET Status = 'Completed' WHERE BookingID = @BookingID";
                        SqlCommand cmdUpdateBooking = new SqlCommand(updateBookingQuery, con, transaction);
                        cmdUpdateBooking.Parameters.AddWithValue("@BookingID", BookingData.Rows[0]["BookingID"]);
                        cmdUpdateBooking.ExecuteNonQuery();

                        // Insert into Payment table
                        string insertPaymentQuery = @"
                        INSERT INTO Payment (OrderID, BookingID, BookingTime, Total)
                        VALUES (@OrderID, @BookingID, @BookingTime, @Total)";
                        SqlCommand cmdInsertPayment = new SqlCommand(insertPaymentQuery, con, transaction);
                        cmdInsertPayment.Parameters.AddWithValue("@OrderID", BookingData.Rows[0]["OrderID"]);
                        cmdInsertPayment.Parameters.AddWithValue("@BookingID", BookingData.Rows[0]["BookingID"]);
                        cmdInsertPayment.Parameters.AddWithValue("@BookingTime", BookingData.Rows[0]["BookingTime"]);
                        cmdInsertPayment.Parameters.AddWithValue("@Total", TotalAmount);
                        cmdInsertPayment.ExecuteNonQuery();

                        // Commit transaction
                        transaction.Commit();

                        // Show confirmation message
                        label_warning.Text = "PAYMENT COMPLETE RECIPE PRINTED";

                        // Reset and reload UI after 5 seconds
                        await Task.Delay(5000);
                        ResetForm();
                    }
                    catch
                    {
                        transaction.Rollback();
                        MessageBox.Show("An error occurred during payment processing. Transaction rolled back.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetForm()
        {
            // Clear all controls
            label_tablename.Text = string.Empty;
            label_bookingid.Text = string.Empty;
            label_customername.Text = string.Empty;
            label_contactnumber.Text = string.Empty;
            label_notes.Text = string.Empty;
            label_totalprice.Text = string.Empty;
            dataGridView1_payment.DataSource = null;

            // Notify ManagerDashboard to reload table grid and right panel
            ManagerDashboard dashboard = Application.OpenForms.OfType<ManagerDashboard>().FirstOrDefault();
            dashboard?.ReloadUI();
        }
    }
}

