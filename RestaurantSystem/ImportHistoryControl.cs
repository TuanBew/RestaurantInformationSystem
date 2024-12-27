using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantSystem
{
    public partial class ImportHistoryControl : UserControl
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RestaurantDB;Integrated Security=True;";

        public ImportHistoryControl()
        {
            InitializeComponent();
        }

        private void ImportHistoryControl_Load(object sender, EventArgs e)
        {
            LoadImportHistory();
        }


        private void LoadImportHistory()
        {

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT DateOfImport, TotalCost FROM ImportHistory";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dataTable = new DataTable();

                    con.Open();
                    adapter.Fill(dataTable);

                    dgvImportHistory.DataSource = dataTable;

                    // Calculate total revenue for all records
                    CalculateTotalRevenue(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading import history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateTotalRevenue(DataTable dataTable)
        {
            decimal totalRevenue = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                totalRevenue += row.Field<decimal>("TotalCost");
            }

            txtTotalRevenue.Text = totalRevenue.ToString("C", CultureInfo.CurrentCulture); // Update total revenue textbox
        }

        private void btnConfirmDateSelection_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStartDate.Value.Date; // Start date from the date picker
            DateTime endDate = dtpEndDate.Value.Date;    // End date from the date picker

            if (startDate > endDate)
            {
                MessageBox.Show("Start date must be earlier than or equal to the end date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"
                SELECT DateOfImport, TotalCost
                FROM ImportHistory
                WHERE DateOfImport BETWEEN @StartDate AND @EndDate";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();

                    con.Open();
                    adapter.Fill(dataTable);

                    // Bind the filtered data to the DataGridView
                    dgvImportHistory.DataSource = dataTable;

                    // Calculate the total revenue for the filtered records
                    CalculateTotalRevenue(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering import history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
