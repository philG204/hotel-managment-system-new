using hotel_managment_system;
using hotel.managment.system.Data.DB;
using hotel_managment_system_v2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.managment.system.Service
{
    internal class BreakfastService : IBreakfastService
    {
        private readonly BreakfastRepository breakfastRepository = new BreakfastRepository();

        public bool Delete(Breakfast obj) => breakfastRepository.Delete(obj);

        public bool Delete(int id) => breakfastRepository.Delete(id);

        public Breakfast Get(int TId) => breakfastRepository.Get(TId);  

        public List<Breakfast> GetAll() => breakfastRepository.GetAll();    

        public bool Save(Breakfast obj) => breakfastRepository.Save(obj);
    }
}
