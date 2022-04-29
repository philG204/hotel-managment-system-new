using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_managment_system.Models
{
    public class Receipt
    {
        public int ReceiptID { get; set; }
        public Customer Customer { get; set; }
        public DateTime PaymentDate { get; set; }
        public string MethodOfPayment { get; set; }
        public double CashAmount { get; set; }
        public bool settel { get; set; }
        public TotalMealCosts TotalMealCosts { get; set; }
        public TotalTreatmentCosts TotalTreatmentCosts { get; set; }  
        public Event Event { get; set; }
        public SubEmployee SubEmployee { get; set; }
    }
}
