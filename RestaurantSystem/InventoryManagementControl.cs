using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace RestaurantSystem
{
    public partial class InventoryManagementControl : UserControl
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RestaurantDB;Integrated Security=True;";

        public InventoryManagementControl()
        {
            InitializeComponent();
        }

        private void InventoryManagementControl_Load(object sender, EventArgs e)
        {
            LoadInventory();
        }

        // Load Inventory Data into Main DataGridView
        private void LoadInventory()
        {
            dgvInventory.Rows.Clear();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT Name, Quantity, UnitPrice, Unit, ExpiryDate FROM Inventory";
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        dgvInventory.Rows.Add(
                            reader["Name"],
                            reader["Quantity"],
                            reader["UnitPrice"],
                            reader["Unit"],
                            reader["ExpiryDate"]
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading inventory: {ex.Message}");
            }
        }

        // Add Items to Temporary List
        private void btnAddToList_Click(object sender, EventArgs e)
        {
            string itemName = cmbItem.Text;
            int quantity = (int)nudQuantity.Value;
            DateTime expiryDate = dtpExpiryDate.Value;

            if (string.IsNullOrEmpty(itemName) || quantity <= 0)
            {
                MessageBox.Show("Please select an item and enter a valid quantity.");
                return;
            }

            try
            {
                decimal unitPrice = 0;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT UnitPrice FROM Inventory WHERE Name = @Name";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", itemName);

                    con.Open();
                    unitPrice = Convert.ToDecimal(cmd.ExecuteScalar());
                }

                // Check if the item already exists in the temporary list
                foreach (DataGridViewRow row in dgvAddedInventory.Rows)
                {
                    if (row.Cells["Item Name"].Value != null && row.Cells["Item Name"].Value.ToString() == itemName)
                    {
                        int existingQuantity = int.Parse(row.Cells["Quantity"].Value.ToString());
                        row.Cells["Quantity"].Value = existingQuantity + quantity;
                        row.Cells["TotalPrice"].Value = (unitPrice * (existingQuantity + quantity)).ToString("C");
                        UpdateTotalPrice();
                        return;
                    }
                }

                // Add row to dgvAddedInventory
                decimal totalPrice = unitPrice * quantity;
                dgvAddedInventory.Rows.Add(itemName, quantity, expiryDate.ToString("dd/MM/yyyy"), unitPrice.ToString("C"), totalPrice.ToString("C"));

                // Update total price and clear fields
                UpdateTotalPrice();
                cmbItem.SelectedIndex = -1;
                nudQuantity.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding item: {ex.Message}");
            }
        }

        // Update Total Price in TextBox
        private void UpdateTotalPrice()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvAddedInventory.Rows)
            {
                if (row.Cells["TotalPrice"].Value != null)
                {
                    string totalPriceStr = row.Cells["TotalPrice"].Value.ToString();
                    decimal rowTotal = decimal.Parse(totalPriceStr, NumberStyles.Currency);
                    total += rowTotal;
                }
            }

            txtTotalPrice.Text = total.ToString("C"); // Display in currency format
        }

        // Confirm Import to Database
        private void btnConfirmImport_Click(object sender, EventArgs e)
        {
            if (dgvAddedInventory.Rows.Count == 0)
            {
                MessageBox.Show("No items to confirm.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlTransaction transaction = con.BeginTransaction();

                    foreach (DataGridViewRow row in dgvAddedInventory.Rows)
                    {
                        if (row.Cells["Item Name"].Value != null)
                        {
                            string itemName = row.Cells["Item Name"].Value.ToString();
                            int quantity = int.Parse(row.Cells["Quantity"].Value.ToString());
                            decimal totalPrice = decimal.Parse(row.Cells["TotalPrice"].Value.ToString(), NumberStyles.Currency);
                            DateTime expiryDate = DateTime.Parse(row.Cells["ExpiryDate"].Value.ToString());

                            // Update Inventory Table
                            string updateQuery = "UPDATE Inventory SET Quantity = Quantity + @Quantity, ExpiryDate = @ExpiryDate WHERE Name = @Name";
                            SqlCommand updateCmd = new SqlCommand(updateQuery, con, transaction);
                            updateCmd.Parameters.AddWithValue("@Name", itemName);
                            updateCmd.Parameters.AddWithValue("@Quantity", quantity);
                            updateCmd.Parameters.AddWithValue("@ExpiryDate", expiryDate);

                            updateCmd.ExecuteNonQuery();

                            // Insert into InventoryTransactions
                            string insertQuery = "INSERT INTO InventoryTransactions (InventoryID, Quantity, TotalPrice, TransactionType, TransactionDate) " +
                                                 "VALUES ((SELECT InventoryID FROM Inventory WHERE Name = @Name), @Quantity, @TotalPrice, 'Add', GETDATE())";
                            SqlCommand insertCmd = new SqlCommand(insertQuery, con, transaction);
                            insertCmd.Parameters.AddWithValue("@Name", itemName);
                            insertCmd.Parameters.AddWithValue("@Quantity", quantity);
                            insertCmd.Parameters.AddWithValue("@TotalPrice", totalPrice);

                            insertCmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }

                MessageBox.Show("Inventory updated successfully.");
                dgvAddedInventory.Rows.Clear();
                txtTotalPrice.Text = "$0.00"; // Reset total price
                LoadInventory(); // Refresh main inventory table
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error confirming import: {ex.Message}");
            }
        }

        // Update Usage Data
        private void btnUpdateUsage_Click(object sender, EventArgs e)
        {
            string itemName = cmbItemToUpdate.Text;
            int quantityUsed = (int)nudQuantityUsed.Value;

            if (string.IsNullOrEmpty(itemName) || quantityUsed <= 0)
            {
                MessageBox.Show("Please select an item and enter a valid quantity.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string validateQuery = "SELECT Quantity FROM Inventory WHERE Name = @Name";
                    SqlCommand validateCmd = new SqlCommand(validateQuery, con);
                    validateCmd.Parameters.AddWithValue("@Name", itemName);

                    con.Open();
                    int currentQuantity = Convert.ToInt32(validateCmd.ExecuteScalar());

                    if (currentQuantity < quantityUsed)
                    {
                        MessageBox.Show("Insufficient inventory for this usage.");
                        return;
                    }

                    string updateQuery = "UPDATE Inventory SET Quantity = Quantity - @QuantityUsed WHERE Name = @Name";
                    SqlCommand cmd = new SqlCommand(updateQuery, con);
                    cmd.Parameters.AddWithValue("@Name", itemName);
                    cmd.Parameters.AddWithValue("@QuantityUsed", quantityUsed);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Usage updated successfully.");
                LoadInventory();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating usage: {ex.Message}");
            }
        }
    }
}
