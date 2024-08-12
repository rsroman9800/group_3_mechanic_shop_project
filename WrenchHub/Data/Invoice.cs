using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Data
{
    public class InvoiceModel
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public int AppointmentId { get; set; }
        public double LaborCost { get; set; }
        public double PartsCost { get; set; }
        public double TotalCost { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime? DatePaid { get; set; }

        public InvoiceModel()
        {

        }

        public InvoiceModel(int invoiceId, int customerId, int appointmentId, double laborCost, double partsCost, double totalCost, DateTime dateIssued, DateTime? datePaid)
        {
            InvoiceId = invoiceId;
            CustomerId = customerId;
            AppointmentId = appointmentId;
            LaborCost = laborCost;
            PartsCost = partsCost;
            TotalCost = totalCost;
            DateIssued = dateIssued;
            DatePaid = datePaid;
        }

        public override string ToString()
        {
            return $"InvoiceId: {InvoiceId}, CustomerId: {CustomerId}, AppointmentId: {AppointmentId}, LaborCost: {LaborCost}, PartsCost: {PartsCost}, TotalCost: {TotalCost}, DateIssued: {DateIssued.ToShortDateString()}, DatePaid: {DatePaid?.ToShortDateString()}";
        }
    }
}
