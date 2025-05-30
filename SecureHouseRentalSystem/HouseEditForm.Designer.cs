namespace SecureHouseRentalSystem
{
    partial class HouseEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnSave;

        private void InitializeComponent()
        {
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAddress
            // 
            this.lblAddress.Text = "Address:";
            this.lblAddress.Location = new System.Drawing.Point(20, 20);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(120, 20);
            this.txtAddress.Size = new System.Drawing.Size(200, 20);
            // 
            // lblDescription
            // 
            this.lblDescription.Text = "Description:";
            this.lblDescription.Location = new System.Drawing.Point(20, 60);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(120, 60);
            this.txtDescription.Size = new System.Drawing.Size(200, 20);
            // 
            // lblPrice
            // 
            this.lblPrice.Text = "Price:";
            this.lblPrice.Location = new System.Drawing.Point(20, 100);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(120, 100);
            this.txtPrice.Size = new System.Drawing.Size(200, 20);
            // 
            // lblStatus
            // 
            this.lblStatus.Text = "Status:";
            this.lblStatus.Location = new System.Drawing.Point(20, 140);
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Items.AddRange(new object[] { "available", "rented" });
            this.cmbStatus.Location = new System.Drawing.Point(120, 140);
            this.cmbStatus.Size = new System.Drawing.Size(200, 21);
            // 
            // btnSave
            // 
            this.btnSave.Text = "Save";
            this.btnSave.Location = new System.Drawing.Point(120, 180);
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // HouseEditForm
            // 
            this.ClientSize = new System.Drawing.Size(350, 230);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "HouseEditForm";
            this.Text = "Edit House";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}