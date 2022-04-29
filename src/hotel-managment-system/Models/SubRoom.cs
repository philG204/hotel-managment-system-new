using hotel_managment_system.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_managment_system
{
    public class SubRoom
    {
        public ObservableCollection<Room> Rooms { get; set; } = new ObservableCollection<Room> { };
        public double AmountPrice { get; set; }
        public double DiscountValue { get; set; }
    }
}
