using Car_Rental_Management_System.Data;
using Car_Rental_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Management_System.Services
{
    internal class CustomerService
    {
        private readonly CarRentalContext _context;

        public CustomerService()
        {
            _context = new CarRentalContext();
        }

        // ✅ BUSINESS LOGIC: Validate customer data
        public (bool IsValid, string ErrorMessage) ValidateCustomer(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return (false, "Customer name is required.");

            if (name.Length < 2)
                return (false, "Customer name must be at least 2 characters.");

            return (true, string.Empty);
        }

        // ✅ BUSINESS LOGIC: Add customer
        public (bool Success, string Message) AddCustomer(string name, string phone, string email, string licenseNumber)
        {
            try
            {
                var validation = ValidateCustomer(name);
                if (!validation.IsValid)
                    return (false, validation.ErrorMessage);

                var customer = new Customer
                {
                    CustomerName = name,
                    Phone = phone,
                    Email = email,
                    DriverLicenseNumber = licenseNumber,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                };

                _context.Customers.Add(customer);
                _context.SaveChanges();

                return (true, "Customer added successfully.");
            }
            catch (Exception ex)
            {
                return (false, $"Error adding customer: {ex.Message}");
            }
        }

        // ✅ BUSINESS LOGIC: Update customer
        public (bool Success, string Message) UpdateCustomer(int customerId, string name, string phone, string email, string licenseNumber)
        {
            try
            {
                var validation = ValidateCustomer(name);
                if (!validation.IsValid)
                    return (false, validation.ErrorMessage);

                var customer = _context.Customers.Find(customerId);
                if (customer == null)
                    return (false, "Customer not found.");

                customer.CustomerName = name;
                customer.Phone = phone;
                customer.Email = email;
                customer.DriverLicenseNumber = licenseNumber;

                _context.SaveChanges();

                return (true, "Customer updated successfully.");
            }
            catch (Exception ex)
            {
                return (false, $"Error updating customer: {ex.Message}");
            }
        }

        // ✅ BUSINESS LOGIC: Deactivate customer
        public (bool Success, string Message) DeactivateCustomer(int customerId)
        {
            try
            {
                var customer = _context.Customers.Find(customerId);
                if (customer == null)
                    return (false, "Customer not found.");

                // Check for active rentals
                var hasActiveRentals = _context.Rentals
                    .Any(r => r.CustomerID == customerId && r.Status == "Active");

                if (hasActiveRentals)
                    return (false, "Cannot deactivate customer with active rentals.");

                customer.IsActive = false;
                _context.SaveChanges();

                return (true, "Customer deactivated successfully.");
            }
            catch (Exception ex)
            {
                return (false, $"Error deactivating customer: {ex.Message}");
            }
        }

        // ✅ BUSINESS LOGIC: Get all active customers
        public List<Customer> GetAllActiveCustomers()
        {
            return _context.Customers
                .Where(c => c.IsActive)
                .OrderBy(c => c.CustomerName)
                .ToList();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
