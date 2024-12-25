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
    public partial class ReceiveOrdersControl : UserControl
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RestaurantDB;Integrated Security=True;";
        
        public ReceiveOrdersControl()
        {
            InitializeComponent();
            LoadTables();
        }


        private void LoadTables()
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
                        BackColor = reader["Status"].ToString() == "Clear" ? Color.LightGray : Color.DarkGreen,
                        ForeColor = Color.White
                    };

                    flpTables.Controls.Add(btnTable); // Add the button to the FlowLayoutPanel
                }
                con.Close();
            }
        }

        private void LoadOrderDetails(string tableNumber)
        {
            dgvOrderDetails.Rows.Clear();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"
                SELECT M.Name AS DishName, OD.Quantity
                FROM Orders O
                INNER JOIN OrderDetails OD ON O.OrderID = OD.OrderID
                INNER JOIN Menu M ON OD.MenuItemID = M.MenuItemID
                INNER JOIN Tables T ON O.TableID = T.TableID
                WHERE T.TableNumber = @TableNumber";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@TableNumber", tableNumber);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        dgvOrderDetails.Rows.Add(reader["DishName"], reader["Quantity"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading order details: {ex.Message}");
            }
        }


        private void grpOrderDetails_Enter(object sender, EventArgs e)
        {

        }
    }
}
