namespace Car_Rental_Management_System.Forms
{
    partial class RentalManagementForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblCar;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.ComboBox cmbCar;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblEstimatedCost;
        private System.Windows.Forms.Button btnCreateRental;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.DataGridView dgvRentals;

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
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblCar = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.cmbCar = new System.Windows.Forms.ComboBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblEstimatedCost = new System.Windows.Forms.Label();
            this.btnCreateRental = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.dgvRentals = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentals)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(12, 15);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(68, 16);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Customer:";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(90, 12);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(200, 24);
            this.cmbCustomer.TabIndex = 1;
            // 
            // lblCar
            // 
            this.lblCar.AutoSize = true;
            this.lblCar.Location = new System.Drawing.Point(310, 15);
            this.lblCar.Name = "lblCar";
            this.lblCar.Size = new System.Drawing.Size(32, 16);
            this.lblCar.TabIndex = 2;
            this.lblCar.Text = "Car:";
            // 
            // cmbCar
            // 
            this.cmbCar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCar.FormattingEnabled = true;
            this.cmbCar.Location = new System.Drawing.Point(348, 12);
            this.cmbCar.Name = "cmbCar";
            this.cmbCar.Size = new System.Drawing.Size(200, 24);
            this.cmbCar.TabIndex = 3;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(12, 50);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(72, 16);
            this.lblStart.TabIndex = 4;
            this.lblStart.Text = "Start Date:";
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(90, 47);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 22);
            this.dtpStart.TabIndex = 5;
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(310, 50);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(67, 16);
            this.lblEnd.TabIndex = 6;
            this.lblEnd.Text = "End Date:";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(383, 47);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 22);
            this.dtpEnd.TabIndex = 7;
            // 
            // lblEstimatedCost
            // 
            this.lblEstimatedCost.AutoSize = true;
            this.lblEstimatedCost.Location = new System.Drawing.Point(12, 80);
            this.lblEstimatedCost.Name = "lblEstimatedCost";
            this.lblEstimatedCost.Size = new System.Drawing.Size(104, 16);
            this.lblEstimatedCost.TabIndex = 8;
            this.lblEstimatedCost.Text = "Estimated: $0.00";
            // 
            // btnCreateRental
            // 
            this.btnCreateRental.Location = new System.Drawing.Point(330, 75);
            this.btnCreateRental.Name = "btnCreateRental";
            this.btnCreateRental.Size = new System.Drawing.Size(120, 28);
            this.btnCreateRental.TabIndex = 9;
            this.btnCreateRental.Text = "Create Rental";
            this.btnCreateRental.UseVisualStyleBackColor = true;
            this.btnCreateRental.Click += new System.EventHandler(this.btnCreateRental_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(463, 75);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(120, 28);
            this.btnReturn.TabIndex = 10;
            this.btnReturn.Text = "Return Rental";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // dgvRentals
            // 
            this.dgvRentals.AllowUserToAddRows = false;
            this.dgvRentals.AllowUserToDeleteRows = false;
            this.dgvRentals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRentals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentals.Location = new System.Drawing.Point(15, 115);
            this.dgvRentals.MultiSelect = false;
            this.dgvRentals.Name = "dgvRentals";
            this.dgvRentals.ReadOnly = true;
            this.dgvRentals.RowHeadersWidth = 51;
            this.dgvRentals.RowTemplate.Height = 24;
            this.dgvRentals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRentals.Size = new System.Drawing.Size(568, 220);
            this.dgvRentals.TabIndex = 11;
            // 
            // RentalManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.Controls.Add(this.dgvRentals);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnCreateRental);
            this.Controls.Add(this.lblEstimatedCost);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.cmbCar);
            this.Controls.Add(this.lblCar);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.lblCustomer);
            this.Name = "RentalManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rental Management";
            this.Load += new System.EventHandler(this.RentalManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
