using hotel_managment_system.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_managment_system
{
    public class TotalTreatmentCosts
    {
        public ObservableCollection<Treatment> Treatments { get; set; } = new ObservableCollection<Treatment>();
        public double AmountTreatmentCosts { get; set; }
        public double Discount { get; set; }
    }
}
