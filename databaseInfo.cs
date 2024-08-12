using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mechanic_database
{
    public class databaseInfo
    {
        public string connectionString {  get; private set; }

        public databaseInfo()
        {
            connectionString = @"Data Source=DESKTOP-H5V5OP2\SQLEXPRESS;Database=mechanic_db;Trusted_Connection=True;";

            // Connection String List

            // Mace Laptop: @"Server=localhost\SQLEXPRESS;Database=mechanic_db;Trusted_Connection=True;";
            // Mace Desktop: @"Data Source=DESKTOP-H5V5OP2\SQLEXPRESS;Database=mechanic_db;Trusted_Connection=True;";

        }
    }
}
