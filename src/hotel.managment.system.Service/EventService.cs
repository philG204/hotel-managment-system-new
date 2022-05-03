using hotel.managment.system.Data.DB;
using hotel_managment_system;
using hotel_managment_system_v2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.managment.system.Service
{
    public class EventService : IEventService
    {
        private readonly EventRepository eventRepository = new EventRepository();

        public bool Delete(Event obj) => eventRepository.Delete(obj);

        public bool Delete(int id) => eventRepository.Delete(id);   

        public Event Get(int TId) => eventRepository.Get(TId);

        public List<Event> GetAll() => eventRepository.GetAll();

        public bool Save(Event obj) => eventRepository.Save(obj);
    }
}
