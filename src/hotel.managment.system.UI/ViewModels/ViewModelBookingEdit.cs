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
    }
}
