using Car_Rental_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Management_System.Data
{
    public class CarRentalContext
    {
        // Update to match your DB server + name
        private string connectionString = @"Server=.\SQLEXPRESS;Database=CarRentalDB;Trusted_Connection=True;";

        // ===================== CARS ===================== //

        public List<Car> GetAllCars()
        {
            List<Car> list = new List<Car>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT CarId, Make, Model, Year, DailyRate, IsActive FROM Cars";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Car
                        {
                            CarID = Convert.ToInt32(reader["CarId"]),
                            Make = reader["Make"].ToString(),
                            Model = reader["Model"].ToString(),
                            Year = Convert.ToInt32(reader["Year"]),
                            DailyRate = Convert.ToDecimal(reader["DailyRate"]),
                            IsActive = Convert.ToBoolean(reader["IsActive"])
                        });
                    }
                }
            }
            return list;
        }

        public void AddCar(Car car)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Cars (Make, Model, Year, DailyRate, IsActive)
                                 VALUES (@Make, @Model, @Year, @DailyRate, @IsActive)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Make", car.Make);
                    cmd.Parameters.AddWithValue("@Model", car.Model);
                    cmd.Parameters.AddWithValue("@Year", car.Year);
                    cmd.Parameters.AddWithValue("@DailyRate", car.DailyRate);
                    cmd.Parameters.AddWithValue("@IsActive", car.IsActive);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ===================== CUSTOMERS ===================== //

        public List<Customer> GetAllCustomers()
        {
            List<Customer> list = new List<Customer>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT CustomerId, FullName, Phone, Email, DriversLicense FROM Customers";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Customer
                        {
                            CustomerID = Convert.ToInt32(reader["CustomerID"]),
                            CustomerName = reader["FullName"].ToString(),
                            Phone = reader["Phone"]?.ToString(),
                            Email = reader["Email"]?.ToString(),
                            DriverLicenseNumber = reader["DriversLicense"]?.ToString()
                        });
                    }
                }
            }
            return list;
        }

        public void AddCustomer(Customer cust)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Customers (FullName, Phone, Email, DriversLicense)
                                 VALUES (@FullName, @Phone, @Email, @License)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FullName", cust.CustomerName);
                    cmd.Parameters.AddWithValue("@Phone", (object)cust.Phone ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", (object)cust.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@License", (object)cust.DriverLicenseNumber ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ===================== RENTALS ===================== //

        public List<Rental> GetAllRentals()
        {
            List<Rental> list = new List<Rental>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT RentalId, CustomerId, CarId, StartDate, EndDate, EstimatedCost, ActualReturnDate, FinalCost 
                                 FROM Rentals";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Rental
                        {
                            RentalID = Convert.ToInt32(reader["RentalId"]),
                            CustomerID = Convert.ToInt32(reader["CustomerId"]),
                            CarID = Convert.ToInt32(reader["CarId"]),
                            StartDate = Convert.ToDateTime(reader["StartDate"]),
                            EndDate = Convert.ToDateTime(reader["EndDate"]),
                            EstimatedCost = Convert.ToDecimal(reader["EstimatedCost"]),
                            ActualReturnDate = reader["ActualReturnDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["ActualReturnDate"]),
                            FinalCost = reader["FinalCost"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["FinalCost"])
                        });
                    }
                }
            }
            return list;
        }

        public void AddRental(Rental rent)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Rentals (CustomerId, CarId, StartDate, EndDate, EstimatedCost)
                                 VALUES (@CustomerId, @CarId, @StartDate, @EndDate, @Cost)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", rent.CustomerID);
                    cmd.Parameters.AddWithValue("@CarId", rent.CarID);
                    cmd.Parameters.AddWithValue("@StartDate", rent.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", rent.EndDate);
                    cmd.Parameters.AddWithValue("@Cost", rent.EstimatedCost);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}