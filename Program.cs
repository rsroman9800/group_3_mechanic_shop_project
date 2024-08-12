using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace mechanic_database
{
    internal class Program
    {
        static List<Customer> customerList = new List<Customer>();
        static List<Vehicle> vehicleList = new List<Vehicle>();
        static List<Appointment> appointmentList = new List<Appointment>();
        static List<Invoice> invoiceList = new List<Invoice>();

        static void Main(string[] args)
        {
            Console.WriteLine("Calling Startup...\n");
            startup();

            mainMenu();

            Console.ReadLine();
        }




        /** ---------- Startup Function ---------- **/
        static void startup()
        {
            if (IsServerConnected())
            {
                Console.WriteLine("Database Connection Successful!\n");
            }
            else
            {
                Console.WriteLine("Database Connection Failed.");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Have you changed the connection string in databaseInfo.cs?");
                Console.WriteLine("Have you created 'mechanic_db' database in SQL Server Mangement Studio?");
                Console.ReadLine();
                Environment.Exit(0);
            }

            Console.WriteLine("Would you like to load or create the database?");
            Console.WriteLine("1 - Load Database");
            Console.WriteLine("2 - Create Database");
            string selection = Console.ReadLine();

            if (selection == "1")
            {
                loadDatabase();
            }
            else if (selection == "2")
            {
                databaseCreate();
                databasePopulate();
                loadDatabase();
            }
            else
            {
                Console.WriteLine("Invalid Selection.");
                Console.ReadLine(); // Wait for input
                Environment.Exit(0);
            }
        }


        /** Test Server Connection **/
        private static bool IsServerConnected()
        {
            var dbInfo = new databaseInfo();

            using (SqlConnection connection = new SqlConnection(dbInfo.connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }












        /** ---------- Menu Functions ---------- **/





        /** ---------- Main Menu ---------- **/
        static void mainMenu()
        {
            Console.WriteLine("Please select one of the following options:");
            Console.WriteLine("1 - Customer Menu");
            Console.WriteLine("2 - Vehicle Menu");
            Console.WriteLine("3 - Appointment/Invoice Menu");
            Console.WriteLine("4 - Debug Menu");
            //Console.WriteLine("11 - Load Data");
            //Console.WriteLine("22 - Save Data");
            Console.WriteLine("0 - Save & Quit");

            string selection = Console.ReadLine();

            if (Int32.TryParse(selection, out int value))
            {
                int selectionInt = Convert.ToInt32(selection);

                switch(selectionInt)
                {
                    case 1:
                        customerMenu();
                        break;

                    case 2:
                        vehicleMenu();
                        break;

                    case 3:
                        invoiceMenu();
                        break;

                    case 4: // Debug Menu
                        debugMenu();
                        break;

                    case 11: // Load data
                        // Debug function - defunct
                        break;

                    case 22: // Save data
                        // Debug function - defunct - moved to "Save & Quit"
                        saveDatabase();
                        break;

                    case 0: // Save & Quit App
                        saveDatabase();
                        break;

                    default:
                        Console.WriteLine("Invalid Selection.");
                        Console.ReadLine(); // Wait for input
                        mainMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid Selection.");
                Console.ReadLine(); // Wait for input
                mainMenu();
            }
        }




        /** ---------- Customer Menu ---------- **/
        static void customerMenu()
        {
            Console.WriteLine("Please select one of the following options:");
            Console.WriteLine("1 - Add Customer");
            Console.WriteLine("2 - Edit Customer");
            Console.WriteLine("3 - Delete Customer");
            Console.WriteLine("0 - Back");

            string selection = Console.ReadLine();

            if (Int32.TryParse(selection, out int value))
            {
                int selectionInt = Convert.ToInt32(selection);

                switch (selectionInt)
                {
                    case 1: // Add Customer
                        addCustomer();
                        break;

                    case 2: // Edit Customer
                        editCustomer();
                        break;

                    case 3: // Delete Customer
                        deleteCustomer();
                        break;

                    case 0: // Return
                        mainMenu();
                        break;

                    default:
                        Console.WriteLine("Invalid Selection.");
                        Console.ReadLine(); // Wait for input
                        customerMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid Selection.");
                Console.ReadLine(); // Wait for input
                customerMenu();
            }
        }




        /** ---------- Vehicle Menu ---------- **/
        static void vehicleMenu()
        {
            Console.WriteLine("Please select one of the following options:");
            Console.WriteLine("1 - Add Vehicle");
            Console.WriteLine("2 - Edit Vehicle");
            Console.WriteLine("3 - Delete Vehicle");
            Console.WriteLine("0 - Back");

            string selection = Console.ReadLine();

            if (Int32.TryParse(selection, out int value))
            {
                int selectionInt = Convert.ToInt32(selection);

                switch (selectionInt)
                {
                    case 1: // Add Vehicle
                        addVehicle();
                        break;

                    case 2: // Edit Vehicle
                        editVehicle();
                        break;

                    case 3: // Delete Vehicle
                        deleteVehicle();
                        break;

                    case 0: // Return
                        mainMenu();
                        break;

                    default:
                        Console.WriteLine("Invalid Selection.");
                        Console.ReadLine(); // Wait for input
                        customerMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid Selection.");
                Console.ReadLine(); // Wait for input
                customerMenu();
            }
        }




        /** ---------- Appointment/Invoice Menu ---------- **/
        static void invoiceMenu()
        {
            Console.WriteLine("Please select one of the following options:");
            Console.WriteLine("1 - Create Appointment");
            Console.WriteLine("2 - Edit Appointment");
            Console.WriteLine("3 - Cancel Appointment");
            Console.WriteLine("4 - Generate Invoice");
            Console.WriteLine("5 - Pay Invoice");
            Console.WriteLine("0 - Back");

            string selection = Console.ReadLine();

            if (Int32.TryParse(selection, out int value))
            {
                int selectionInt = Convert.ToInt32(selection);

                switch (selectionInt)
                {
                    case 1: // Create Appointment
                        createAppointment();
                        break;

                    case 2: // Edit Appointment
                        editAppointment();
                        break;

                    case 3: // Cancel Appointment
                        cancelAppointment();
                        break;

                    case 4: // Generate Invoice
                        generateInvoice();
                        break;

                    case 5: // Pay Invoice
                        payInvoice();
                        break;

                    case 0: // Return
                        mainMenu();
                        break;

                    default:
                        Console.WriteLine("Invalid Selection.");
                        Console.ReadLine(); // Wait for input
                        customerMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid Selection.");
                Console.ReadLine(); // Wait for input
                customerMenu();
            }
        }



        /** ---------- Debug Menu ---------- **/
        static void debugMenu()
        {
            Console.WriteLine("Please select one of the following options:");
            Console.WriteLine("1 - Test Database (List all customers)");
            Console.WriteLine("2 - Create Database");
            Console.WriteLine("3 - Populate Database");
            Console.WriteLine("0 - Back");

            string selection = Console.ReadLine();

            if (Int32.TryParse(selection, out int value))
            {
                int selectionInt = Convert.ToInt32(selection);

                switch (selectionInt)
                {
                    case 1: // Database test
                        databaseTest();
                        break;

                    case 2:
                        databaseCreate();
                        break;

                    case 3:
                        databasePopulate();
                        break;

                    case 0: // Return
                        mainMenu();
                        break;

                    default:
                        Console.WriteLine("Invalid Selection.");
                        Console.ReadLine(); // Wait for input
                        debugMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid Selection.");
                Console.ReadLine(); // Wait for input
                debugMenu();
            }
        }







        /** ---------- Database Create ---------- **/
        static void databaseCreate()
        {
            string connectionString;
            SqlConnection cnn;
            var dbInfo = new databaseInfo();
            connectionString = dbInfo.connectionString;
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            //string script = File.ReadAllText(@"G:\mechanic_database_backend\create-mechanic-database.sql");
            string script = File.ReadAllText(@"G:\mechanic_database_backend\create2.sql");

            var cmd = new SqlCommand(script, cnn);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Database successfully Created!");
            Console.ReadLine(); // Wait for input

            cmd.Dispose();
            cnn.Close();

            return;
        }




        /** ---------- Database Populate ---------- **/
        static void databasePopulate()
        {
            string connectionString;
            SqlConnection cnn;
            var dbInfo = new databaseInfo();
            connectionString = dbInfo.connectionString;
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            //string script = File.ReadAllText(@"G:\mechanic_database_backend\populate-mechanic-database.sql");
            string script = File.ReadAllText(@"G:\mechanic_database_backend\populate2.sql");

            var cmd = new SqlCommand(script, cnn);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Database successfully populated!");
            Console.ReadLine(); // Wait for input

            cmd.Dispose();
            cnn.Close();

            return;
        }




        /** ---------- Database Test ---------- **/
        static void databaseTest()
        {
            string connectionString;
            SqlConnection cnn;
            var dbInfo = new databaseInfo();
            connectionString = dbInfo.connectionString;
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";

            sql = "SELECT customer_id,customer_name FROM customer_table";

            command = new SqlCommand(sql, cnn);

            dataReader = command.ExecuteReader();

            Console.WriteLine("Connection Success!");

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + "\n";
            }

            Console.WriteLine(Output);

            Console.ReadLine(); // Wait for input


            dataReader.Close();
            command.Dispose();
            cnn.Close();

            debugMenu();
        }




        /** ---------- Load Database ---------- **/
        static void loadDatabase()
        {

            

            string connectionString;
            SqlConnection cnn;
            var dbInfo = new databaseInfo();
            connectionString = dbInfo.connectionString;
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlDataReader dataReader;


            /** Load Customers **/

            SqlCommand command;
            String sql = "";

            sql = "SELECT customer_id,customer_name,customer_phone,customer_email FROM customer_table";

            command = new SqlCommand(sql, cnn);

            dataReader = command.ExecuteReader();

            
            while (dataReader.Read())
            {
                var id = dataReader.GetInt32(0);
                var name = dataReader.GetString(1);
                var phone = dataReader.GetInt64(2);
                var email = dataReader.GetString(3);

                customerList.Add(new Customer(id, name, phone, email));
            }

            foreach( var customer in customerList)
            {
                Console.WriteLine(customer.ToString());
            }

            command.Dispose();
            dataReader.Close();

            /** Load Vehicles **/

            sql = "SELECT vehicle_id,customer_id,make,model,year,vin FROM vehicle_table";

            command = new SqlCommand(sql, cnn);

            dataReader = command.ExecuteReader();


            while (dataReader.Read())
            {
                var vid = dataReader.GetInt32(0);
                var cid = dataReader.GetInt32(1);
                var make = dataReader.GetString(2);
                var model = dataReader.GetString(3);
                var year = dataReader.GetString(4);
                var vin = dataReader.GetString(5);

                vehicleList.Add(new Vehicle(vid,cid,make,model,year,vin));
            }

            foreach (var vehicle in vehicleList)
            {
                Console.WriteLine(vehicle.ToString());
            }

            command.Dispose();
            dataReader.Close();

            /** Load Appointments **/

            sql = "SELECT appointment_id,customer_id,vehicle_id,description,labor_cost,part_cost,date FROM appointment_table";

            command = new SqlCommand(sql, cnn);

            dataReader = command.ExecuteReader();


            while (dataReader.Read())
            {
                var aid = dataReader.GetInt32(0);
                var cid = dataReader.GetInt32(1);
                var vid = dataReader.GetInt32(2);
                var description = dataReader.GetString(3);
                var laborCost = float.Parse(dataReader.GetDouble(4).ToString());
                var partCost = float.Parse(dataReader.GetDouble(5).ToString());
                var date = dataReader.GetDateTime(6);

                appointmentList.Add(new Appointment(aid,vid,cid,description,laborCost,partCost,date));
            }

            foreach (var appointment in appointmentList)
            {
                Console.WriteLine(appointment.ToString());
            }

            command.Dispose();
            dataReader.Close();

            /** Load Invoices **/

            sql = "SELECT invoice_id,customer_id,appointment_id,total_cost,date_issued,date_paid FROM invoice_table";

            command = new SqlCommand(sql, cnn);

            dataReader = command.ExecuteReader();


            while (dataReader.Read())
            {
                var iid = dataReader.GetInt32(0);
                var cid = dataReader.GetInt32(1);
                var aid = dataReader.GetInt32(2);
                var totalCost = float.Parse(dataReader.GetDouble(3).ToString());
                var dateIssued = dataReader.GetDateTime(4);
                var datePaid = dataReader.GetDateTime(5);



                invoiceList.Add(new Invoice(iid, cid, aid, totalCost, dateIssued, datePaid));
            }

            foreach (var invoice in invoiceList)
            {
                Console.WriteLine(invoice.ToString());
            }

            command.Dispose();
            dataReader.Close();


            Console.ReadLine(); // Wait for input


            dataReader.Close();
            cnn.Close();

        }

        /** ---------- Save Database ---------- **/
        static void saveDatabase()
        {

            string connectionString;
            SqlConnection cnn;
            var dbInfo = new databaseInfo();
            connectionString = dbInfo.connectionString;
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            string script = "DELETE FROM invoice_table;\nDELETE FROM appointment_table;\nDELETE FROM vehicle_table;\nDELETE FROM customer_table;\n";

            foreach (var customer in customerList)
            {
                script = (script + $"INSERT INTO customer_table VALUES ({customer.CID},'{customer.Name}', {customer.Phone}, '{customer.Email}');\n");
            }

            foreach (var vehicle in vehicleList)
            {
                script = (script + $"INSERT INTO vehicle_table VALUES ({vehicle.VID}, {vehicle.CID}, '{vehicle.Make}', '{vehicle.Model}', '{vehicle.Year}', '{vehicle.Vin}');\n");
            }

            foreach (var appointment in appointmentList)
            {
                script = (script + $"INSERT INTO appointment_table VALUES ({appointment.AID}, {appointment.CID}, {appointment.VID}, '{appointment.Description}', {appointment.LaborCost}, {appointment.PartsCost}, '{appointment.Date.ToShortDateString()}');\n");
            }

            foreach (var invoice in invoiceList)
            {
                script = (script + $"INSERT INTO invoice_table VALUES ({invoice.IID}, {invoice.CID}, {invoice.AID}, {invoice.TotalCost}, '{invoice.DateIssued.ToShortDateString()}', '{invoice.DatePaid.ToShortDateString()}');\n");
            }

            Console.WriteLine(script);

            var cmd = new SqlCommand(script, cnn);
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            cnn.Close();

            Console.WriteLine("Database successfully saved!");
            Console.WriteLine("You can now press enter to quit");
            Console.ReadLine(); // Wait for input

            


            Environment.Exit(0);
        }








        /** ---------- Customer Functions ---------- **/


        static void addCustomer()
        {
            int tempIDint = 0;
            Console.WriteLine("Enter new customer ID:");
            string tempID = Console.ReadLine();
            if (Int32.TryParse(tempID, out int value)) // Verify ID input
            {
                tempIDint = Int32.Parse(tempID);
            }
            else
            {
                Console.WriteLine("Invalid Selection.");
                Console.ReadLine();
                customerMenu();
            }

            Console.WriteLine("Enter new customer Name:");
            string tempName = Console.ReadLine();

            long tempPhonelong = 0;
            Console.WriteLine("Enter new customer phone number (no spaces or dashes):");
            string tempPhone = Console.ReadLine();
            if (Int64.TryParse(tempPhone, out long value2)) // Verify phone input
            {
                tempPhonelong = Int64.Parse(tempPhone);
            }
            else
            {
                Console.WriteLine("Invalid Selection.");
                Console.ReadLine();
                customerMenu();
            }

            Console.WriteLine("Enter new customer email:");
            string tempEmail = Console.ReadLine();


            customerList.Add(new Customer(tempIDint, tempName, tempPhonelong, tempEmail));

            Console.WriteLine($"{tempName} has been added as a customer.");
            Console.ReadLine();
            customerMenu();
        }

        static void editCustomer()
        {
            Console.WriteLine("Enter customer ID to edit:");
            int editID = Int32.Parse(Console.ReadLine());

            Customer editCustomer = customerList.Find(c => c.CID == editID);

            if (editCustomer != null)
            {
                Console.WriteLine("Editing customer: " + editCustomer.Name);
                Console.WriteLine("Leave blank to keep the current value.");

                Console.WriteLine("Enter new customer Name (current: " + editCustomer.Name + "):");
                string newName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newName))
                {
                    editCustomer.Name = newName;
                }

                Console.WriteLine("Enter new customer phone number (no spaces or dashes, current: " + editCustomer.Phone + "):");
                string newPhone = Console.ReadLine();
                if (!string.IsNullOrEmpty(newPhone))
                {
                    editCustomer.Phone = Int32.Parse(newPhone);
                }

                Console.WriteLine("Enter new customer email (current: " + editCustomer.Email + "):");
                string newEmail = Console.ReadLine();
                if (!string.IsNullOrEmpty(newEmail))
                {
                    editCustomer.Email = newEmail;
                }

                Console.WriteLine("Customer updated successfully.");
                Console.ReadLine();
                customerMenu();
            }
            else
            {
                Console.WriteLine("No customer is found with that ID.");
                Console.ReadLine();
                customerMenu();
            }
        }

        static void deleteCustomer()
        {
            Console.WriteLine("Enter customer ID to delete:");
            int delID = Int32.Parse(Console.ReadLine());

            Customer delCustomer = customerList.Find(c => c.CID == delID);

            if (delCustomer != null)
            {
                Console.WriteLine($"Are you sure you want to delete {delCustomer.Name}? [y/n]");
                string select = Console.ReadLine().ToLower();

                if (select == "y")
                {
                    customerList.Remove(delCustomer);
                    Console.WriteLine("Customer deleted successfully.");
                    Console.ReadLine();
                    customerMenu();
                }
                else
                {
                    Console.WriteLine("Customer not deleted.");
                    Console.ReadLine();
                    customerMenu();
                }
            }
            else
            {
                Console.WriteLine("No customer is found with that ID.");
                Console.ReadLine();
                customerMenu();
            }


        }







        /** ---------- Vehicle Functions ---------- **/



        static void addVehicle()
        {
            int tempVIDint = 0;
            Console.WriteLine("Enter new Vehicle ID:");
            string tempVID = Console.ReadLine();
            if (Int32.TryParse(tempVID, out int value)) // Verify VID input
            {
                tempVIDint = Int32.Parse(tempVID);
            }
            else
            {
                Console.WriteLine("Invalid Selection.");
                Console.ReadLine();
                vehicleMenu();
            }

            int tempCIDint = 0;
            Console.WriteLine("Enter new Owner Customer ID:");
            string tempCID = Console.ReadLine();
            if (Int32.TryParse(tempCID, out int value2)) // Verify CID input
            {
                tempCIDint = Int32.Parse(tempCID);
            }
            else
            {
                Console.WriteLine("Invalid Selection.");
                Console.ReadLine();
                vehicleMenu();
            }

            Console.WriteLine("Enter new vehicle Make:");
            string tempMake = Console.ReadLine();

            Console.WriteLine("Enter new vehicle Model:");
            string tempModel = Console.ReadLine();

            Console.WriteLine("Enter new vehicle Year:");
            string tempYear = Console.ReadLine();

            Console.WriteLine("Enter new vehicle VIN:");
            string tempVIN = Console.ReadLine();



            vehicleList.Add(new Vehicle(tempVIDint,tempCIDint,tempMake,tempModel,tempYear,tempVIN));

            Console.WriteLine($"Vehicle has been added.");
            Console.ReadLine();
            vehicleMenu();
        }

        static void editVehicle()
        {
            Console.WriteLine("Enter vehicle ID to edit:");
            int editID = Int32.Parse(Console.ReadLine());

            Vehicle vehicleToEdit = vehicleList.Find(v => v.VID == editID);

            if (vehicleToEdit != null)
            {
                Console.WriteLine("Editing vehicle with ID: " + editID);
                Console.WriteLine("Leave blank to keep the current value.");

                Console.WriteLine("Enter new vehicle Make (current: " + vehicleToEdit.Make + "):");
                string newMake = Console.ReadLine();
                if (!string.IsNullOrEmpty(newMake))
                {
                    vehicleToEdit.Make = newMake;
                }

                Console.WriteLine("Enter new vehicle Model (current: " + vehicleToEdit.Model + "):");
                string newModel = Console.ReadLine();
                if (!string.IsNullOrEmpty(newModel))
                {
                    vehicleToEdit.Model = newModel;
                }

                Console.WriteLine("Enter new vehicle Year (current: " + vehicleToEdit.Year + "):");
                string newYear = Console.ReadLine();
                if (!string.IsNullOrEmpty(newYear))
                {
                    vehicleToEdit.Year = newYear;
                }

                Console.WriteLine("Enter new vehicle VIN (current: " + vehicleToEdit.Vin + "):");
                string newVIN = Console.ReadLine();
                if (!string.IsNullOrEmpty(newVIN))
                {
                    vehicleToEdit.Vin = newVIN;
                }

                Console.WriteLine("Vehicle updated successfully.");
            }
            else
            {
                Console.WriteLine("Vehicle not found.");
            }
            Console.ReadLine();
            vehicleMenu();
        }

        static void deleteVehicle()
        {
            Console.WriteLine("Enter vehicle ID to delete:");
            int delID = Int32.Parse(Console.ReadLine());

            Vehicle vehicleToDelete = vehicleList.Find(v => v.VID == delID);

            if (vehicleToDelete != null)
            {
                Console.WriteLine($"Are you sure you want to delete vehicle with ID {vehicleToDelete.VID}? [y/n]");
                string select = Console.ReadLine().ToLower();

                if (select == "y")
                {
                    vehicleList.Remove(vehicleToDelete);
                    Console.WriteLine("Vehicle deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Vehicle not deleted.");
                }
            }
            else
            {
                Console.WriteLine("Vehicle not found.");
            }
            Console.ReadLine();
            vehicleMenu();
        }







        /** ---------- Appointments/Invoice Functions ---------- **/


        static void createAppointment()
        {
            Console.WriteLine("Enter new Appointment ID:");
            int aid = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter Vehicle ID:");
            int vid = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter Customer ID:");
            int cid = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter Description:");
            string description = Console.ReadLine();

            Console.WriteLine("Enter Labor Cost:");
            float laborCost = float.Parse(Console.ReadLine());

            Console.WriteLine("Enter Parts Cost:");
            float partsCost = float.Parse(Console.ReadLine());

            Console.WriteLine("Enter Date (yyyy-mm-dd):");
            DateTime date = DateTime.Parse(Console.ReadLine());

            appointmentList.Add(new Appointment(aid, vid, cid, description, laborCost, partsCost, date));
            Console.WriteLine("Appointment has been created.");
            Console.ReadLine();
            invoiceMenu();
        }

        static void editAppointment()
        {
            Console.WriteLine("Enter Appointment ID to edit:");
            int editAID = Int32.Parse(Console.ReadLine());

            Appointment appointmentToEdit = appointmentList.Find(a => a.AID == editAID);

            if (appointmentToEdit != null)
            {
                Console.WriteLine("Editing appointment with ID: " + editAID);
                Console.WriteLine("Leave blank to keep the current value.");

                Console.WriteLine("Enter new Description (current: " + appointmentToEdit.Description + "):");
                string newDescription = Console.ReadLine();
                if (!string.IsNullOrEmpty(newDescription))
                {
                    appointmentToEdit.Description = newDescription;
                }

                Console.WriteLine("Enter new Labor Cost (current: " + appointmentToEdit.LaborCost + "):");
                string newLaborCost = Console.ReadLine();
                if (!string.IsNullOrEmpty(newLaborCost))
                {
                    appointmentToEdit.LaborCost = float.Parse(newLaborCost);
                }

                Console.WriteLine("Enter new Parts Cost (current: " + appointmentToEdit.PartsCost + "):");
                string newPartsCost = Console.ReadLine();
                if (!string.IsNullOrEmpty(newPartsCost))
                {
                    appointmentToEdit.PartsCost = float.Parse(newPartsCost);
                }

                Console.WriteLine("Enter new Date (current: " + appointmentToEdit.Date.ToShortDateString() + "):");
                string newDate = Console.ReadLine();
                if (!string.IsNullOrEmpty(newDate))
                {
                    appointmentToEdit.Date = DateTime.Parse(newDate);
                }

                Console.WriteLine("Appointment updated successfully.");
                Console.ReadLine();
                invoiceMenu();
            }
            else
            {
                Console.WriteLine("Appointment not found.");
                Console.ReadLine();
                invoiceMenu();
            }
        }

        static void cancelAppointment()
        {
            Console.WriteLine("Enter Appointment ID to cancel:");
            int cancelAID = Int32.Parse(Console.ReadLine());

            Appointment appointmentToCancel = appointmentList.Find(a => a.AID == cancelAID);

            if (appointmentToCancel != null)
            {
                Console.WriteLine($"Are you sure you want to cancel appointment with ID {appointmentToCancel.AID}? [y/n]");
                string select = Console.ReadLine().ToLower();

                if (select == "y")
                {

                    appointmentList.Remove(appointmentToCancel);
                    Console.WriteLine("Appointment cancelled successfully.");
                    Console.ReadLine();
                    invoiceMenu();
                }
                else
                {
                    Console.WriteLine("Appointment not cancelled.");
                    Console.ReadLine();
                    invoiceMenu();
                }
            }
            else
            {
                Console.WriteLine("Appointment not found.");
                Console.ReadLine();
                invoiceMenu();
            }
        }

        static void generateInvoice()
        {
            Console.WriteLine("Enter Appointment ID to generate invoice for:");
            int aid = Int32.Parse(Console.ReadLine());

            Appointment appointment = appointmentList.Find(a => a.AID == aid);

            if (appointment != null)
            {
                int iid = invoiceList.Count + 1; // Generating new invoice ID
                DateTime dateIssued = DateTime.Now;
                DateTime datePaid = new DateTime(1111, 11, 11);
                float totalCost = appointment.LaborCost + appointment.PartsCost;

                Invoice newInvoice = new Invoice(iid, appointment.CID, aid, totalCost, dateIssued, datePaid);
                invoiceList.Add(newInvoice);

                Console.WriteLine("Invoice generated successfully.");
                Console.WriteLine(newInvoice.ToString());
                Console.ReadLine();
                invoiceMenu();
            }
            else
            {
                Console.WriteLine("Appointment not found.");
                Console.ReadLine();
                invoiceMenu();
            }
        }

        static void payInvoice()
        {
            Console.WriteLine("Enter Invoice ID to pay:");
            int payIID = Int32.Parse(Console.ReadLine());

            Invoice invoiceToPay = invoiceList.Find(i => i.IID == payIID);

            if (invoiceToPay != null)
            {
                invoiceToPay.DatePaid = DateTime.Now;
                Console.WriteLine("Invoice paid successfully.");
                Console.ReadLine();
                invoiceMenu();
            }
            else
            {
                Console.WriteLine("Invoice not found.");
                Console.ReadLine();
                invoiceMenu();
            }
        }


    }













}
