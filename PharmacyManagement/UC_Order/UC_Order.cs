using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace PharmacyManagement.UC_Order
{
    public partial class UC_Order : UserControl
    {
        public UC_Order()
        {
            InitializeComponent();
            LoadOrders();

        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadOrders()
        {
            string connectionString = "Data Source=DESKTOP-N0VN4S0\\SQLEXPRESS;Initial Catalog=PharmacyDB;Integrated Security=True";
            string query = "SELECT OrderID, OrderDate, HospitalPharmacyName, Status, ArrivalDate FROM Orders";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvOrders.DataSource = dt; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }





    }
}
