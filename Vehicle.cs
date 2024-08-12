using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace mechanic_database
{
    internal class Vehicle
    {
        public int VID { get; set; } // Vehicle ID
        public int CID { get; set; } // Customer ID
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Vin { get; set; }


        public Vehicle(int vid, int cid, string make, string model, string year, string vin)
        {
            VID = vid;
            CID = cid;
            Make = make;
            Model = model;
            Year = year;
            Vin = vin;
        }

        public override string ToString()
        {
            return $"Vehicle Id: {VID}, Customer Id: {CID}, Make: {Make}, Model: {Model}, Year: {Year}, VIN: {Vin}";
        }
    }
}
