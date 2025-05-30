using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SecureHouseRentalSystem
{
    public partial class HousesForm : Form
    {
        private readonly string _role;
        private readonly string _username;

        public HousesForm(string role, string username)
        {
            _role = role;
            _username = username;
            InitializeComponent();
            LoadHouses();
            ApplyRoleAccess();
        }

        private void ApplyRoleAccess()
        {
            // Both admin and staff can use all features
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnRent.Enabled = true;
        }

        private void LoadHouses()
        {
            using (var conn = new MySqlConnection("server=localhost;user=root;database=houserental;"))
            {
                conn.Open();
                var da = new MySqlDataAdapter("SELECT * FROM houses", conn);
                var dt = new DataTable();
                da.Fill(dt);
                dgvHouses.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new HouseEditForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadHouses();
                AuditLog("Added a house");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvHouses.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvHouses.CurrentRow.Cells["id"].Value);
            var editForm = new HouseEditForm(id);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadHouses();
                AuditLog($"Edited house ID {id}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvHouses.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvHouses.CurrentRow.Cells["id"].Value);
            if (MessageBox.Show("Delete this house?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var conn = new MySqlConnection("server=localhost;user=root;database=houserental;"))
                {
                    conn.Open();
                    var cmd = new MySqlCommand("DELETE FROM houses WHERE id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                LoadHouses();
                AuditLog($"Deleted house ID {id}");
            }
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            if (dgvHouses.CurrentRow == null) return;
            int houseId = Convert.ToInt32(dgvHouses.CurrentRow.Cells["id"].Value);

            using (var conn = new MySqlConnection("server=localhost;user=root;database=houserental;"))
            {
                conn.Open();

                // Check if house is already rented
                var checkCmd = new MySqlCommand("SELECT status FROM houses WHERE id=@id", conn);
                checkCmd.Parameters.AddWithValue("@id", houseId);
                var status = checkCmd.ExecuteScalar()?.ToString();
                if (status == "rented")
                {
                    MessageBox.Show("This house is already rented.");
                    return;
                }

                // Get current user id
                int userId = GetCurrentUserId(_username, conn);

                // Insert rental record
                var cmd = new MySqlCommand("INSERT INTO rentals (user_id, house_id, rent_date) VALUES (@uid, @hid, @date)", conn);
                cmd.Parameters.AddWithValue("@uid", userId);
                cmd.Parameters.AddWithValue("@hid", houseId);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.ExecuteNonQuery();

                // Update house status to 'rented'
                var updateCmd = new MySqlCommand("UPDATE houses SET status='rented' WHERE id=@id", conn);
                updateCmd.Parameters.AddWithValue("@id", houseId);
                updateCmd.ExecuteNonQuery();

                MessageBox.Show("House rented successfully!");
                LoadHouses();
                AuditLog($"Rented house ID {houseId}");
            }
        }

        private int GetCurrentUserId(string username, MySqlConnection conn)
        {
            var cmd = new MySqlCommand("SELECT id FROM users WHERE username=@u", conn);
            cmd.Parameters.AddWithValue("@u", username);
            var result = cmd.ExecuteScalar();
            return Convert.ToInt32(result);
        }

        private void AuditLog(string action)
        {
            try
            {
                using (var conn = new MySqlConnection("server=localhost;user=root;database=houserental;"))
                {
                    conn.Open();
                    var cmd = new MySqlCommand("INSERT INTO audit_log (username, action) VALUES (@u, @a)", conn);
                    cmd.Parameters.AddWithValue("@u", _username);
                    cmd.Parameters.AddWithValue("@a", action);
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                // Optionally handle/log error
            }
        }
    }
}