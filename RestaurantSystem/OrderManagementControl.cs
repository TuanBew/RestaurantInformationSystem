using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RestaurantSystem
{
    public partial class OrderManagementControl : UserControl
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RestaurantDB;Integrated Security=True;";
        
        public OrderManagementControl()
        {
            InitializeComponent();
            LoadCategories();
            btnSubmitOrder.Enabled = false; // Disable Submit Order button by default
        }

        private void OrderManagementControl_Load(object sender, EventArgs e)
        {
           
        }

        public void LoadTableDetails(string tableID, string status)
        {
            txtTableNumber.Text = tableID;

            if (status == "Reserved" || status == "Occupied")
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        // Fetch the BookingID associated with the table
                        string query = "SELECT TOP 1 BookingID FROM Bookings WHERE TableID = @TableID AND Status = 'Active' ORDER BY BookingTime DESC";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@TableID", tableID);
                        con.Open();

                        object bookingIdResult = cmd.ExecuteScalar();
                        con.Close();

                        if (bookingIdResult != null)
                        {
                            lblBookingID.Text = $"Booking ID: {bookingIdResult.ToString()}";
                            lblBookingID.Tag = bookingIdResult.ToString(); // Store the BookingID for reference
                        }
                        else
                        {
                            lblBookingID.Text = "No active booking found for this table.";
                            lblBookingID.Tag = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching booking details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                lblBookingID.Text = "No booking associated with this table.";
                lblBookingID.Tag = null;
            }
        }


        private void LoadCategories()
        {
            // Load categories into the cmbCategory ComboBox
            cmbCategory.Items.Clear();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT DISTINCT Category FROM Menu";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbCategory.Items.Add(reader["Category"].ToString());
                }

                con.Close();
            }

            cmbCategory.SelectedIndexChanged += CmbCategory_SelectedIndexChanged;
        }

        private void CmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedItem == null)
            {
                MessageBox.Show("Please select a category before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method if no category is selected
            }

            // Load dishes into the cmbDish ComboBox based on the selected category
            cmbDish.Items.Clear();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Name FROM Menu WHERE Category = @Category";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Category", cmbCategory.SelectedItem.ToString());
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbDish.Items.Add(reader["Name"].ToString());
                }
                reader.Close();
                con.Close();
            }
        }

        private void ClearForm()
        {
            txtTableNumber.Clear();
            cmbCategory.SelectedIndex = -1;
            cmbDish.SelectedIndex = -1;
            nudQuantity.Value = 0;
            dgvOrderItems.Rows.Clear();
        }

        private void btnAddOrder_Click_1(object sender, EventArgs e)
        {
            if (cmbDish.SelectedItem == null || nudQuantity.Value <= 0)
            {
                MessageBox.Show("Please select a dish and specify a quantity!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT Price FROM Menu WHERE Name = @DishName";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@DishName", cmbDish.SelectedItem.ToString());
                    con.Open();

                    decimal price = Convert.ToDecimal(cmd.ExecuteScalar());
                    con.Close();

                    // Calculate the total price
                    decimal total = price * nudQuantity.Value;

                    // Add the item to the DataGridView
                    dgvOrderItems.Rows.Add(cmbDish.SelectedItem.ToString(), nudQuantity.Value, price, total);

                    // Enable the Submit Order button
                    btnSubmitOrder.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmitOrder_Click_1(object sender, EventArgs e)
        {
            if (dgvOrderItems.Rows.Count == 0)
            {
                MessageBox.Show("You must add at least one item to the order before submitting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string tableID;
                string formattedTableNumber = $"Table {int.Parse(txtTableNumber.Text):00}";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Validate and get the correct TableID
                    string getTableIdQuery = "SELECT TableID FROM Tables WHERE TableNumber = @TableNumber";
                    SqlCommand getTableIdCmd = new SqlCommand(getTableIdQuery, con);
                    getTableIdCmd.Parameters.AddWithValue("@TableNumber", formattedTableNumber);

                    con.Open();
                    object result = getTableIdCmd.ExecuteScalar();
                    con.Close();

                    if (result == null)
                    {
                        MessageBox.Show($"TableNumber {formattedTableNumber} does not exist in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    tableID = result.ToString();

                    // Get the BookingID if it exists
                    int? bookingID = lblBookingID.Tag != null ? (int?)Convert.ToInt32(lblBookingID.Tag) : null;

                    // Insert a new order into the Orders table
                    string insertOrderQuery = @"
                INSERT INTO Orders (TableID, OrderDateTime, OrderStatus, BookingID)
                VALUES (@TableID, @OrderDateTime, 'Pending', @BookingID);
                SELECT SCOPE_IDENTITY();"; // Get the newly created OrderID

                    SqlCommand insertOrderCmd = new SqlCommand(insertOrderQuery, con);
                    insertOrderCmd.Parameters.AddWithValue("@TableID", tableID);
                    insertOrderCmd.Parameters.AddWithValue("@OrderDateTime", DateTime.Now);
                    insertOrderCmd.Parameters.AddWithValue("@BookingID", (object)bookingID ?? DBNull.Value);

                    con.Open();
                    int orderId = Convert.ToInt32(insertOrderCmd.ExecuteScalar());
                    con.Close();

                    // Insert each order item into the OrderDetails table
                    foreach (DataGridViewRow row in dgvOrderItems.Rows)
                    {
                        if (row.Cells[0].Value == null) continue;

                        string insertOrderDetailQuery = @"
                    INSERT INTO OrderDetails (OrderID, MenuItemID, Quantity, Price)
                    SELECT @OrderID, MenuItemID, @Quantity, @Price
                    FROM Menu
                    WHERE Name = @DishName";

                        SqlCommand insertOrderDetailCmd = new SqlCommand(insertOrderDetailQuery, con);
                        insertOrderDetailCmd.Parameters.AddWithValue("@OrderID", orderId);
                        insertOrderDetailCmd.Parameters.AddWithValue("@DishName", row.Cells["DishName"].Value.ToString());
                        insertOrderDetailCmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(row.Cells["Quantity"].Value));
                        insertOrderDetailCmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(row.Cells["Price"].Value));

                        con.Open();
                        insertOrderDetailCmd.ExecuteNonQuery();
                        con.Close();
                    }

                    // Update the table status
                    string updateTableQuery = "UPDATE Tables SET Status = 'Occupied' WHERE TableID = @TableID";
                    SqlCommand updateTableCmd = new SqlCommand(updateTableQuery, con);
                    updateTableCmd.Parameters.AddWithValue("@TableID", tableID);

                    con.Open();
                    updateTableCmd.ExecuteNonQuery();
                    con.Close();
                }

                MessageBox.Show("Order submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh tables and clear form
                var dashboard = (WaiterDashboard)this.ParentForm;
                dashboard.LoadTableGrid();
                ClearForm();
                btnSubmitOrder.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error submitting order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void label5_Click(object sender, EventArgs e)
        {
            string tableID = txtTableNumber.Text; // Assuming you have this control for the table number

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT BookingID FROM Bookings WHERE TableID = @TableID AND Status = 'Active'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TableID", tableID);
                con.Open();

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    lblBookingID.Text = "Booking ID: " + result.ToString();
                }
                else
                {
                    lblBookingID.Text = "No active booking found.";
                }

                con.Close();
            }
        }
    }
}
