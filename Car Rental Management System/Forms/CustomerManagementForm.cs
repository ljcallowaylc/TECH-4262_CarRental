using System;
using System.Windows.Forms;
using Car_Rental_Management_System.Model;
using System.ComponentModel;

namespace Car_Rental_Management_System.Forms
{
    public partial class CustomerManagementForm : Form
    {
        private BindingList<Customer> _customers = new BindingList<Customer>();
        private Customer _selectedCustomer;

        public CustomerManagementForm()
        {
            InitializeComponent();
        }

        private void CustomerManagementForm_Load(object sender, EventArgs e)
        {
            dgvCustomers.AutoGenerateColumns = true;
            dgvCustomers.DataSource = _customers;

            _customers.Add(new Customer { CustomerId = 1, FullName = "John Doe", Phone = "555-1234", Email = "john@example.com" });
            _customers.Add(new Customer { CustomerId = 2, FullName = "Jane Smith", Phone = "555-5678", Email = "jane@example.com" });

            dgvCustomers.SelectionChanged += DgvCustomers_SelectionChanged;
        }

        private void DgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow?.DataBoundItem is Customer cust)
            {
                _selectedCustomer = cust;
                txtName.Text = cust.FullName;
                txtPhone.Text = cust.Phone;
                txtEmail.Text = cust.Email;
                txtLicense.Text = cust.DriversLicense;
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Customer name is required.");
                return;
            }

            int nextId = _customers.Count == 0 ? 1 : _customers[_customers.Count - 1].CustomerId + 1;

            var cust = new Customer
            {
                CustomerId = nextId,
                FullName = txtName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                DriversLicense = txtLicense.Text.Trim(),
                IsActive = true
            };

            _customers.Add(cust);
            ClearInputs();
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (_selectedCustomer == null)
            {
                MessageBox.Show("Select a customer to update.");
                return;
            }

            _selectedCustomer.FullName = txtName.Text.Trim();
            _selectedCustomer.Phone = txtPhone.Text.Trim();
            _selectedCustomer.Email = txtEmail.Text.Trim();
            _selectedCustomer.DriversLicense = txtLicense.Text.Trim();

            dgvCustomers.Refresh();
            ClearInputs();
        }

        private void btnClearCustomer_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtLicense.Clear();
            _selectedCustomer = null;
            dgvCustomers.ClearSelection();
        }
    }
}
