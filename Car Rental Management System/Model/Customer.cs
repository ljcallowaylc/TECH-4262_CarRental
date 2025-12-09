using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Management_System.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; } = "";
        public string Phone { get; set; }
        public string Email { get; set; }
        public string DriversLicense { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    }
}
