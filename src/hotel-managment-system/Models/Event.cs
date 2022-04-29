using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_managment_system
{
    public class Event
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public double DiscountValue { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
