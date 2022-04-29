using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_managment_system.Models
{
    public class Treatment
    {
        public int TreatmentID { get; set; }
        public string TreatmentName { get; set; }
        public double TreatmentAmount { get; set; }
        public Discount discount { get; set; }  
    }
}
