using hotel.managment.system.Data.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_managment_system
{
    public interface IBookingRepository : IRepositoryBase<int, Booking>
    {
    }
}
