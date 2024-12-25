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
            Application.Exit(); // Exit the application
        }
    }
}
