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
    public partial class ManagerDashboard : Form
    {

        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RestaurantDB;Integrated Security=True;";
        private UserControl currentForm;
        public ManagerDashboard()
        {
            InitializeComponent();
        }

        private void LoadTableGrid()
        {
            flpTables.Controls.Clear();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Tables";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string tableID = reader["TableID"].ToString();
                        string tableNumber = reader["TableNumber"].ToString();
                        string status = reader["Status"].ToString();

                        Button btnTable = new Button
                        {
                            Name = "btn" + tableID,
                            Text = $"{tableNumber}\n{status}",
                            Width = 120,
                            Height = 120,
                            BackColor = GetTableColor(status),
                        };

                        btnTable.Click += (s, e) => HandleTableButtonClick(tableID, tableNumber, status);

                        flpTables.Controls.Add(btnTable);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading tables: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleTableButtonClick(string tableID, string tableNumber, string status)
        {
            if (status == "Empty")
            {
                MessageBox.Show("This table is empty and has no associated bookings.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"
                SELECT 
                    b.BookingID, b.CustomerName, b.ContactNumber, b.Notes, 
                    o.OrderID, m.Name AS DishName, m.Category, od.Quantity, od.Price, o.OrderStatus
                FROM 
                    Bookings b
                INNER JOIN 
                    Orders o ON b.BookingID = o.BookingID
                INNER JOIN 
                    OrderDetails od ON o.OrderID = od.OrderID
                INNER JOIN 
                    Menu m ON od.MenuItemID = m.MenuItemID
                WHERE 
                    b.TableID = @TableID AND b.Status = 'Active' AND b.BookingID = o.BookingID";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@TableID", tableID);
                    con.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        var paymentForm = new PaymentManagementControl
                        {
                            BookingData = dataTable,
                            TableID = tableID,
                            TotalAmount = CalculateTotal(dataTable)
                        };

                        LoadRightPanel(paymentForm);
                    }
                    else
                    {
                        MessageBox.Show("No orders or bookings found for this table.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching table data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private decimal CalculateTotal(DataTable dataTable)
        {
            decimal total = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                total += Convert.ToDecimal(row["Quantity"]) * Convert.ToDecimal(row["Price"]);
            }

            return total;
        }

        private void ResetRightPanel()
        {
            pnlRightContent.Controls.Clear();
            flpTables.Controls.Clear();
            currentForm = null; // Clear current form reference
        }

        private void btnOtherFeature_Click(object sender, EventArgs e)
        {
            ResetRightPanel();
            // Load the appropriate form or perform the action for the other feature
        }


        private Color GetTableColor(string status)
        {
            switch (status)
            {
                case "Occupied": return Color.DarkGreen;
                case "Reserved": return Color.Orange;
                default: return Color.LightGray;
            }
        }

        private void LoadRightPanel(UserControl control)
        {
            // Clear the existing panel and load the specified control
            pnlRightContent.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnlRightContent.Controls.Add(control);
            currentForm = control; // Track the current form
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            ResetRightPanel(); // Clear right panel
            var revenuecontrol = new RevenueControl();

            flpTables.Controls.Clear();
            pnlRightContent.Controls.Add(revenuecontrol);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ResetRightPanel(); // Ensure the right panel is cleared first

                // Create instances of the left and right controls
                var employeeLeftControl = new Employee_LeftControl();
                var employeeRightControl = new Employee_RightControl();

                // Set the DataGridView reference from the right control to the left control
                employeeLeftControl.SetDataGridView(employeeRightControl.EmployeeDataGridView);

                // Load Employee_LeftControl into flpTables
                flpTables.Controls.Clear();
                flpTables.Controls.Add(employeeLeftControl);

                // Load Employee_RightControl into pnlRightContent
                pnlRightContent.Controls.Clear();
                pnlRightContent.Controls.Add(employeeRightControl);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employee controls: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void flpTables_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBookTable_Click(object sender, EventArgs e)
        {
            ResetRightPanel(); // Clear right panel
            LoadTableGrid();
            var paymentForm = new PaymentManagementControl();
            LoadRightPanel(paymentForm);
        }

        public void ReloadUI()
        {
            // Reload table grid
            LoadTableGrid();

            // Clear the right panel
            pnlRightContent.Controls.Clear();
        }


        private void pnlRightContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetRightPanel(); // Clear right panel
        }
    }
}
