using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace SecureHouseRentalSystem
{
    public partial class RentalsForm : Form
    {
        private string _role;
        private string _username;
        private DataTable _rentalsTable;

        public RentalsForm(string role, string username)
        {
            _role = role;
            _username = username;
            InitializeComponent();
            dgvRentals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRentals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            LoadRentals();
        }

        private void LoadRentals()
        {
            try
            {
                using (var conn = new MySqlConnection("server=localhost;user=root;database=houserental;"))
                {
                    conn.Open();
                    string query = _role == "admin"
                        ? @"SELECT r.id AS 'Rental ID', u.username AS 'User', h.address AS 'Address', h.description AS 'Description', 
                                h.price AS 'Price', h.status AS 'Status', r.rent_date AS 'Rent Date', r.return_date AS 'Return Date'
                            FROM rentals r 
                            JOIN users u ON r.user_id=u.id 
                            JOIN houses h ON r.house_id=h.id"
                        : @"SELECT r.id AS 'Rental ID', u.username AS 'User', h.address AS 'Address', h.description AS 'Description', 
                                h.price AS 'Price', h.status AS 'Status', r.rent_date AS 'Rent Date', r.return_date AS 'Return Date'
                            FROM rentals r 
                            JOIN users u ON r.user_id=u.id 
                            JOIN houses h ON r.house_id=h.id 
                            WHERE u.username=@username";
                    var da = new MySqlDataAdapter(query, conn);
                    if (_role != "admin")
                        da.SelectCommand.Parameters.AddWithValue("@username", _username);
                    _rentalsTable = new DataTable();
                    da.Fill(_rentalsTable);
                    dgvRentals.DataSource = _rentalsTable;

                    if (_rentalsTable.Rows.Count == 0)
                        MessageBox.Show("No rental records found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rentals: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_rentalsTable == null || _rentalsTable.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.");
                return;
            }
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel CSV|*.csv", FileName = "Rentals.csv" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName))
                        {
                            // Write header
                            for (int i = 0; i < _rentalsTable.Columns.Count; i++)
                            {
                                sw.Write(_rentalsTable.Columns[i]);
                                if (i < _rentalsTable.Columns.Count - 1)
                                    sw.Write(",");
                            }
                            sw.WriteLine();
                            // Write rows
                            foreach (DataRow row in _rentalsTable.Rows)
                            {
                                for (int i = 0; i < _rentalsTable.Columns.Count; i++)
                                {
                                    // Escape commas in data
                                    string value = row[i].ToString().Replace(",", " ");
                                    sw.Write(value);
                                    if (i < _rentalsTable.Columns.Count - 1)
                                        sw.Write(",");
                                }
                                sw.WriteLine();
                            }
                        }
                        MessageBox.Show("Exported successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Export failed: " + ex.Message);
                    }
                }
            }
        }
        private void btnAddRental_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To add a rental, please use the 'Rent' button in the Houses form.");
            // Or implement a dialog to add a rental manually if you want.
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRentals();
        }
    }
}