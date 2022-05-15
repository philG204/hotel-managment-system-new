using hotel_managment_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.managment.system.Test
{
    public class CreateEmployee
    {
        public static Employee GetEmployee()
        {
            Employee employee2 = new Employee();

            employee2.EmployeeID = 3;
            employee2.Name = "Name3";
            employee2.Surename = "Surename3";
            employee2.Street = "street3";
            employee2.Housenumber = 3;
            employee2.PhoneNumber = 1234;
            employee2.City = "city3";
            employee2.Email = "email3@.com";
            employee2.PostalCode = 123145;
            employee2.Password = "passwwort1234";

            return employee2;
        }
    }
}
