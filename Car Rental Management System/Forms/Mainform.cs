using System;
using System.Windows.Forms;
using Car_Rental_Management_System.Forms;

namespace Car_Rental_Management_System
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }

        private void btnCars_Click(object sender, EventArgs e)
        {
            using (var f = new CarManagementForm())
            {
                f.ShowDialog();
            }
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            using (var f = new CustomerManagementForm())
            {
                f.ShowDialog();
            }
        }

        private void btnRentals_Click(object sender, EventArgs e)
        {
            using (var f = new RentalManagementForm())
            {
                f.ShowDialog();
            }
        }

        private void Mainform_Load(object sender, EventArgs e)
        {

        }
    }
}
