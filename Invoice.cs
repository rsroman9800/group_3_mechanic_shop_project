using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mechanic_database
{
    internal class Invoice
    {
        public int IID { get; set; } // Invoice ID
        public int AID { get; set; } // Appointment ID
        public int CID { get; set; } // Customer ID
        public float TotalCost { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime DatePaid { get; set; }


        public Invoice(int iid, int cid, int aid, float totalCost, DateTime dateIssued, DateTime datePaid)
        {
            IID = iid;
            AID = aid;
            CID = cid;
            TotalCost = totalCost;
            DateIssued = dateIssued;
            DatePaid = datePaid;
        }

        public override string ToString()
        {
            return $"Invoice Id: {IID}, Appointment Id: {AID}, Customer Id: {CID},\n Total Cost: {TotalCost},\n Date Issued: {DateIssued.ToShortDateString()}, Date Paid: {DatePaid.ToShortDateString()}";
        }
    }
}
