using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PharmacyManagement.AdministratorUC
{
    public partial class UC_Dashboard : UserControl
    {
        private string connectionString = "Data Source=DESKTOP-N0VN4S0\\SQLEXPRESS;Initial Catalog=PharmacyDB;Integrated Security=True";
        private System.Windows.Forms.Timer refreshTimer;

        public UC_Dashboard()
        {
            InitializeComponent();
            this.Load += UC_Dashboard_Load; // Attach the Load event handler
        }

        // Handle the Load event to ensure the control is fully initialized
        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            LoadDashboardData(); // Load data initially
            StartRealTimeUpdates(); // Start the timer for real-time updates
        }

        // Start the timer for real-time updates
        private void StartRealTimeUpdates()
        {
            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 5000; 
            refreshTimer.Tick += (s, e) => LoadDashboardData(); 
            refreshTimer.Start();
        }
        private void LoadDashboardData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    System.Diagnostics.Debug.WriteLine("Connected to PharmacyDB"); // Prints in VS Output Window

                    int outOfStock = GetProductCount(conn, "SELECT COUNT(*) FROM Products WHERE QuantityInStock = 0");
                    int lowStock = GetProductCount(conn, "SELECT COUNT(*) FROM Products WHERE QuantityInStock > 0 AND QuantityInStock <= ReorderLevel");
                    int arrivingProducts = GetProductCount(conn, "SELECT COUNT(*) FROM Orders WHERE ArrivalDate IS NOT NULL AND ArrivalDate >= GETDATE()");

                    // Debugging: Print values in Visual Studio Output Window
                    System.Diagnostics.Debug.WriteLine($"Out of Stock: {outOfStock}");
                    System.Diagnostics.Debug.WriteLine($"Low Stock: {lowStock}");
                    System.Diagnostics.Debug.WriteLine($"Arriving Products: {arrivingProducts}");

                    // Update Labels
                    lblOutOfStock.Text = outOfStock.ToString();
                    lblLowStock.Text = lowStock.ToString();
                    lblArrivingProducts.Text = arrivingProducts.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        // Helper method to execute a query and return a count
        private int GetProductCount(SqlConnection conn, string query)
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Optional: Handle the PictureBox click event (if you want a manual refresh button)
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            LoadDashboardData(); // Refresh data manually
        }

        // Clean up the timer when the control is disposed
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                refreshTimer?.Stop();
                refreshTimer?.Dispose();
            }
            base.Dispose(disposing);
        }

        // Rest of your existing code remains unchanged
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            using (GraphicsPath path = new GraphicsPath())
            using (Pen borderPen = new Pen(Color.Black, 3))
            using (SolidBrush whiteBrush = new SolidBrush(Color.White))
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
            {
                int radius = panel1.Height / 2;
                Rectangle rect = panel1.ClientRectangle;
                rect.Width -= 1;
                rect.Height -= 1;

                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.TranslateTransform(3, 3);
                e.Graphics.FillPath(shadowBrush, path);
                e.Graphics.TranslateTransform(-3, -3);
                e.Graphics.FillPath(whiteBrush, path);
                e.Graphics.DrawPath(borderPen, path);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            using (GraphicsPath path = new GraphicsPath())
            using (Pen borderPen = new Pen(Color.Black, 2))
            using (SolidBrush whiteBrush = new SolidBrush(Color.White))
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
            {
                int radius = 20;
                Rectangle rect = panel2.ClientRectangle;
                rect.Width -= 1;
                rect.Height -= 1;

                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.TranslateTransform(3, 3);
                e.Graphics.FillPath(shadowBrush, path);
                e.Graphics.TranslateTransform(-3, -3);
                e.Graphics.FillPath(whiteBrush, path);
                e.Graphics.DrawPath(borderPen, path);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void guna2PictureBox1_Click(object sender, EventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            using (GraphicsPath path = new GraphicsPath())
            using (Pen borderPen = new Pen(Color.Black, 3))
            using (SolidBrush whiteBrush = new SolidBrush(Color.White))
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
            {
                int radius = 20;
                Rectangle rect = panel2.ClientRectangle;
                rect.Width -= 1;
                rect.Height -= 1;

                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.TranslateTransform(3, 3);
                e.Graphics.FillPath(shadowBrush, path);
                e.Graphics.TranslateTransform(-3, -3);
                e.Graphics.FillPath(whiteBrush, path);
                e.Graphics.DrawPath(borderPen, path);
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            using (GraphicsPath path = new GraphicsPath())
            using (Pen borderPen = new Pen(Color.Black, 2))
            using (SolidBrush whiteBrush = new SolidBrush(Color.White))
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
            {
                int radius = 20;
                Rectangle rect = panel2.ClientRectangle;
                rect.Width -= 1;
                rect.Height -= 1;

                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.TranslateTransform(3, 3);
                e.Graphics.FillPath(shadowBrush, path);
                e.Graphics.TranslateTransform(-3, -3);
                e.Graphics.FillPath(whiteBrush, path);
                e.Graphics.DrawPath(borderPen, path);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e) { }

        private void LoadInventoryData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    lblOutOfStock.Text = GetProductCount(con, "SELECT COUNT(*) FROM Products WHERE QuantityInStock = 0").ToString();
                    lblLowStock.Text = GetProductCount(con, "SELECT COUNT(*) FROM Products WHERE QuantityInStock > 0 AND QuantityInStock <= ReorderLevel").ToString();
                    lblArrivingProducts.Text = GetProductCount(con, "SELECT COUNT(*) FROM Orders WHERE ArrivalDate IS NOT NULL AND ArrivalDate >= GETDATE()").ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing inventory data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblArrivingProducts_Click(object sender, EventArgs e) { }

        private void lbOutOfStock_Click(object sender, EventArgs e) { }

        private void lblOutOfStock_Click(object sender, EventArgs e) { }
    }
}