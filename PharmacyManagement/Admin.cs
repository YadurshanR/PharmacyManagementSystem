using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyManagement
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            
            this.suppliersTableAdapter.Fill(this.pharmacyDBDataSet.Suppliers);
            uC_Dashboard1.Visible = false;
            uC_Supplier1.Visible = false;
            uC_Order1.Visible = false;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            pictureBox2.Visible = false;

            
            uC_Dashboard1.Visible = true;
            uC_Dashboard1.BringToFront();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uC_Dashboard1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            uC_Supplier1.Visible = true;
            uC_Supplier1.BringToFront();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            uC_Order1.Visible = true;
            uC_Order1.BringToFront();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
