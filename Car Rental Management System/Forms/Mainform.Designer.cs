namespace Car_Rental_Management_System
{
    partial class Mainform
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCars;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnRentals;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCars = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnRentals = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(560, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Car Rental Management System";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCars
            // 
            this.btnCars.Location = new System.Drawing.Point(200, 80);
            this.btnCars.Name = "btnCars";
            this.btnCars.Size = new System.Drawing.Size(200, 40);
            this.btnCars.TabIndex = 1;
            this.btnCars.Text = "Manage Cars";
            this.btnCars.UseVisualStyleBackColor = true;
            this.btnCars.Click += new System.EventHandler(this.btnCars_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.Location = new System.Drawing.Point(200, 140);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(200, 40);
            this.btnCustomers.TabIndex = 2;
            this.btnCustomers.Text = "Manage Customers";
            this.btnCustomers.UseVisualStyleBackColor = true;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnRentals
            // 
            this.btnRentals.Location = new System.Drawing.Point(200, 200);
            this.btnRentals.Name = "btnRentals";
            this.btnRentals.Size = new System.Drawing.Size(200, 40);
            this.btnRentals.TabIndex = 3;
            this.btnRentals.Text = "Manage Rentals";
            this.btnRentals.UseVisualStyleBackColor = true;
            this.btnRentals.Click += new System.EventHandler(this.btnRentals_Click);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 281);
            this.Controls.Add(this.btnRentals);
            this.Controls.Add(this.btnCustomers);
            this.Controls.Add(this.btnCars);
            this.Controls.Add(this.lblTitle);
            this.Name = "Mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Car Rental Management";
            this.Load += new System.EventHandler(this.Mainform_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
