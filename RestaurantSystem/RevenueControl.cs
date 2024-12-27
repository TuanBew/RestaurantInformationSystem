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
    public partial class RevenueControl : UserControl
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RestaurantDB;Integrated Security=True;"; // Replace with your actual connection string
        public RevenueControl()
        {
            InitializeComponent();
            LoadPaymentData();
        }

        private void LoadPaymentData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Payment";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable paymentTable = new DataTable();
                    adapter.Fill(paymentTable);

                    revenue_dataGridView.DataSource = paymentTable;
                    revenue_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }

                // Automatically calculate and display the total revenue
                label1_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Payment data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void revenue_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                // Initialize the sum variable
                decimal totalRevenue = 0;

                // Loop through the rows in the DataGridView
                foreach (DataGridViewRow row in revenue_dataGridView.Rows)
                {
                    // Check if the row is not a new row (to avoid issues with the empty last row)
                    if (!row.IsNewRow)
                    {
                        // Parse the value from the "total" column and add it to the sum
                        if (row.Cells["total"].Value != null &&
                            decimal.TryParse(row.Cells["total"].Value.ToString(), out decimal value))
                        {
                            totalRevenue += value;
                        }
                    }
                }

                // Display the total revenue in the label
                label1.Text = $"TOTAL REVENUE: {totalRevenue:C}"; // ":C" formats as currency
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating total revenue: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
