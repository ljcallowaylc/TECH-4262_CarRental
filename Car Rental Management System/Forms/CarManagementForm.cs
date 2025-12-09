using System;
using System.Windows.Forms;
using Car_Rental_Management_System.Model;
using System.ComponentModel;
using System.Collections.Generic;

namespace Car_Rental_Management_System.Forms
{
    public partial class CarManagementForm : Form
    {
        // Very simple in-memory list just for the interface demo
        private BindingList<Car> _cars = new BindingList<Car>();
        private Car _selectedCar;

        public CarManagementForm()
        {
            InitializeComponent();
        }

        private void CarManagementForm_Load(object sender, EventArgs e)
        {
            dgvCars.AutoGenerateColumns = true;
            dgvCars.DataSource = _cars;

            // Just a couple of sample rows so the grid isn't empty
            _cars.Add(new Car { CarID = 1, Make = "Toyota", Model = "Corolla", Year = 2020, DailyRate = 40m });
            _cars.Add(new Car { CarID = 2, Make = "Honda", Model = "Civic", Year = 2019, DailyRate = 38m });

            dgvCars.SelectionChanged += DgvCars_SelectionChanged;
        }

        private void DgvCars_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCars.CurrentRow?.DataBoundItem is Car car)
            {
                _selectedCar = car;
                txtMake.Text = car.Make;
                txtModel.Text = car.Model;
                numYear.Value = car.Year;
                numDailyRate.Value = car.DailyRate;
                chkActive.Checked = car.IsActive;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMake.Text) ||
                string.IsNullOrWhiteSpace(txtModel.Text))
            {
                MessageBox.Show("Make and Model are required.");
                return;
            }

            int nextId = _cars.Count == 0 ? 1 : _cars[_cars.Count - 1].CarID + 1;

            var car = new Car
            {
                CarID = nextId,
                Make = txtMake.Text.Trim(),
                Model = txtModel.Text.Trim(),
                Year = (int)numYear.Value,
                DailyRate = numDailyRate.Value,
                IsAvailable = true,
                IsActive = chkActive.Checked
            };

            _cars.Add(car);
            ClearInputs();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedCar == null)
            {
                MessageBox.Show("Select a car to update.");
                return;
            }

            _selectedCar.Make = txtMake.Text.Trim();
            _selectedCar.Model = txtModel.Text.Trim();
            _selectedCar.Year = (int)numYear.Value;
            _selectedCar.DailyRate = numDailyRate.Value;
            _selectedCar.IsActive = chkActive.Checked;

            dgvCars.Refresh();
            ClearInputs();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtMake.Clear();
            txtModel.Clear();
            numYear.Value = DateTime.Now.Year;
            numDailyRate.Value = 0;
            chkActive.Checked = true;
            _selectedCar = null;
            dgvCars.ClearSelection();
        }
    }
}
