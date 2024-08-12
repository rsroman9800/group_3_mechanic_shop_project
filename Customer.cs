using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mechanic_database
{
    internal class Customer
    {
        public int CID { get; set; } // Customer ID
        public string Name { get; set; }
        public long Phone {  get; set; }
        public string Email { get; set; }

        public Customer(int id, string name, long phone, string email)
        {
            CID = id;
            Name = name;
            Phone = phone;
            Email = email;
        }

        public override string ToString()
        {
            return $"Customer Id: {CID}, Name: {Name}, Phone: {Phone}, Email: {Email}";
        }
    }
}
