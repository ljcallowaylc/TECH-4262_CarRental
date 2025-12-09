using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Management_System.Data
{
    internal class CaeRentalContext
    {
        // Update with your server & database.
        private static string connectionString =
            "Server=SQLEXPRESS;Database=CarRentalDB;Trusted_Connection=True;";

        // Returns an open SQL connection
        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }
    }
}
