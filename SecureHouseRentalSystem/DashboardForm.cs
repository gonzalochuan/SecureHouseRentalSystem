using System;
using System.Windows.Forms;

namespace SecureHouseRentalSystem
{
    public partial class DashboardForm : Form
    {
        private string _username;
        private string _role;

        public DashboardForm(string username, string role)
        {
            _username = username;
            _role = role;
            InitializeComponent();
            lblWelcome.Text = $"Welcome, {_username} ({_role})";
            if (_role != "admin")
            {
                btnUsers.Visible = false;
                btnAuditLog.Visible = false;
            }
        }

        private void btnHouses_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            var houses = new HousesForm(_role, _username);
            houses.TopLevel = false;
            houses.FormBorderStyle = FormBorderStyle.None;
            houses.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(houses);
            houses.Show();
        }

        private void btnRentals_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            var rentals = new RentalsForm(_role, _username);
            rentals.TopLevel = false;
            rentals.FormBorderStyle = FormBorderStyle.None;
            rentals.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(rentals);
            rentals.Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            var users = new UsersForm();
            users.TopLevel = false;
            users.FormBorderStyle = FormBorderStyle.None;
            users.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(users);
            users.Show();
        }

        private void btnAuditLog_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            var audit = new AuditLogForm();
            audit.TopLevel = false;
            audit.FormBorderStyle = FormBorderStyle.None;
            audit.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(audit);
            audit.Show();
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }
    }
}