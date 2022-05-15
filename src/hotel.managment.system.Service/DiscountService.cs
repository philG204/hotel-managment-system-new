using hotel_managment_system.Models;
using hotel_managment_system_v2.Services;
using hotel.managment.system.Data.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.managment.system.Service
{
    public class DiscountService : IDiscountService
    {
        private readonly DiscountRepository discountRepository = new DiscountRepository();
        public bool Delete(Discount obj) => discountRepository.Delete(obj);
     

        public bool Delete(int id) => discountRepository.Delete(id);    

        public Discount Get(int TId) => discountRepository.Get(TId);    

        public ObservableCollection<Discount> GetAll() => discountRepository.GetAll();

        public bool Save(Discount obj) => discountRepository.Save(obj);
    }
}
