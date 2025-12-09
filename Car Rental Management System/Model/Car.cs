using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Management_System.Model
{
    public class Car
    {
        public int CarId { get; set; }
        public string Make { get; set; } = "";
        public string Model { get; set; } = "";
        public int Year { get; set; }
        public decimal DailyRate { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string IsAvailable { get; set; } = "Available";

        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
        public string DisplayName => $"{Year} {Make} {Model}";
    }
}
