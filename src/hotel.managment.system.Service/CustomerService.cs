using hotel.managment.system.Data.DB;
using hotel_managment_system;
using hotel_managment_system_v2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.managment.system.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerRepository customerRepository;
        public bool Delete(Customer obj) => customerRepository.Delete(obj); 

        public bool Delete(int id) => customerRepository.Delete(id);    

        public Customer Get(int TId) => customerRepository.Get(TId);    

        public List<Customer> GetAll() => customerRepository.GetAll();  

        public bool Save(Customer obj) => customerRepository.Save(obj);
    }
}
