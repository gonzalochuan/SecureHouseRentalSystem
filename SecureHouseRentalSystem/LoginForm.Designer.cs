namespace SecureHouseRentalSystem
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblCaptcha;
        private System.Windows.Forms.TextBox txtCaptcha;
        private System.Windows.Forms.CheckBox chkShowPassword;

        private void InitializeComponent()
        {
            this.panelCard = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblCaptcha = new System.Windows.Forms.Label();
            this.txtCaptcha = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.panelCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCard
            // 
            this.panelCard.BackColor = System.Drawing.Color.White;
            this.panelCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCard.Controls.Add(this.lblTitle);
            this.panelCard.Controls.Add(this.lblUsername);
            this.panelCard.Controls.Add(this.txtUsername);
            this.panelCard.Controls.Add(this.lblPassword);
            this.panelCard.Controls.Add(this.txtPassword);
            this.panelCard.Controls.Add(this.chkShowPassword);
            this.panelCard.Controls.Add(this.lblCaptcha);
            this.panelCard.Controls.Add(this.txtCaptcha);
            this.panelCard.Controls.Add(this.btnLogin);
            this.panelCard.Location = new System.Drawing.Point(40, 30);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(320, 340);
            this.panelCard.TabIndex = 0;
            this.panelCard.BackColor = System.Drawing.Color.FromArgb(245, 245, 250);
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Secure House Rental Login";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Size = new System.Drawing.Size(280, 35);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUsername
            // 
            this.lblUsername.Text = "Username";
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUsername.Location = new System.Drawing.Point(30, 70);
            this.lblUsername.Size = new System.Drawing.Size(80, 20);
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsername.Location = new System.Drawing.Point(30, 95);
            this.txtUsername.Size = new System.Drawing.Size(260, 25);
            // 
            // lblPassword
            // 
            this.lblPassword.Text = "Password";
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPassword.Location = new System.Drawing.Point(30, 130);
            this.lblPassword.Size = new System.Drawing.Size(80, 20);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(30, 155);
            this.txtPassword.Size = new System.Drawing.Size(260, 25);
            this.txtPassword.PasswordChar = '*';
            // 
            // chkShowPassword
            // 
            this.chkShowPassword.Text = "Show Password";
            this.chkShowPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkShowPassword.Location = new System.Drawing.Point(30, 185);
            this.chkShowPassword.Size = new System.Drawing.Size(120, 20);
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            // 
            // lblCaptcha
            // 
            this.lblCaptcha.Text = "0000";
            this.lblCaptcha.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCaptcha.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.lblCaptcha.BackColor = System.Drawing.Color.FromArgb(230, 236, 240);
            this.lblCaptcha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCaptcha.Location = new System.Drawing.Point(30, 215);
            this.lblCaptcha.Size = new System.Drawing.Size(100, 35);
            // 
            // txtCaptcha
            // 
            this.txtCaptcha.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCaptcha.Location = new System.Drawing.Point(150, 220);
            this.txtCaptcha.Size = new System.Drawing.Size(140, 25);
            // 
            // btnLogin
            // 
            this.btnLogin.Text = "Login";
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Location = new System.Drawing.Point(30, 270);
            this.btnLogin.Size = new System.Drawing.Size(260, 40);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // LoginForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(230, 236, 240);
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.panelCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LoginForm";
            this.Text = "Secure House Rental Login";
            this.ResumeLayout(false);
        }
    }
}