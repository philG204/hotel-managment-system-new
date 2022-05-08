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
    public class MealService : IMealService
    {
        private readonly MealRepository mealRepositroy = new MealRepository();

        public bool Delete(Meal obj) => mealRepositroy.Delete(obj);

        public bool Delete(int id) => mealRepositroy.Delete(id);    

        public Meal Get(int TId) => mealRepositroy.Get(TId);

        public ObservableCollection<Meal> GetAll() => mealRepositroy.GetAll();

        public bool Save(Meal obj) => mealRepositroy.Save(obj);
    }
}
