using Car_Rental_Management_System.Data;
using Car_Rental_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Management_System.Services
{
    public class RentalService
    {
        private readonly CarRentalContext _db;
        public RentalService(CarRentalContext db) { _db = db; }

        public static int RentalDaysInclusive(DateTime start, DateTime end)
        {
            var days = (int)(end.Date - start.Date).TotalDays + 1;
            return days < 1 ? 1 : days;
        }

        public static decimal ComputeEstimatedCost(decimal dailyRate, DateTime start, DateTime end)
            => dailyRate * RentalDaysInclusive(start, end);

        public async Task<bool> IsCarAvailableAsync(int carId, DateTime start, DateTime end, int? excludingRentalId = null)
        {
            return !await _db.Rentals
                .Where(r => r.CarId == carId && !r.IsReturned && (excludingRentalId == null || r.RentalId != excludingRentalId))
                .AnyAsync(r => r.StartDate <= end.Date && r.EndDate >= start.Date);
        }

        public async Task<(bool Success, string Error)> CreateRentalAsync(int customerId, int carId, DateTime start, DateTime end)
        {
            if (end.Date < start.Date) return (false, "End date cannot be before start date.");
            var car = await _db.Cars.FindAsync(carId);
            if (car == null || !car.IsActive) return (false, "Selected car not available.");

            var available = await IsCarAvailableAsync(carId, start, end);
            if (!available) return (false, "Car is already rented for the selected dates.");

            var estimated = ComputeEstimatedCost(car.DailyRate, start, end);

            var rental = new Rental
            {
                CustomerId = customerId,
                CarId = carId,
                StartDate = start.Date,
                EndDate = end.Date,
                EstimatedCost = estimated,
                IsReturned = false
            };

            _db.Rentals.Add(rental);
            await _db.SaveChangesAsync();
            return (true, null);
        }

        public async Task<(bool Success, string Error)> ReturnRentalAsync(int rentalId, DateTime actualReturnDate, decimal? finalCost = null)
        {
            var rental = await _db.Rentals.Include(r => r.Car).FirstOrDefaultAsync(r => r.RentalId == rentalId);
            if (rental == null) return (false, "Rental not found.");
            if (rental.IsReturned) return (false, "Rental is already returned.");
            if (actualReturnDate.Date < rental.StartDate.Date) return (false, "Actual return date cannot be before start date.");

            rental.ActualReturnDate = actualReturnDate.Date;
            rental.IsReturned = true;

            if (finalCost.HasValue)
            {
                rental.FinalCost = finalCost.Value;
            }
            else if (rental.Car != null)
            {
                var days = RentalDaysInclusive(rental.StartDate, actualReturnDate);
                rental.FinalCost = rental.Car.DailyRate * days;
            }

            await _db.SaveChangesAsync();
            return (true, null);
        }
    }
}
