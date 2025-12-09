namespace Car_Rental_Management_System.Forms
{
    partial class CarManagementForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblMake;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblDailyRate;
        private System.Windows.Forms.TextBox txtMake;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.NumericUpDown numDailyRate;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvCars;

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
            this.lblMake = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblDailyRate = new System.Windows.Forms.Label();
            this.txtMake = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.numDailyRate = new System.Windows.Forms.NumericUpDown();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvCars = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDailyRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMake
            // 
            this.lblMake.AutoSize = true;
            this.lblMake.Location = new System.Drawing.Point(12, 15);
            this.lblMake.Name = "lblMake";
            this.lblMake.Size = new System.Drawing.Size(43, 16);
            this.lblMake.TabIndex = 0;
            this.lblMake.Text = "Make:";
            // 
            // txtMake
            // 
            this.txtMake.Location = new System.Drawing.Point(80, 12);
            this.txtMake.Name = "txtMake";
            this.txtMake.Size = new System.Drawing.Size(150, 22);
            this.txtMake.TabIndex = 1;
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(250, 15);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(48, 16);
            this.lblModel.TabIndex = 2;
            this.lblModel.Text = "Model:";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(304, 12);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(150, 22);
            this.txtModel.TabIndex = 3;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(12, 50);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(37, 16);
            this.lblYear.TabIndex = 4;
            this.lblYear.Text = "Year:";
            // 
            // numYear
            // 
            this.numYear.Location = new System.Drawing.Point(80, 48);
            this.numYear.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.numYear.Minimum = new decimal(new int[] {
            1980,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(150, 22);
            this.numYear.TabIndex = 5;
            this.numYear.Value = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            // 
            // lblDailyRate
            // 
            this.lblDailyRate.AutoSize = true;
            this.lblDailyRate.Location = new System.Drawing.Point(250, 50);
            this.lblDailyRate.Name = "lblDailyRate";
            this.lblDailyRate.Size = new System.Drawing.Size(70, 16);
            this.lblDailyRate.TabIndex = 6;
            this.lblDailyRate.Text = "Daily Rate:";
            // 
            // numDailyRate
            // 
            this.numDailyRate.DecimalPlaces = 2;
            this.numDailyRate.Location = new System.Drawing.Point(326, 48);
            this.numDailyRate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numDailyRate.Name = "numDailyRate";
            this.numDailyRate.Size = new System.Drawing.Size(128, 22);
            this.numDailyRate.TabIndex = 7;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(480, 14);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(64, 20);
            this.chkActive.TabIndex = 8;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(15, 85);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 30);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(120, 85);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(90, 30);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(225, 85);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 30);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dgvCars
            // 
            this.dgvCars.AllowUserToAddRows = false;
            this.dgvCars.AllowUserToDeleteRows = false;
            this.dgvCars.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCars.Location = new System.Drawing.Point(15, 130);
            this.dgvCars.MultiSelect = false;
            this.dgvCars.Name = "dgvCars";
            this.dgvCars.ReadOnly = true;
            this.dgvCars.RowHeadersWidth = 51;
            this.dgvCars.RowTemplate.Height = 24;
            this.dgvCars.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCars.Size = new System.Drawing.Size(560, 220);
            this.dgvCars.TabIndex = 12;
            // 
            // CarManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 370);
            this.Controls.Add(this.dgvCars);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.numDailyRate);
            this.Controls.Add(this.lblDailyRate);
            this.Controls.Add(this.numYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.txtMake);
            this.Controls.Add(this.lblMake);
            this.Name = "CarManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Car Management";
            this.Load += new System.EventHandler(this.CarManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDailyRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
