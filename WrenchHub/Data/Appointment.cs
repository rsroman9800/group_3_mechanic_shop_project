using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Data
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int VehicleId { get; set; }
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public double LaborCost { get; set; }
        public double PartsCost { get; set; }
        public DateTime Date { get; set; }

        public Appointment()
        {

        }

        public Appointment(int appointmentId, int vehicleId, int customerId, string description, double laborCost, double partsCost, DateTime date)
        {
            AppointmentId = appointmentId;
            VehicleId = vehicleId;
            CustomerId = customerId;
            Description = description;
            LaborCost = laborCost;
            PartsCost = partsCost;
            Date = date;
        }

        public override string ToString()
        {
            return $"AppointmentId: {AppointmentId}, VehicleId: {VehicleId}, CustomerId: {CustomerId}, Description: {Description}, LaborCost: {LaborCost}, PartsCost: {PartsCost}, Date: {Date.ToShortDateString()}";
        }
    }
}
