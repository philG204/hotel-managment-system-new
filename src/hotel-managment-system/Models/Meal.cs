using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_managment_system.Models
{
    public class Meal
    {
        public int MealID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Discount discount { get; set; }
    }
}
