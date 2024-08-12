using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mechanic_database
{
    internal class Appointment
    {
        public int AID { get; set; } // Appointment ID
        public int VID { get; set; } // Vehicle ID
        public int CID { get; set; } // Customer ID
        public string Description { get; set; }
        public float LaborCost { get; set; }
        public float PartsCost { get; set; }
        public DateTime Date { get; set; }


        public Appointment(int aid ,int vid, int cid, string description, float laborCost, float partsCost, DateTime date)
        {
            AID = aid;
            VID = vid;
            CID = cid;
            Description = description;
            LaborCost = laborCost;
            PartsCost = partsCost;
            Date = date;
        }

        public override string ToString()
        {
            return $"Appointment Id: {AID}, Vehicle Id: {VID}, Customer Id: {CID}, Labor Cost: {LaborCost}, Parts Cost: {PartsCost}, Date: {Date.ToShortDateString()}, \n{Description}";
        }
    }
}
