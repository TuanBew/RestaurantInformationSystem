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
    public partial class ChefDashboard : Form
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RestaurantDB;Integrated Security=True;";

        public ChefDashboard()
        {
            InitializeComponent();
        }

        private void ChefDashboard_Load(object sender, EventArgs e)
        {
            LoadTableButtons();
        }

        private void LoadTableButtons()
        {
            flpTables.Controls.Clear(); // Clear any existing buttons
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT TableNumber, Status FROM Tables";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Create a button for each table
                    Button btnTable = new Button
                    {
                        Text = $"{reader["TableNumber"]}\n{reader["Status"]}",
                        Width = 120,
                        Height = 120,
                        BackColor = reader["Status"].ToString() == "Trống" ? Color.LightGray : Color.DarkGreen,
                        ForeColor = Color.White
                    };

                    flpTables.Controls.Add(btnTable); // Add the button to the FlowLayoutPanel
                }
                con.Close();
            }
        }
        
        private void LoadDynamicContent(UserControl control)
        {
            pnlMainContent.Controls.Clear(); // Clear existing controls
            control.Dock = DockStyle.Fill;      // Fill the panel
            pnlMainContent.Controls.Add(control); // Add the new control
        }

        private void btnReceiveOrders_Click(object sender, EventArgs e)
        {
            var ordersControl = new ReceiveOrdersControl();
            LoadDynamicContent(ordersControl);
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            var inventoryControl = new InventoryManagementControl();
            LoadDynamicContent(inventoryControl);
        }

        private void btnImportHistory_Click(object sender, EventArgs e)
        {
            var historyControl = new ImportHistoryControl();
            LoadDynamicContent(historyControl);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }
    }
}
