using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Car_Rental_Management_System.Model;

namespace Car_Rental_Management_System.Forms
{
    public partial class RentalManagementForm : Form
    {
        private BindingList<Rental> _rentals = new BindingList<Rental>();
        private BindingList<Car> _cars;
        private BindingList<Customer> _customers;
        private Rental _selectedRental;

        public RentalManagementForm()
        {
            InitializeComponent();
        }

        private void RentalManagementForm_Load(object sender, EventArgs e)
        {
            // Simple in-memory data shared only inside this form
            _cars = new BindingList<Car>
            {
                new Car { CarId = 1, Make = "Toyota", Model = "Corolla", Year = 2020, DailyRate = 40m, IsAvailable = "Rented" },
                new Car { CarId = 2, Make = "Honda", Model = "Civic", Year = 2019, DailyRate = 38m, IsAvailable = "Availabe" }
            };

            _customers = new BindingList<Customer>
            {
                new Customer { CustomerId = 1, FullName = "John Doe" },
                new Customer { CustomerId = 2, FullName = "Jane Smith" }
            };

            cmbCustomer.DataSource = _customers;
            cmbCustomer.DisplayMember = "CustomerName";
            cmbCustomer.ValueMember = "CustomerID";

            cmbCar.DataSource = _cars;
            cmbCar.DisplayMember = "Model";
            cmbCar.ValueMember = "CarID";

            dgvRentals.AutoGenerateColumns = true;
            dgvRentals.DataSource = _rentals;
            dgvRentals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRentals.SelectionChanged += DgvRentals_SelectionChanged;

            dtpStart.Value = DateTime.Today;
            dtpEnd.Value = DateTime.Today.AddDays(1);
        }

        private void DgvRentals_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRentals.CurrentRow?.DataBoundItem is Rental rental)
            {
                _selectedRental = rental;
            }
        }

        private void btnCreateRental_Click(object sender, EventArgs e)
        {
            if (!(cmbCustomer.SelectedItem is Customer customer &&
                cmbCar.SelectedItem is Car car))
            {
                MessageBox.Show("Select a customer and a car.");
                return;
            }

            DateTime start = dtpStart.Value.Date;
            DateTime end = dtpEnd.Value.Date;

            if (end < start)
            {
                MessageBox.Show("End date cannot be before start date.");
                return;
            }

            bool overlaps = _rentals.Any(r =>
                r.CarId == car.CarId &&
                r.Status == "Active" &&
                start <= r.EndDate && r.StartDate <= end);

            if (overlaps)
            {
                MessageBox.Show("This car is already rented for the selected dates.");
                return;
            }

            int days = (int)(end - start).TotalDays;
            if (days < 1) days = 1;
            decimal estimated = days * car.DailyRate;

            int nextId = _rentals.Count == 0 ? 1 : _rentals[_rentals.Count - 1].RentalId + 1;

            var rental = new Rental
            {
                RentalId = nextId,
                CustomerId = customer.CustomerId,
                CarId = car.CarId,
                StartDate = start,
                EndDate = end,
                EstimatedCost = estimated,
                Status = "Active"
            };

            _rentals.Add(rental);
            lblEstimatedCost.Text = $"Estimated: {estimated:C}";
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (_selectedRental == null)
            {
                MessageBox.Show("Select a rental to return.");
                return;
            }

            if (_selectedRental.Status == "Returned")
            {
                MessageBox.Show("This rental is already returned.");
                return;
            }

            DateTime returnDate = DateTime.Today;
            if (returnDate < _selectedRental.StartDate)
            {
                MessageBox.Show("Return date cannot be before start date.");
                return;
            }

            var car = _cars.FirstOrDefault(c => c.CarId == _selectedRental.CarId);
            decimal rate = car?.DailyRate ?? 0m;

            int days = (int)(returnDate - _selectedRental.StartDate).TotalDays;
            if (days < 1) days = 1;

            decimal finalCost = days * rate;

            _selectedRental.ActualReturnDate = returnDate;
            _selectedRental.FinalCost = finalCost;
            _selectedRental.Status = "Returned";

            dgvRentals.Refresh();
            MessageBox.Show($"Rental returned. Final cost: {finalCost:C}");
        }
    }
}
