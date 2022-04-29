using hotel.managment.system.Data.DB;
using hotel_managment_system;
using System.Collections.Generic;

namespace hotel.managment.system.Service
{
    public class BookingService : IBookingService
    {
        private readonly BookingRepository bookingRepository = new BookingRepository();
        
        public bool Delete(Booking obj) => bookingRepository.Delete(obj);

        public bool Delete(int id) => bookingRepository.Delete(id);

        public Booking Get(int TId) => bookingRepository.Get(TId);

        public List<Booking> GetAll() => bookingRepository.GetAll();

        public bool Save(Booking obj) => bookingRepository.Save(obj);

        List<Booking> IBookingService.GetAll() => bookingRepository.GetAll();
    }
}