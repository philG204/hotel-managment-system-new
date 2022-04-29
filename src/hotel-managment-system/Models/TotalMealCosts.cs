using hotel_managment_system.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_managment_system
{
    public class TotalMealCosts
    {
        public ObservableCollection<Meal> Meals { get; set; } = new ObservableCollection<Meal> { };
        public double MealCost { get; set; }
        public double discount { get; set; }
    }
}
