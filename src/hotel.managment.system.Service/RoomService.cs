using hotel.managment.system.Data.DB;
using hotel_managment_system.Models;
using hotel_managment_system_v2.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.managment.system.Service
{
    public class RoomService : IRoomService
    {
        private RoomRepository roomRepositroy = new RoomRepository();

        public bool Delete(Room obj) => roomRepositroy.Delete(obj);

        public bool Delete(int id) => roomRepositroy.Delete(id);

        public Room Get(int TId) => roomRepositroy.Get(TId);

        public ObservableCollection<Room> GetAll() => roomRepositroy.GetAll();  

        public bool Save(Room obj) => roomRepositroy.Save(obj);
    }
}
