using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_managment_system.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public string Street { get; set; }
        public int Housenumber { get; set; }
        public long PostalCode { get; set; }
        public string City { get; set; }    
        public long PhoneNumber { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
