namespace SecureHouseRentalSystem
{
    partial class RentalsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvRentals;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnAddRental;

        private void InitializeComponent()
        {
            this.dgvRentals = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnAddRental = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentals)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRentals
            // 
            this.dgvRentals.AllowUserToAddRows = false;
            this.dgvRentals.AllowUserToDeleteRows = false;
            this.dgvRentals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRentals.Location = new System.Drawing.Point(10, 10);
            this.dgvRentals.Name = "dgvRentals";
            this.dgvRentals.ReadOnly = true;
            this.dgvRentals.Size = new System.Drawing.Size(700, 350);
            this.dgvRentals.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(10, 370);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(120, 30);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Save List (Excel)";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnAddRental
            // 
            this.btnAddRental.Location = new System.Drawing.Point(140, 370);
            this.btnAddRental.Name = "btnAddRental";
            this.btnAddRental.Size = new System.Drawing.Size(120, 30);
            this.btnAddRental.TabIndex = 2;
            this.btnAddRental.Text = "Add Rental";
            this.btnAddRental.UseVisualStyleBackColor = true;
            this.btnAddRental.Click += new System.EventHandler(this.btnAddRental_Click);
            // 
            // RentalsForm
            // 
            this.ClientSize = new System.Drawing.Size(720, 410);
            this.Controls.Add(this.dgvRentals);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnAddRental);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RentalsForm";
            this.Text = "Rentals";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentals)).EndInit();
            this.ResumeLayout(false);
        }
    }
}