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
            flpTables.Controls.Clear();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT t.TableID, t.TableNumber, 
                   CASE 
                       WHEN EXISTS (SELECT 1 FROM Orders WHERE TableID = t.TableID AND Status = 'Active') THEN 'Have order'
                       ELSE t.Status
                   END AS TableStatus
            FROM Tables t";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string tableID = reader["TableID"].ToString();
                    string tableNumber = reader["TableNumber"].ToString();
                    string status = reader["TableStatus"].ToString().Trim();

                    Button btnTable = new Button
                    {
                        Text = $"{tableNumber}\n{status}",
                        Width = 100,  // Button width
                        Height = 100, // Button height
                        BackColor = GetTableColor(status),
                        Tag = new { TableID = tableID, TableNumber = tableNumber } // Store table data in Tag
                    };

                    btnTable.Click += (s, e) =>
                    {
                        // Extract the data from the button's Tag property
                        var tagData = (dynamic)((Button)s).Tag;
                        string clickedTableNumber = tagData.TableNumber;
                        string clickedTableID = tagData.TableID;

                        // Update the text box with the table number
                        txtTableNumber.Text = clickedTableNumber;

                        // Load order details for the clicked table
                        LoadOrderDetails(clickedTableID);
                    };

                    flpTables.Controls.Add(btnTable);
                }

                con.Close();
            }
        }


        private FlowLayoutPanel CreateNewRow()
        {
            return new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,   // Force buttons to stay in a single row
                AutoSize = true,        // Adjust size to fit buttons
                Height = 110,           // Fixed height for each row
                Width = flpTables.Width // Match parent panel width
            };
        }



        private Color GetTableColor(string status)
        {
            switch (status)
            {
                case "Occupied":
                    return Color.LightGreen;  // Green for tables with orders
                case "Empty":
                    return Color.LightGray;  // Gray for empty tables
                default:
                    return Color.LightGray;  // Default color
            }
        }



        private void LoadOrderDetails(string tableID)
        {
            dgvOrderDetails.Rows.Clear();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT m.Name AS ItemName, od.Quantity, od.Price
            FROM OrderDetails od
            INNER JOIN Menu m ON od.MenuItemID = m.MenuItemID
            WHERE od.OrderID IN 
                (SELECT OrderID FROM Orders WHERE TableID = @TableID)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TableID", tableID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dgvOrderDetails.Rows.Add(reader["ItemName"], reader["Quantity"], reader["Price"]);
                }

                con.Close();
            }
        }



        private void grpOrderDetails_Enter(object sender, EventArgs e)
        {

        }
    }
}
