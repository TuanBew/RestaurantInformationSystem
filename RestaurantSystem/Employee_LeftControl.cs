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
    public partial class Employee_LeftControl : UserControl
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RestaurantDB;Integrated Security=True;";
        private DataGridView employeeDataGridView; // Reference to DataGridView in Employee_RightControl

        public Employee_LeftControl()
        {
            InitializeComponent();
        }

        // Method to set the DataGridView reference from the parent form
        public void SetDataGridView(DataGridView dataGridView)
        {
            employeeDataGridView = dataGridView;
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            if (employeeDataGridView != null)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        // Insert a new user with default values (update as needed)
                        string query = "INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Username", "NewUser");
                        cmd.Parameters.AddWithValue("@Password", "default_password");
                        cmd.Parameters.AddWithValue("@Role", "User"); // Default role

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }

                    // Reload the data in the DataGridView
                    RefreshEmployeeDataGridView();
                    MessageBox.Show("New user added. Edit the details in the grid to customize.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding new user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("DataGridView reference is not set. Please contact the administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void remove_button_Click(object sender, EventArgs e)
        {
            if (employeeDataGridView != null)
            {
                if (employeeDataGridView.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Do you want to remove the selected user(s)?", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            foreach (DataGridViewRow row in employeeDataGridView.SelectedRows)
                            {
                                if (!row.IsNewRow)
                                {
                                    int userId = Convert.ToInt32(row.Cells["UserID"].Value); // Assumes column name is UserID
                                    using (SqlConnection con = new SqlConnection(connectionString))
                                    {
                                        string query = "DELETE FROM Users WHERE UserID = @UserID";
                                        SqlCommand cmd = new SqlCommand(query, con);
                                        cmd.Parameters.AddWithValue("@UserID", userId);
                                        con.Open();
                                        cmd.ExecuteNonQuery();
                                    }
                                    employeeDataGridView.Rows.Remove(row); // Remove from DataGridView
                                }
                            }

                            MessageBox.Show("Selected user(s) removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error removing user(s): {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select at least one row to remove.", "Remove User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("DataGridView reference is not set. Please contact the administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool isEditing = false; // Flag to track if editing is active
        private DataGridViewRow originalRow; // Store original data for cancelation

        private void edit_button_Click(object sender, EventArgs e)
        {
            if (employeeDataGridView != null && employeeDataGridView.SelectedRows.Count == 1)
            {
                if (isEditing)
                {
                    MessageBox.Show("You are already editing. Finish or cancel the current edit first.", "Edit User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = employeeDataGridView.SelectedRows[0];
                    if (selectedRow.IsNewRow)
                    {
                        MessageBox.Show("Cannot edit a new row. Please add it first.", "Edit User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Enter editing mode
                    isEditing = true;
                    originalRow = (DataGridViewRow)selectedRow.Clone();
                    for (int i = 0; i < selectedRow.Cells.Count; i++)
                    {
                        originalRow.Cells[i].Value = selectedRow.Cells[i].Value;
                    }

                    MessageBox.Show("You can now edit the selected row. Press Enter to save changes.", "Edit User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    employeeDataGridView.BeginEdit(true);

                    // Handle cell editing completion
                    employeeDataGridView.KeyDown += EmployeeDataGridView_KeyDown;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error editing user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a single row to edit.", "Edit User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Handle key events (e.g., Enter for save, Escape for cancel)
        private void EmployeeDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isEditing) return;

            if (e.KeyCode == Keys.Enter) // Confirm edit
            {
                try
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = employeeDataGridView.SelectedRows[0];

                    // Ensure column indices are correct
                    int userIdIndex = GetColumnIndex("UserID");
                    int usernameIndex = GetColumnIndex("Username");
                    int passwordIndex = GetColumnIndex("Password");
                    int roleIndex = GetColumnIndex("Role");

                    if (userIdIndex == -1 || usernameIndex == -1 || passwordIndex == -1 || roleIndex == -1)
                    {
                        MessageBox.Show("One or more required columns are missing or misconfigured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Extract values from the selected row
                    int userId = Convert.ToInt32(selectedRow.Cells[userIdIndex].Value);
                    string username = selectedRow.Cells[usernameIndex].Value?.ToString();
                    string password = selectedRow.Cells[passwordIndex].Value?.ToString();
                    string role = selectedRow.Cells[roleIndex].Value?.ToString();

                    // Validate data
                    if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(role))
                    {
                        MessageBox.Show("All fields must be filled out.", "Edit User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Save changes to the database
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string query = @"
                    UPDATE Users
                    SET Username = @Username, Password = @Password, Role = @Role
                    WHERE UserID = @UserID";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Role", role);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("User updated successfully!", "Edit User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Exit editing mode
                    isEditing = false;
                    employeeDataGridView.EndEdit();
                    employeeDataGridView.KeyDown -= EmployeeDataGridView_KeyDown;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show($"Column index issue: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.KeyCode == Keys.Escape) // Cancel edit
            {
                DialogResult result = MessageBox.Show("Do you want to cancel editing?", "Cancel Editing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = employeeDataGridView.SelectedRows[0];
                    for (int i = 0; i < originalRow.Cells.Count; i++)
                    {
                        selectedRow.Cells[i].Value = originalRow.Cells[i].Value;
                    }

                    isEditing = false;
                    employeeDataGridView.CancelEdit();
                    employeeDataGridView.KeyDown -= EmployeeDataGridView_KeyDown;
                    MessageBox.Show("Editing canceled.", "Cancel Editing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Helper function to get column index by name
        private int GetColumnIndex(string columnName)
        {
            if (employeeDataGridView.Columns.Contains(columnName))
            {
                return employeeDataGridView.Columns[columnName].Index;
            }
            return -1; // Column not found
        }

        private void employeeDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (employeeDataGridView != null)
            {
                try
                {
                    var row = employeeDataGridView.Rows[e.RowIndex];
                    int userId = Convert.ToInt32(row.Cells["UserID"].Value); // Assumes column name is UserID
                    string username = row.Cells["Username"].Value.ToString();
                    string password = row.Cells["Password"].Value.ToString();
                    string role = row.Cells["Role"].Value.ToString();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE Users SET Username = @Username, Password = @Password, Role = @Role WHERE UserID = @UserID";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Role", role);
                        cmd.Parameters.AddWithValue("@UserID", userId);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("User details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating user details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RefreshEmployeeDataGridView()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Users";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    employeeDataGridView.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing user data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Employee_LeftControl_Load(object sender, EventArgs e)
        {
            // Add any initialization code here if needed
        }

    }
}