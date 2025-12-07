using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Management_System.Model
{
    internal class Rental
    {
        public int RentalID { get; set; }
        public int CustomerID { get; set; }
        public int CarID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public decimal EstimatedCost { get; set; }
        public decimal? FinalCost { get; set; }
        public string Status { get; set; } = "Active";
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual Customer Customer { get; set; }
        public virtual Car Car { get; set; }
    }
}
