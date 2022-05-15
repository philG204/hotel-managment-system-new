using hotel.managment.system.Data.DB;
using hotel_managment_system.Models;
using hotel_managment_system_v2.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.managment.system.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeRepositroy employeeRepositroy = new EmployeeRepositroy();

        public bool Delete(Employee obj) => employeeRepositroy.Delete(obj);

        public bool Delete(int id) => employeeRepositroy.Delete(id);

        public Employee Get(int TId) => employeeRepositroy.Get(TId);

        public ObservableCollection<Employee> GetAll() => employeeRepositroy.GetAll();

        public bool Save(Employee obj) => employeeRepositroy.Save(obj);
        public bool CheckIDs(string toCheckId)
        {
            ObservableCollection<string> Ids = employeeRepositroy.GetEmployeeIDs();
            foreach (string id in Ids)
            {
                if (id == toCheckId)
                {
                    return false;
                }
            }
            return true;
        }
    
        public bool CheckPassword(string password, string name)
        {
            try
            {
                ObservableCollection<Employee> employees = employeeRepositroy.GetAll();

                foreach (Employee employee in employees)
                {
                    if (employee.Name == name && employee.Password == password)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
