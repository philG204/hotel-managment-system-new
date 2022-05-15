using hotel_managment_system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.managment.system.Test
{
    public class CreateCustomer
    {
        public static Customer GetCustomer()
        {
            Customer customer2 = new Customer();
            customer2.CustomerID = 9;
            customer2.Name = "Name9";
            customer2.Surname = "Surename9";
            customer2.Street = "Street9";
            customer2.City = "City9";
            customer2.Email = "email9.@email.com";
            customer2.Vocation = "Vocation9";
            customer2.MaritalStatus = "maritalStatus9";
            customer2.KindOfTravaler = "KindOfTravaler9";
            customer2.Birthday = new DateTime();
            customer2.EducationalStatus = "EducationalStatus9";
            customer2.HouseNumber = "9";
            customer2.PhoneNumber = 1234567;
            customer2.Gender = "gender9";
            customer2.PostalCode = 1234;

            return customer2;
        }
    }
}
