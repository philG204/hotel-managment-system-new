using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_managment_system
{
    public interface IBookingService : IBookingRepository
    {
        ObservableCollection<Booking> GetAll();
    }
}
