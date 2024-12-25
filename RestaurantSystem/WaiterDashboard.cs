using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace RestaurantSystem
{
    public partial class WaiterDashboard : Form
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RestaurantDB;Integrated Security=True;";
        private UserControl currentForm; // Tracks the currently loaded form in pnlRightContent

        public WaiterDashboard()
        {
            InitializeComponent();
        }

        private void WaiterDashboard_Load(object sender, EventArgs e)
        {
            // Dock panels for responsive layout
            pnlSideBar.Dock = DockStyle.Left;
            flpTables.Dock = DockStyle.Fill;
            pnlRightContent.Dock = DockStyle.Right;

            // Load tables dynamically
            LoadTableGrid();
        }

        public void LoadTableGrid()
        {
            // Clear existing controls in the FlowLayoutPanel
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
                        // Capture the TableID and Status into local variables
                        string tableID = reader["TableID"].ToString();
                        string status = reader["Status"].ToString();

                        // Create a button for each table
                        Button btnTable = new Button
                        {
                            Name = "btn" + tableID,           // Unique name for the button
                            Text = $"{reader["TableNumber"]}\n{status}", // Display table number and status
                            Width = 120,                     // Button width
                            Height = 120,                    // Button height
                            BackColor = GetTableColor(status) // Set button color based on status
                        };

                        // Attach click event, passing the captured tableID and status
                        btnTable.Click += (s, e) => HandleTableButtonClick(tableID, status);

                        // Add the button to the FlowLayoutPanel
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

        private void HandleTableButtonClick(string tableID, string status)
        {
            // Pass the table details to the currently loaded form
            if (currentForm is BookingFormControl bookingForm)
            {
                bookingForm.LoadTableDetails(tableID, status);
            }
            else if (currentForm is OrderManagementControl orderForm)
            {
                orderForm.LoadTableDetails(tableID, status);
            }
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOrder_Click_1(object sender, EventArgs e)
        {
            // Load the Order Form (initially empty)
            var orderForm = new OrderManagementControl();
            LoadRightPanel(orderForm);
        }

        private void btnBookTable_Click_1(object sender, EventArgs e)
        {
            // Load the Booking Form (initially empty)
            var bookingForm = new BookingFormControl();
            LoadRightPanel(bookingForm);
        }
        private void pnlRightContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlSideBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flpTables_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


