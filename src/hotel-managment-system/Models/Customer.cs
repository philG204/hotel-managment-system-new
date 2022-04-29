using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_managment_system
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public long  PostalCode { get; set; }
        public string City { get; set; }
        public string KindOfTravaler { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string EducationalStatus { get; set; }
        public string Vocation { get; set; }
    }
}
