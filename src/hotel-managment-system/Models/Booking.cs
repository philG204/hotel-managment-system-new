using System;

namespace hotel_managment_system
{
    public class Booking
    {
        public int BookingID { get; set; }
        public Customer Customer { get; set; }
        public Breakfast Breakfast { get; set; }
        public DateTime BookingDate { get; set; }
        public string MethodOfPayment { get; set; }
        public double Amount { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Depature { get; set; }
        public bool settel { get; set; }
        public Event Event { get; set; }
        public SubRoom Room { get; set; }
        public TotalMealCosts TotalMealCosts { get; set; }
        public TotalTreatmentCosts TotalTreatmentCosts { get; set; }
        public SubEmployee SubEmployee { get; set; }
    }
}