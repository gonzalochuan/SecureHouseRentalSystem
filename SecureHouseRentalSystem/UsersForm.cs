using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SecureHouseRentalSystem
{
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            using (var conn = new MySqlConnection("server=localhost;user=root;database=houserental;"))
            {
                conn.Open();
                var da = new MySqlDataAdapter("SELECT id, username, role, created_at FROM users", conn);
                var dt = new DataTable();
                da.Fill(dt);
                dgvUsers.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddUserForm();
            if (addForm.ShowDialog() == DialogResult.OK)
                LoadUsers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells["id"].Value);
            if (MessageBox.Show("Delete this user?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var conn = new MySqlConnection("server=localhost;user=root;database=houserental;"))
                {
                    conn.Open();
                    var cmd = new MySqlCommand("DELETE FROM users WHERE id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                LoadUsers();
            }
        }

        private void btnSetRole_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells["id"].Value);
            string newRole = cmbRole.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(newRole)) return;
            using (var conn = new MySqlConnection("server=localhost;user=root;database=houserental;"))
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE users SET role=@role WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@role", newRole);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            LoadUsers();
        }
    }
}