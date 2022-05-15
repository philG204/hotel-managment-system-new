using hotel.managment.system.Service;
using hotel_managment_system;
using hotel_managment_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.managment.system.Test
{
    public class CreateBooking
    {
        public static Booking GetBooking()
        {
            BookingService bookingService = new BookingService();

            int id;
            do
            {
                Random rand = new Random();
                id = rand.Next(1, 10000);
            }
            while (!bookingService.CheckIDs(id.ToString()));

            Booking booking = new Booking();
            booking.BookingID = id;
            booking.BookingDate = DateTime.Now; 
            booking.Depature = DateTime.Now;
            booking.Arrival = DateTime.Now;
            booking.Amount = 2500;
            booking.MethodOfPayment = "card";
            booking.settel = true;

            Breakfast bf = new Breakfast();
            bf.BreakfastID = 1;
            bf.KindOfBreakfast = "mF";
            bf.AdditionAmount = 30;

            booking.Breakfast = bf;

            Customer customer2 = new Customer();
            customer2.CustomerID = 9;
            customer2.Name = "Name9";
            customer2.Surname = "Surename9";
            customer2.Street = "Street9";
            customer2.City = "City9";
            customer2.Email = "email9.@email.com";
            customer2.Vocation = "Vocation9";
            customer2.MaritalStatus = "maritalStatus9";
            customer2.KindOfTravaler = "KindOfTravaler9";
            customer2.Birthday = new DateTime();
            customer2.EducationalStatus = "EducationalStatus9";
            customer2.HouseNumber = "9";
            customer2.PhoneNumber = 1234567;
            customer2.Gender = "gender9";
            customer2.PostalCode = 1234;

            booking.Customer = customer2;

            SubEmployee sub = new SubEmployee();

            Employee employee2 = new Employee();

            employee2.EmployeeID = 3;
            employee2.Name = "Name3";
            employee2.Surename = "Surename3";
            employee2.Street = "street3";
            employee2.Housenumber = 3;
            employee2.PhoneNumber = 1234;
            employee2.City = "city3";
            employee2.Email = "email3@.com";
            employee2.PostalCode = 123145;
            employee2.Password = "passwwort1234";

            sub.Employee = employee2;
            sub.Date = DateTime.Now;

            booking.SubEmployee = sub;

            Event e = new Event();
            e.EventID = 1;
            e.EventName = "Aktion1";

            booking.Event = e;

            SubRoom subRoom = new SubRoom();
            subRoom.AmountPrice = 100;
            subRoom.DiscountValue = 12;

            Room r = new Room();
            r.RoomID = 1;
            r.RoomName = "room1";
            r.NumberOfRooms = 1;
            r.Price = 100;
            r.Size = 23;
            r.SizeOfShower = 2;
            r.Floor = "floor1";
            r.Lightning = "lightning1";
            r.Positon = "positoin1";

            Bed b = new Bed();
            b.BedID = 1;
            b.NumberOfBeds = 1;
            b.Name = "bed1";

            r.Bed.Add(b);

            Equipment equip = new Equipment();
            equip.EquipmentID = 1;
            equip.EquipmentName = "Ausstatung1";
     
            r.equipment = equip;

            subRoom.Rooms.Add(r);
            booking.Room = subRoom;

            return booking;
        }
    }
}
