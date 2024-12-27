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
            LoadItemsIntoComboBox();
            LoadItemsIntoUpdateComboBox();
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

        private void LoadItemsIntoComboBox()
        {
            cmbItem.Items.Clear(); // Clear existing items to avoid duplication

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT Name FROM Inventory";
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        cmbItem.Items.Add(reader["Name"].ToString());
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadItemsIntoUpdateComboBox()
        {
            try
            {
                cmbItemToUpdate.Items.Clear(); // Clear existing items to avoid duplication

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT Name FROM Inventory";
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        cmbItemToUpdate.Items.Add(reader["Name"].ToString()); // Add each item name to the ComboBox
                    }

                    reader.Close();
                }

                if (cmbItemToUpdate.Items.Count > 0)
                {
                    cmbItemToUpdate.SelectedIndex = 0; // Automatically select the first item
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Please select an item and enter a valid quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                decimal unitPrice = 0;

                // Get the UnitPrice from the database
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT UnitPrice FROM Inventory WHERE Name = @Name";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", itemName);

                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show($"Item '{itemName}' does not exist in the inventory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    unitPrice = Convert.ToDecimal(result);
                }

                // Check if the item already exists in dgvAddedInventory
                foreach (DataGridViewRow row in dgvAddedInventory.Rows)
                {
                    if (row.Cells["Column6"].Value != null && row.Cells["Column6"].Value.ToString() == itemName)
                    {
                        int existingQuantity = int.Parse(row.Cells["Column7"].Value.ToString());
                        row.Cells["Column7"].Value = existingQuantity + quantity; // Update quantity
                        row.Cells["Column10"].Value = (unitPrice * (existingQuantity + quantity)).ToString("C"); // Update total price
                        UpdateTotalPrice(); // Update the total price in the form
                        return;
                    }
                }

                // Add new row to dgvAddedInventory
                decimal totalPrice = unitPrice * quantity;

                // Ensure the values are in the correct order:
                dgvAddedInventory.Rows.Add(
                    itemName,                             // Column6: Item Name
                    quantity,                             // Column7: Quantity
                    unitPrice.ToString("C"),              // Column8: Unit Price
                    expiryDate.ToString("dd/MM/yyyy"),    // Column9: Expiry Date
                    totalPrice.ToString("C")              // Column10: Total Price
                );

                // Update total price
                UpdateTotalPrice();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        // Update Total Price in TextBox
        private void UpdateTotalPrice()
        {
            decimal totalPrice = 0;

            foreach (DataGridViewRow row in dgvAddedInventory.Rows)
            {
                if (row.Cells["Column10"].Value != null)
                {
                    totalPrice += decimal.Parse(row.Cells["Column10"].Value.ToString(), System.Globalization.NumberStyles.Currency);
                }
            }

            txtTotalPrice.Text = totalPrice.ToString("C"); // Update the total price textbox
        }


        // Confirm Import to Database
        private void btnConfirmImport_Click(object sender, EventArgs e)
        {
            if (dgvAddedInventory.Rows.Count == 0)
            {
                MessageBox.Show("No items to confirm.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlTransaction transaction = con.BeginTransaction();

                    decimal totalCost = 0;

                    // Loop through the DataGridView rows and update the Inventory table
                    foreach (DataGridViewRow row in dgvAddedInventory.Rows)
                    {
                        if (row.Cells["Column6"].Value == null) continue;

                        string itemName = row.Cells["Column6"].Value.ToString(); // Column6: Item Name
                        int quantity = int.Parse(row.Cells["Column7"].Value.ToString()); // Column7: Quantity
                        decimal unitPrice = decimal.Parse(row.Cells["Column8"].Value.ToString(), System.Globalization.NumberStyles.Currency); // Column8: Unit Price
                        DateTime expiryDate = DateTime.Parse(row.Cells["Column9"].Value.ToString()); // Column9: Expiry Date

                        // Calculate the total cost for the current row
                        decimal rowTotalCost = quantity * unitPrice;
                        totalCost += rowTotalCost;

                        // Check if the item already exists in the Inventory table
                        string checkQuery = "SELECT COUNT(*) FROM Inventory WHERE Name = @Name";
                        SqlCommand checkCmd = new SqlCommand(checkQuery, con, transaction);
                        checkCmd.Parameters.AddWithValue("@Name", itemName);

                        int itemCount = (int)checkCmd.ExecuteScalar();

                        if (itemCount > 0)
                        {
                            // Update the existing item
                            string updateQuery = "UPDATE Inventory SET Quantity = Quantity + @Quantity, ExpiryDate = @ExpiryDate WHERE Name = @Name";
                            SqlCommand updateCmd = new SqlCommand(updateQuery, con, transaction);
                            updateCmd.Parameters.AddWithValue("@Name", itemName);
                            updateCmd.Parameters.AddWithValue("@Quantity", quantity);
                            updateCmd.Parameters.AddWithValue("@ExpiryDate", expiryDate);

                            updateCmd.ExecuteNonQuery();
                        }
                        else
                        {
                            // Insert a new item
                            string insertQuery = @"
                        INSERT INTO Inventory (Name, Quantity, UnitPrice, Unit, ExpiryDate) 
                        VALUES (@Name, @Quantity, @UnitPrice, 'Unit', @ExpiryDate)";
                            SqlCommand insertCmd = new SqlCommand(insertQuery, con, transaction);
                            insertCmd.Parameters.AddWithValue("@Name", itemName);
                            insertCmd.Parameters.AddWithValue("@Quantity", quantity);
                            insertCmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
                            insertCmd.Parameters.AddWithValue("@ExpiryDate", expiryDate);

                            insertCmd.ExecuteNonQuery();
                        }
                    }

                    // Insert the total cost and date of the import into the ImportHistory table
                    string historyQuery = "INSERT INTO ImportHistory (DateOfImport, TotalCost) VALUES (@DateOfImport, @TotalCost)";
                    SqlCommand historyCmd = new SqlCommand(historyQuery, con, transaction);
                    historyCmd.Parameters.AddWithValue("@DateOfImport", DateTime.Now);
                    historyCmd.Parameters.AddWithValue("@TotalCost", totalCost);

                    historyCmd.ExecuteNonQuery();

                    // Commit the transaction
                    transaction.Commit();
                }

                MessageBox.Show("Inventory updated successfully and import record added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the DataGridView and reset total cost
                dgvAddedInventory.Rows.Clear();
                txtTotalPrice.Text = "$0.00";

                // Reload the inventory list
                LoadInventory();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error confirming import: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
