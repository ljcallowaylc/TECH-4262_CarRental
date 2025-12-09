using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Management_System.Model
{
    public class Rental
    {
        public int RentalId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }

        public decimal EstimatedCost { get; set; }
        public decimal? FinalCost { get; set; }
        public bool IsReturned { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Active";
    }
}
