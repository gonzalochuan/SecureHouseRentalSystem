using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SecureHouseRentalSystem
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text; // In production, hash the password!
            string role = cmbRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            using (var conn = new MySqlConnection("server=localhost;user=root;database=houserental;"))
            {
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO users (username, password_hash, role) VALUES (@u, SHA2(@p,256), @r)", conn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);
                cmd.Parameters.AddWithValue("@r", role);
                cmd.ExecuteNonQuery();
            }
            DialogResult = DialogResult.OK;
        }
    }
}