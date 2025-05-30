using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

namespace SecureHouseRentalSystem
{
    public partial class LoginForm : Form
    {
        private int loginAttempts = 0;
        private const int MaxAttempts = 5;
        private string captchaText = "";
        private System.Timers.Timer lockoutTimer;

        public LoginForm()
        {
            InitializeComponent();
            GenerateCaptcha();
            txtPassword.PasswordChar = '*';
        }

        private void GenerateCaptcha()
        {
            Random rand = new Random();
            captchaText = rand.Next(1000, 9999).ToString();
            lblCaptcha.Text = captchaText;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Input validation
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                loginAttempts++;
                ShowAttemptWarning("Username and password are required.");
                return;
            }

            if (txtCaptcha.Text != captchaText)
            {
                loginAttempts++;
                ShowAttemptWarning("Invalid CAPTCHA.");
                GenerateCaptcha();
                return;
            }

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            using (var conn = new MySqlConnection("server=localhost;user=root;database=houserental;"))
            {
                conn.Open();

                // Check if account is locked
                var lockCmd = new MySqlCommand("SELECT locked FROM users WHERE username=@u", conn);
                lockCmd.Parameters.AddWithValue("@u", username);
                var lockedObj = lockCmd.ExecuteScalar();
                if (lockedObj != null && Convert.ToBoolean(lockedObj))
                {
                    MessageBox.Show("Account is locked. Please contact admin.");
                    return;
                }

                var cmd = new MySqlCommand("SELECT * FROM users WHERE username=@u AND password_hash=SHA2(@p,256)", conn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string role = reader["role"].ToString();
                    AuditLog(username, "Login Success");
                    this.Hide();
                    new DashboardForm(username, role).Show();
                }
                else
                {
                    loginAttempts++;
                    ShowAttemptWarning("Invalid username or password.");
                    AuditLog(username, "Login Failed");
                }
            }
        }

        private void ShowAttemptWarning(string message)
        {
            if (loginAttempts >= MaxAttempts)
            {
                btnLogin.Enabled = false;
                MessageBox.Show($"Too many failed attempts. Login disabled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Optionally, start a timer to re-enable after a period:
                // StartLockoutTimer();
            }
            else
            {
                MessageBox.Show($"{message}\nAttempt {loginAttempts} of {MaxAttempts}.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GenerateCaptcha();
            }
        }

        // Optional: Timer to re-enable login after lockout
        private void StartLockoutTimer()
        {
            lockoutTimer = new System.Timers.Timer();
            lockoutTimer.Interval = 60000; // 60 seconds
            lockoutTimer.Elapsed += LockoutTimer_Elapsed;
            lockoutTimer.AutoReset = false;
            lockoutTimer.Start();
        }

        private void LockoutTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => btnLogin.Enabled = true));
            }
            else
            {
                btnLogin.Enabled = true;
            }
            loginAttempts = 0;
        }

        private void AuditLog(string username, string action)
        {
            using (var conn = new MySqlConnection("server=localhost;user=root;database=houserental;"))
            {
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO audit_log (username, action) VALUES (@u, @a)", conn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@a", action);
                cmd.ExecuteNonQuery();
            }
        }
    }
}