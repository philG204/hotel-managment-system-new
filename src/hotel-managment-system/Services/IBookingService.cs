using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_managment_system
{
    public interface IBookingService : IBookingRepository
    {
        List<Booking> GetAll();
    }
}
