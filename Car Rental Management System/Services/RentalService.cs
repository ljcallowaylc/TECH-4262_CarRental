using Car_Rental_Management_System.Data;
using Car_Rental_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Management_System.Services
{
    internal class RentalService
    {
        private readonly CarRentalContext _context;

        public RentalService()
        {
            _context = new CarRentalContext();
        }

        // ✅ BUSINESS LOGIC: Calculate rental cost
        public decimal CalculateRentalCost(DateTime startDate, DateTime endDate, decimal dailyRate)
        {
            int days = (endDate - startDate).Days;
            if (days < 1) days = 1; // Business rule: minimum 1 day
            return days * dailyRate;
        }

        // ✅ BUSINESS LOGIC: Check if car is available for date range
        public bool IsCarAvailable(int carId, DateTime startDate, DateTime endDate, int? excludeRentalId = null)
        {
            var overlappingRentals = _context.Rentals
                .Where(r => r.CarID == carId
                    && r.Status == "Active"
                    && r.StartDate < endDate
                    && r.EndDate > startDate);

            // Exclude current rental when editing
            if (excludeRentalId.HasValue)
            {
                overlappingRentals = overlappingRentals.Where(r => r.RentalID != excludeRentalId.Value);
            }

            return !overlappingRentals.Any();
        }

        // ✅ BUSINESS LOGIC: Validate rental dates
        public (bool IsValid, string ErrorMessage) ValidateRentalDates(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
                return (false, "End date cannot be before start date.");

            if (startDate < DateTime.Today)
                return (false, "Start date cannot be in the past.");

            return (true, string.Empty);
        }

        // ✅ BUSINESS LOGIC: Create new rental
        public (bool Success, string Message) CreateRental(int customerId, int carId, DateTime startDate, DateTime endDate)
        {
            try
            {
                // Validate dates
                var dateValidation = ValidateRentalDates(startDate, endDate);
                if (!dateValidation.IsValid)
                    return (false, dateValidation.ErrorMessage);

                // Check car availability
                if (!IsCarAvailable(carId, startDate, endDate))
                    return (false, "Car is not available for the selected dates.");

                // Get car details
                var car = _context.Cars.Find(carId);
                if (car == null || !car.IsActive)
                    return (false, "Invalid or inactive car selected.");

                // Calculate cost
                decimal estimatedCost = CalculateRentalCost(startDate, endDate, car.DailyRate);

                // Create rental
                var rental = new Rental
                {
                    CustomerID = customerId,
                    CarID = carId,
                    StartDate = startDate,
                    EndDate = endDate,
                    EstimatedCost = estimatedCost,
                    Status = "Active",
                    CreatedDate = DateTime.Now
                };

                // Update car availability
                car.IsAvailable = false;

                _context.Rentals.Add(rental);
                _context.SaveChanges();

                return (true, "Rental created successfully.");
            }
            catch (Exception ex)
            {
                return (false, $"Error creating rental: {ex.Message}");
            }
        }

        // ✅ BUSINESS LOGIC: Return car
        public (bool Success, string Message) ReturnCar(int rentalId, DateTime returnDate, decimal? adjustedCost = null)
        {
            try
            {
                var rental = _context.Rentals
                    .Include(r => r.Car)
                    .FirstOrDefault(r => r.RentalID == rentalId);

                if (rental == null)
                    return (false, "Rental not found.");

                if (rental.Status == "Returned")
                    return (false, "This rental has already been returned.");

                if (returnDate < rental.StartDate)
                    return (false, "Return date cannot be before start date.");

                // Update rental
                rental.ActualReturnDate = returnDate;
                rental.Status = "Returned";

                // Calculate final cost or use adjusted cost
                if (adjustedCost.HasValue)
                {
                    rental.FinalCost = adjustedCost.Value;
                }
                else
                {
                    rental.FinalCost = CalculateRentalCost(rental.StartDate, returnDate, rental.Car.DailyRate);
                }

                // Mark car as available
                rental.Car.IsAvailable = true;

                _context.SaveChanges();

                return (true, "Car returned successfully.");
            }
            catch (Exception ex)
            {
                return (false, $"Error returning car: {ex.Message}");
            }
        }

        // ✅ BUSINESS LOGIC: Get all rentals
        public List<Rental> GetAllRentals()
        {
            return _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Car)
                .OrderByDescending(r => r.CreatedDate)
                .ToList();
        }

        // ✅ BUSINESS LOGIC: Get active rentals only
        public List<Rental> GetActiveRentals()
        {
            return _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Car)
                .Where(r => r.Status == "Active")
                .OrderBy(r => r.EndDate)
                .ToList();
        }

        // ✅ BUSINESS LOGIC: Get rentals by customer
        public List<Rental> GetRentalsByCustomer(int customerId)
        {
            return _context.Rentals
                .Include(r => r.Car)
                .Where(r => r.CustomerID == customerId)
                .OrderByDescending(r => r.CreatedDate)
                .ToList();
        }

        // ✅ BUSINESS LOGIC: Get rental details
        public Rental GetRentalById(int rentalId)
        {
            return _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Car)
                .FirstOrDefault(r => r.RentalID == rentalId);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
