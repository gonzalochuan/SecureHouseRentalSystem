using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SecureHouseRentalSystem
{
    public partial class AuditLogForm : Form
    {
        public AuditLogForm()
        {
            InitializeComponent();
            LoadAuditLog();
        }

        private void LoadAuditLog()
        {
            using (var conn = new MySqlConnection("server=localhost;user=root;database=houserental;"))
            {
                conn.Open();
                var da = new MySqlDataAdapter("SELECT username, action, timestamp FROM audit_log ORDER BY timestamp DESC", conn);
                var dt = new DataTable();
                da.Fill(dt);
                dgvAuditLog.DataSource = dt;
            }
        }
    }
}