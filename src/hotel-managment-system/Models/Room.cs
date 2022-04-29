using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_managment_system.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public Bed Bed { get; set; }
        public string RoomName { get; set; }
        public double Price { get; set; }
        public byte NumberOfRooms { get; set; }
        public string Positon { get; set; }
        public string Floor { get; set; }
        public byte SizeOfShower { get; set; }
        public string Equipment { get; set; }
        public string Lightning { get; set; }
        public byte Size { get; set; }
        public Equipment equipment { get; set; }
    }
}
