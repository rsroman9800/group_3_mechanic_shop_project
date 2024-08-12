using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Data
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Vin { get; set; }

        public Vehicle()
        {

        }

        public Vehicle(int id, int customerId, string make, string model, string year, string vin)
        {
            Id = id;
            CustomerId = customerId;
            Make = make;
            Model = model;
            Year = year;
            Vin = vin;
        }

        public override string ToString()
        {
            return $"Vehicle Id: {Id}, Customer Id: {CustomerId}, Make: {Make}, Model: {Model}, Year: {Year}, Vin: {Vin}";
        }
    }
}
