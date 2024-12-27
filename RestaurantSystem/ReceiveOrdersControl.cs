using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace RestaurantSystem
{
    public partial class ReceiveOrdersControl : UserControl
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RestaurantDB;Integrated Security=True;";
        private int currentTableID;

        public ReceiveOrdersControl()
        {
            InitializeComponent();
            LoadTables();
        }

        // Load table buttons dynamically
        private void LoadTables()
        {
            flpTables.Controls.Clear();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT t.TableID, t.TableNumber,
                               CASE 
                                   WHEN EXISTS (SELECT 1 FROM Orders WHERE TableID = t.TableID AND OrderStatus = 'Pending') THEN 'Occupied'
                                   ELSE 'Empty'
                               END AS TableStatus
                        FROM Tables t";

                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int tableID = Convert.ToInt32(reader["TableID"]);
                        string tableNumber = reader["TableNumber"].ToString();
                        string status = reader["TableStatus"].ToString();

                        Button btnTable = new Button
                        {
                            Text = $"{tableNumber}\n{status}",
                            Width = 120,
                            Height = 100,
                            BackColor = status == "Occupied" ? Color.LightGreen : Color.LightGray,
                            Tag = tableID
                        };

                        btnTable.Click += TableButton_Click;
                        flpTables.Controls.Add(btnTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading tables: {ex.Message}");
            }
        }

        // Handle table button click
        private void TableButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            currentTableID = (int)clickedButton.Tag;

            txtTableNumber.Text = clickedButton.Text.Split('\n')[0]; // Update table number in UI
            LoadOrderDetails(currentTableID);
        }

        // Load orders for the selected table
        private void LoadOrderDetails(int tableID)
        {
            dgvOrderDetails.Rows.Clear();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT o.OrderID, b.BookingID, m.Name AS DishName, od.Quantity, od.Price, o.OrderStatus
                        FROM Orders o
                        INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
                        INNER JOIN Menu m ON od.MenuItemID = m.MenuItemID
                        LEFT JOIN Bookings b ON o.BookingID = b.BookingID
                        WHERE o.TableID = @TableID AND o.OrderStatus = 'Pending'";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@TableID", tableID);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        dgvOrderDetails.Rows.Add(
                            reader["BookingID"],
                            reader["DishName"],
                            reader["Quantity"],
                            reader["Price"],
                            reader["OrderStatus"],
                            reader["OrderID"]
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}");
            }
        }

        // Mark selected order as Ready
        private void btnMarkReady_Click(object sender, EventArgs e)
        {
            if (dgvOrderDetails.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to mark as Ready.");
                return;
            }

            DataGridViewRow selectedRow = dgvOrderDetails.SelectedRows[0];
            int selectedOrderID = Convert.ToInt32(selectedRow.Cells["OrderID"].Value);

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Orders SET OrderStatus = 'Ready' WHERE OrderID = @OrderID AND OrderStatus = 'Pending'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@OrderID", selectedOrderID);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Order marked as Ready.");
                        LoadOrderDetails(currentTableID); // Refresh orders
                        LoadTables(); // Refresh table statuses
                    }
                    else
                    {
                        MessageBox.Show("Failed to update order status.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating order: {ex.Message}");
            }
        }

        // Unimplemented methods retained
        private void grpOrderDetails_Enter(object sender, EventArgs e)
        {
            // Placeholder for group enter event handling
        }

        private void flpTables_Paint(object sender, PaintEventArgs e)
        {
            // Placeholder for flow layout panel paint event handling
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Placeholder for label click event handling
        }

        private void dgvOrderDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Placeholder for DataGridView cell content click event handling
        }

        private int GetSelectedTableID()
        {
            try
            {
                // Assume lblTable contains "Table 01" or similar
                string tableLabel = lblTableID.Text;
                string tableNumber = tableLabel.Replace("Table ", "").Trim();

                string query = "SELECT TableID FROM Tables WHERE TableNumber = @TableNumber";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@TableNumber", "Table " + tableNumber); // Ensure formatting matches

                    con.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                        return Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching TableID: {ex.Message}");
            }

            return -1; // Invalid TableID
        }
    }
}
