using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace PharmacyManagement.UC_Supplier
{
    public partial class UC_Supplier : UserControl
    {
        public UC_Supplier()
        {
            InitializeComponent();
            this.BackColor = Color.MediumSeaGreen;
            dgvSuppliers.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvSuppliers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSuppliers.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

        }

        private void UC_Supplier_Load(object sender, EventArgs e)
        {
            LoadSuppliers();

            dgvSuppliers.BackgroundColor = Color.White;
            dgvSuppliers.BorderStyle = BorderStyle.None;
            dgvSuppliers.GridColor = Color.LightGray;

           
            dgvSuppliers.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSeaGreen;
            dgvSuppliers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSuppliers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dgvSuppliers.EnableHeadersVisualStyles = false;

            
            dgvSuppliers.DefaultCellStyle.BackColor = Color.White;
            dgvSuppliers.DefaultCellStyle.ForeColor = Color.Black;
            dgvSuppliers.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvSuppliers.DefaultCellStyle.SelectionBackColor = Color.LightGreen;
            dgvSuppliers.DefaultCellStyle.SelectionForeColor = Color.Black;

        
            dgvSuppliers.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#E0F2E9");

            
            dgvSuppliers.RowHeadersVisible = false;
            dgvSuppliers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;




        }


        private void LoadSuppliers()
        {
            
            string connectionString = "Data Source=DESKTOP-N0VN4S0\\SQLEXPRESS;Initial Catalog=PharmacyDB;Integrated Security=True";

            
            string query = "SELECT SupplierID, Name, ContactPerson, Phone, Email, Address FROM Suppliers";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    
                    dgvSuppliers.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void txtContactPerson_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void dgvSuppliers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

        }
    }

}
