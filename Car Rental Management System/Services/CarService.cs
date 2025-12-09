using Car_Rental_Management_System.Data;
using Car_Rental_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Management_System.Services
{
    internal class CarService
    {
        private readonly CarRentalContext _context;

        public CarService()
        {
            _context = new CarRentalContext();
        }

        // ✅ BUSINESS LOGIC: Validate car data
        public (bool IsValid, string ErrorMessage) ValidateCar(string make, string model, int year, decimal dailyRate)
        {
            if (string.IsNullOrWhiteSpace(make))
                return (false, "Make is required.");

            if (string.IsNullOrWhiteSpace(model))
                return (false, "Model is required.");

            if (year < 1900 || year > DateTime.Now.Year + 1)
                return (false, "Invalid year.");

            if (dailyRate <= 0)
                return (false, "Daily rate must be greater than zero.");

            return (true, string.Empty);
        }

        // ✅ BUSINESS LOGIC: Add new car
        public (bool Success, string Message) AddCar(string make, string model, int year, decimal dailyRate)
        {
            try
            {
                var validation = ValidateCar(make, model, year, dailyRate);
                if (!validation.IsValid)
                    return (false, validation.ErrorMessage);

                var car = new Car
                {
                    Make = make,
                    Model = model,
                    Year = year,
                    DailyRate = dailyRate,
                    IsAvailable = true,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                };

                _context.Cars.Add(car);
                _context.SaveChanges();

                return (true, "Car added successfully.");
            }
            catch (Exception ex)
            {
                return (false, $"Error adding car: {ex.Message}");
            }
        }

        // ✅ BUSINESS LOGIC: Update car
        public (bool Success, string Message) UpdateCar(int carId, string make, string model, int year, decimal dailyRate)
        {
            try
            {
                var validation = ValidateCar(make, model, year, dailyRate);
                if (!validation.IsValid)
                    return (false, validation.ErrorMessage);

                var car = _context.Cars.Find(carId);
                if (car == null)
                    return (false, "Car not found.");

                car.Make = make;
                car.Model = model;
                car.Year = year;
                car.DailyRate = dailyRate;

                _context.SaveChanges();

                return (true, "Car updated successfully.");
            }
            catch (Exception ex)
            {
                return (false, $"Error updating car: {ex.Message}");
            }
        }

        // ✅ BUSINESS LOGIC: Deactivate car (soft delete)
        public (bool Success, string Message) DeactivateCar(int carId)
        {
            try
            {
                var car = _context.Cars.Find(carId);
                if (car == null)
                    return (false, "Car not found.");

                // Check if car has active rentals
                var hasActiveRentals = _context.Rentals
                    .Any(r => r.CarID == carId && r.Status == "Active");

                if (hasActiveRentals)
                    return (false, "Cannot deactivate car with active rentals.");

                car.IsActive = false;
                _context.SaveChanges();

                return (true, "Car deactivated successfully.");
            }
            catch (Exception ex)
            {
                return (false, $"Error deactivating car: {ex.Message}");
            }
        }

        // ✅ BUSINESS LOGIC: Get all active cars
        public List<Car> GetAllActiveCars()
        {
            return _context.Cars
                .Where(c => c.IsActive)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .ToList();
        }

        // ✅ BUSINESS LOGIC: Get available cars for rental
        public List<Car> GetAvailableCars()
        {
            return _context.Cars
                .Where(c => c.IsActive && c.IsAvailable)
                .OrderBy(c => c.Make)
                .ToList();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
