using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace SecureHouseRentalSystem
{
    public partial class HouseEditForm : Form
    {
        private int? _houseId = null;

        public HouseEditForm()
        {
            InitializeComponent();
        }

        public HouseEditForm(int houseId)
        {
            InitializeComponent();
            _houseId = houseId;
            LoadHouse();
        }

        private void LoadHouse()
        {
            using (var conn = new MySqlConnection("server=localhost;user=root;database=houserental;"))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM houses WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", _houseId);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtAddress.Text = reader["address"].ToString();
                        txtDescription.Text = reader["description"].ToString();
                        txtPrice.Text = reader["price"].ToString();
                        cmbStatus.SelectedItem = reader["status"].ToString();
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var conn = new MySqlConnection("server=localhost;user=root;database=houserental;"))
            {
                conn.Open();
                MySqlCommand cmd;
                if (_houseId == null)
                {
                    cmd = new MySqlCommand("INSERT INTO houses (address, description, price, status) VALUES (@a, @d, @p, @s)", conn);
                }
                else
                {
                    cmd = new MySqlCommand("UPDATE houses SET address=@a, description=@d, price=@p, status=@s WHERE id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", _houseId);
                }
                cmd.Parameters.AddWithValue("@a", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@d", txtDescription.Text.Trim());

                decimal price;
                if (!decimal.TryParse(txtPrice.Text, out price))
                {
                    MessageBox.Show("Please enter a valid price.");
                    return;
                }
                if (cmbStatus.SelectedItem == null)
                {
                    MessageBox.Show("Please select a status.");
                    return;
                }
                cmd.Parameters.AddWithValue("@p", price);
                cmd.Parameters.AddWithValue("@s", cmbStatus.SelectedItem.ToString());

                cmd.ExecuteNonQuery();
            }
            DialogResult = DialogResult.OK;
        }
    }
}