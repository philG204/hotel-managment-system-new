using hotel.managment.system.Data.DB;
using hotel_managment_system.Models;
using hotel_managment_system_v2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.managment.system.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeRepositroy employeeRepositroy;

        public bool Delete(Employee obj) => employeeRepositroy.Delete(obj);

        public bool Delete(int id) => employeeRepositroy.Delete(id);

        public Employee Get(int TId) => employeeRepositroy.Get(TId);

        public List<Employee> GetAll() => employeeRepositroy.GetAll();

        public bool Save(Employee obj) => employeeRepositroy.Save(obj);

        public string EncryptPassword(string password)
        {
            throw new NotImplementedException;
        }
    }
}
