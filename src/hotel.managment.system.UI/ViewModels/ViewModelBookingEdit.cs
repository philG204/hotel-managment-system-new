using hotel_managment_system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.managment.system.UI.ViewModels
{
    public class ViewModelBookingEdit
    {
        private Booking model;
        public ViewModelBookingEdit(Booking booking)
        {
            model = booking;
        }

        public int BookingID { get => model.BookingID; set => model.BookingID = value; }
        public Customer Customer { get => model.Customer; set => model.Customer = value; }
        public Breakfast Breakfast { get => model.Breakfast; set => model.Breakfast = value; }
        public DateTime BookingDate { get => model.BookingDate; set => model.BookingDate = value; }
        public string MethodOfPayment { get => model.MethodOfPayment; set => model.MethodOfPayment = value; }
        public double Amount { get => model.Amount; set => model.Amount = value; }
        public DateTime Arrival { get => model.Arrival; set => model.Arrival = value; }
        public DateTime Depature { get => model.Depature; set => model.Depature = value; }
        public bool settel { get => model.settel; set => model.settel = value; }
        public Event Event { get => model.Event; set => model.Event = value; }
    }
}
