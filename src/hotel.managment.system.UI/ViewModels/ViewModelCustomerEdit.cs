using hotel_managment_system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.managment.system.UI.ViewModels
{
    public class ViewModelCustomerEdit
    {
        private Customer model;
        public ViewModelCustomerEdit(Customer customer)
        {
            model = customer;
        }
    }
}
