using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Data
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }

        public Customer()
        {

        }

        public Customer(int id, string name, long phone, string email)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Email = email;
        }

        public override string ToString()
        {
            return $"Customer Id: {Id}, Name: {Name}, Phone: {Phone}, Email: {Email}";
        }
    }

}
