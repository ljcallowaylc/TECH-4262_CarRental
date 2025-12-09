using Car_Rental_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;


namespace Car_Rental_Management_System.Data
{
    public class CarRentalContext : DbContext
    {
        public CarRentalContext() : base("name=CarRentalContext") 
        {
            Database.SetInitializer<CarRentalContext>(new DropCreateDatabaseIfModelChanges<CarRentalContext>());
        }

        public DbSet<Car> Cars { get; set; } = null;
        public DbSet<Customer> Customers { get; set; } = null;
        public DbSet<Rental> Rentals { get; set; } = null;

    }
}