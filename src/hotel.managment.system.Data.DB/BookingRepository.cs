using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel_managment_system;
using hotel_managment_system.Models;

namespace hotel.managment.system.Data.DB
{
    public class BookingRepository : IBookingRepository
    {
        public bool Delete(Booking obj)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand cmd = new OleDbCommand("DELETE FROM `Buchung` WHERE `Buchungsnummer`= ?", connection);
                cmd.Parameters.Add(new OleDbParameter { Value = obj.BookingID });

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand cmd = new OleDbCommand("DELETE FROM `Buchung` WHERE `Buchungsnummer`= ?", connection);
                cmd.Parameters.Add(new OleDbParameter { Value = id });

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public Booking Get(int TId)

        {
            try
            {
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand cmdCheck = new OleDbCommand("SELECT `Buchungsnummer` FROM `Buchung` WHERE `Buchungsnummer` = ?", connection);
                cmdCheck.Parameters.Add(new OleDbParameter { Value = TId });
                var edDr = cmdCheck.ExecuteReader();
                edDr.Read();

                if (edDr.HasRows == true)
                {                   

                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM `Buchung` WHERE `Buchungsnummer` = ?", connection);
                    cmd.Parameters.Add(new OleDbParameter { Value = TId });

                    var dr = cmd.ExecuteReader();

                    dr.Read();
                    Booking booking = new Booking();
                    booking.BookingID = dr.GetInt32(0);
                    booking.BookingDate = dr.GetDateTime(3);
                    booking.MethodOfPayment = dr.GetString(4);
                    booking.Amount = Convert.ToDouble(dr.GetValue(5));
                    booking.Arrival = dr.GetDateTime(6);
                    booking.Depature = dr.GetDateTime(7);
                    booking.settel = dr.GetBoolean(8);

                    OleDbCommand cmd2 = new OleDbCommand("SELECT * FROM `Kunde` WHERE `Kundennummer` = ?", connection);
                    cmd2.Parameters.Add(new OleDbParameter { Value = dr.GetValue(1) });

                    var Cdr = cmd2.ExecuteReader();

                    Cdr.Read();
                    Customer customer = new Customer();
                    customer.CustomerID = Cdr.GetInt32(0);
                    customer.Name = Cdr.GetString(1);
                    customer.Surname = Cdr.GetString(2);
                    customer.Street = Cdr.GetString(3);
                    customer.HouseNumber = Convert.ToString(Cdr.GetValue(4));
                    customer.PostalCode = Convert.ToInt64(Cdr.GetValue(5));
                    customer.City = Convert.ToString(Cdr.GetValue(6));
                    customer.KindOfTravaler = Convert.ToString(Cdr.GetValue(7));
                    customer.PhoneNumber = Convert.ToInt64(Cdr.GetValue(8));
                    customer.Email = Convert.ToString(Cdr.GetValue(9));
                    customer.Birthday = Convert.ToDateTime(Cdr.GetValue(10));
                    customer.Gender = Convert.ToString(Cdr.GetValue(11));
                    customer.MaritalStatus = Convert.ToString(Cdr.GetValue(12));
                    customer.EducationalStatus = Convert.ToString(Cdr.GetValue(13));
                    customer.Vocation = Convert.ToString(Cdr.GetValue(14));

                    booking.Customer = customer;

                    OleDbCommand cmd3 = new OleDbCommand("SELECT * FROM `Buchung_Aktion` WHERE `Buchungsnummer`= ?", connection);
                    cmd3.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                    var aDR = cmd3.ExecuteReader();

                    if (aDR.HasRows)
                    {
                        OleDbCommand cmd4 = new OleDbCommand("SELECT * FROM `Aktion` WHERE `Aktionsnummer` = (SELECT `Aktionsnummer` FROM `Buchung_Aktion` WHERE `Buchungsnummer` = ?)", connection);
                        cmd4.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                        var ADr = cmd4.ExecuteReader();

                        ADr.Read();
                        Event Event = new Event();
                        Event.EventID = Convert.ToInt32(ADr.GetValue(0));
                        Event.EventName = Convert.ToString(ADr.GetValue(1));
                        Event.DiscountValue = Convert.ToByte(ADr.GetValue(2));
                        Event.From = Convert.ToDateTime(ADr.GetValue(3));
                        Event.To = Convert.ToDateTime(ADr.GetValue(4));

                        booking.Event = Event;
                    }

                    SubRoom subRoom = new SubRoom();

                    OleDbCommand cmd5 = new OleDbCommand("SELECT * FROM `Zimmer` WHERE `Zimmernummer` = (SELECT `Zimmernummer` FROM `Buchung_Zimmer` WHERE `Buchungsnummer` = ?)", connection);
                    cmd5.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                    var RDr = cmd5.ExecuteReader();

                    while (RDr.Read())
                    {
                        Room room = new Room();
                        room.RoomID = Convert.ToInt32(RDr.GetValue(0));

                        OleDbCommand cmd6 = new OleDbCommand("SELECT * FROM `Zimmer_Betten` WHERE `Bettnummer` = (SELECT `Bettnummer` FROM `Zimmer_Bettzuteilung` WHERE `Zimmernummer` = ?)", connection);
                        cmd6.Parameters.Add(new OleDbParameter { Value = RDr.GetValue(0) });

                        var Bdr = cmd6.ExecuteReader();

                        Bdr.Read();
                        Bed bed = new Bed();
                        bed.BedID = Convert.ToInt32(Bdr.GetValue(0));
                        bed.Name = Convert.ToString(Bdr.GetValue(1));
                        bed.NumberOfBeds = Convert.ToByte(Bdr.GetValue(2));

                        room.Bed = bed;
                        room.RoomName = Convert.ToString(RDr.GetValue(2));
                        room.Price = Convert.ToByte(RDr.GetValue(3));
                        room.NumberOfRooms = Convert.ToByte(RDr.GetValue(4));
                        room.Positon = Convert.ToString(RDr.GetValue(5));
                        room.Floor = Convert.ToString(RDr.GetValue(6));
                        room.SizeOfShower = Convert.ToByte(RDr.GetValue(7));
                        room.Equipment = Convert.ToString(RDr.GetValue(8));
                        room.Lightning = Convert.ToString(RDr.GetValue(9));
                        room.Size = Convert.ToByte(RDr.GetValue(3));

                        OleDbCommand cmd7 = new OleDbCommand("SELECT * FROM `Ausstatungsgegenstaende` WHERE `Ausstatungsnummer` = (SELECT `Ausstatungsnummer` FROM `Buchung_Zimmer` WHERE `Buchungsnummer` = ?)", connection);
                        cmd7.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                        var EDDr = cmd7.ExecuteReader();
                        EDDr.Read();

                        Equipment equipment = new Equipment();
                        equipment.EquipmentID = Convert.ToInt32(EDDr.GetValue(0));
                        equipment.EquipmentName = Convert.ToString(EDDr.GetValue(1));

                        room.equipment = equipment;

                        subRoom.Rooms.Add(room);

                        OleDbCommand cmd8 = new OleDbCommand("SELECT `Zimmerpreis`, `Zimmerrabatt` FROM `Buchung_Zimmer` WHERE `Buchungsnummer` = ?", connection);
                        cmd8.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                        var RPDr = cmd8.ExecuteReader();
                        RPDr.Read();

                        subRoom.AmountPrice = Convert.ToDouble(RPDr.GetValue(0));
                        subRoom.DiscountValue = Convert.ToByte(RPDr.GetValue(1));
                    }

                    booking.Room = subRoom;

                    TotalMealCosts totalMealCost = new TotalMealCosts();

                    OleDbCommand cmd9 = new OleDbCommand("SELECT * FROM `Speisen` WHERE `Speisennummer` = (SELECT `Speisennummer` FROM `Buchung_Hotel_Speisen` WHERE `Buchungsnummer` = ?)", connection);
                    cmd9.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                    var MDr = cmd9.ExecuteReader();

                    if (MDr.HasRows)
                    {
                        while (MDr.Read())
                        {
                            Meal meal = new Meal();
                            meal.MealID = Convert.ToInt32(MDr.GetValue(0));
                            meal.Name = Convert.ToString(MDr.GetValue(1));

                            OleDbCommand cmd10 = new OleDbCommand("SELECT * FROM `Rabatt` WHERE `Rabattnummer` = (SELECT `Rabattnummer` FROM `Speisen` WHERE `Speisennummer` = ?)", connection);
                            cmd10.Parameters.Add(new OleDbParameter { Value = MDr.GetValue(0) });

                            var DDr = cmd10.ExecuteReader();

                            DDr.Read();
                            Discount discount = new Discount();
                            discount.DiscountID = Convert.ToInt32(DDr.GetValue(0));
                            discount.DiscountValue = Convert.ToByte(DDr.GetValue(1));

                            meal.discount = discount;
                            totalMealCost.Meals.Add(meal);
                        }

                        OleDbCommand cmd11 = new OleDbCommand("SELECT `Speisen_Buchungspreis`, `Speisen_Buchungrabatt` FROM `Buchung_Hotel_Speisen` WHERE `Buchungsnummer` = ?", connection);
                        cmd11.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                        var MPDr = cmd11.ExecuteReader();
                        MPDr.Read();

                        totalMealCost.MealCost = Convert.ToDouble(MPDr.GetValue(0));
                        totalMealCost.discount = Convert.ToDouble(MPDr.GetValue(1));

                        booking.TotalMealCosts = totalMealCost;
                    }

                    OleDbCommand cmd12 = new OleDbCommand("SELECT * FROM `Behandlung` WHERE `Behandlungsnummer` = (SELECT `Behandlungsnummer` FROM `Buchung_Hotel_Behandlung` WHERE `Buchungsnummer` = ?)", connection);
                    cmd12.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                    var TDr = cmd12.ExecuteReader();


                    if (TDr.HasRows)
                    {
                        TotalTreatmentCosts totalTreatmentCost = new TotalTreatmentCosts();

                        while (TDr.Read())
                        {
                            Treatment treatment = new Treatment();
                            treatment.TreatmentID = Convert.ToInt32(TDr.GetValue(0));
                            treatment.TreatmentName = Convert.ToString(TDr.GetValue(1));

                            OleDbCommand cmd10 = new OleDbCommand("SELECT * FROM `Rabatt` WHERE `Rabattnummer` = (SELECT `Rabattnummer` FROM `Behandlung` WHERE `Behandlungsnummer` = ?)", connection);
                            cmd10.Parameters.Add(new OleDbParameter { Value = TDr.GetValue(0) });

                            var DDr = cmd10.ExecuteReader();

                            DDr.Read();
                            Discount discount = new Discount();
                            discount.DiscountID = Convert.ToInt32(DDr.GetValue(0));
                            discount.DiscountValue = Convert.ToDouble(DDr.GetValue(1));

                            treatment.discount = discount;

                            totalTreatmentCost.Treatments.Add(treatment);
                        }

                        OleDbCommand cmd13 = new OleDbCommand("SELECT `Behandlung_Buchungspreis`, `Behandlung_Buchungrabatt` FROM `Buchung_Hotel_Behandlung` WHERE `Buchungsnummer` = ?", connection);
                        cmd13.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                        var TCDr = cmd13.ExecuteReader();
                        TCDr.Read();

                        totalTreatmentCost.AmountTreatmentCosts = Convert.ToDouble(TCDr.GetValue(0));
                        totalTreatmentCost.Discount = Convert.ToDouble(TCDr.GetValue(1));

                        booking.TotalTreatmentCosts = totalTreatmentCost;
                    }


                    SubEmployee subEmployee = new SubEmployee();

                    OleDbCommand cmd14 = new OleDbCommand("SELECT * FROM `Mitarbeiter` WHERE `Mitarbeiternummer` = (SELECT `Mitarbeiternummer` FROM `Buchung_Mitarbeiter` WHERE `Buchungsnummer` = ?)", connection);
                    cmd14.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                    var EDr = cmd14.ExecuteReader();
                    EDr.Read();

                    Employee employee = new Employee();
                    employee.EmployeeID = Convert.ToInt32(EDr.GetValue(0));
                    employee.Name = Convert.ToString(EDr.GetValue(1));
                    employee.Surename = Convert.ToString(EDr.GetValue(2));
                    employee.Street = Convert.ToString(EDr.GetValue(3));
                    employee.Housenumber = Convert.ToInt32(EDr.GetValue(4));
                    employee.PostalCode = Convert.ToInt64(EDr.GetValue(5));
                    employee.City = Convert.ToString(EDr.GetValue(6));
                    employee.PhoneNumber = Convert.ToInt64(EDr.GetValue(7));
                    employee.Email = Convert.ToString(EDr.GetValue(8));
                    employee.Password = Convert.ToString(EDr.GetValue(9));

                    subEmployee.Employee = employee;

                    OleDbCommand cmd15 = new OleDbCommand("SELECT `Mitarbeiter_Datum` FROM `Buchung_Mitarbeiter` WHERE `Buchungsnummer` = ?", connection);
                    cmd15.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                    var EdDr = cmd15.ExecuteReader();
                    EdDr.Read();

                    subEmployee.Date = Convert.ToDateTime(EdDr.GetValue(0));

                    booking.SubEmployee = subEmployee;

                    return booking;
                }
                else
                {
                    return new Booking();
                }             
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Booking> GetAll()
        {
            try
            {
                List<Booking> bookingList = new List<Booking>();
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM `Buchung`", connection);

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Booking booking = new Booking();
                    booking.BookingID = dr.GetInt32(0);
                    booking.BookingDate = dr.GetDateTime(3);
                    booking.MethodOfPayment = dr.GetString(4);
                    booking.Amount = Convert.ToDouble(dr.GetValue(5));
                    booking.Arrival = dr.GetDateTime(6);
                    booking.Depature = dr.GetDateTime(7);
                    booking.settel = dr.GetBoolean(8);

                    OleDbCommand cmd2 = new OleDbCommand("SELECT * FROM `Kunde` WHERE `Kundennummer` = ?", connection);
                    cmd2.Parameters.Add(new OleDbParameter { Value = dr.GetValue(1) });

                    var Cdr = cmd2.ExecuteReader();

                    Cdr.Read();
                    Customer customer = new Customer();
                    customer.CustomerID = Cdr.GetInt32(0);
                    customer.Name = Cdr.GetString(1);
                    customer.Surname = Cdr.GetString(2);
                    customer.Street = Cdr.GetString(3);
                    customer.HouseNumber = Convert.ToString(Cdr.GetValue(4));
                    customer.PostalCode = Convert.ToInt64(Cdr.GetValue(5));
                    customer.City = Convert.ToString(Cdr.GetValue(6));
                    customer.KindOfTravaler = Convert.ToString(Cdr.GetValue(7));
                    customer.PhoneNumber = Convert.ToInt64(Cdr.GetValue(8));
                    customer.Email = Convert.ToString(Cdr.GetValue(9));
                    customer.Birthday = Convert.ToDateTime(Cdr.GetValue(10));
                    customer.Gender = Convert.ToString(Cdr.GetValue(11));
                    customer.MaritalStatus = Convert.ToString(Cdr.GetValue(12));
                    customer.EducationalStatus = Convert.ToString(Cdr.GetValue(13));
                    customer.Vocation = Convert.ToString(Cdr.GetValue(14));

                    booking.Customer = customer;

                    OleDbCommand cmd3 = new OleDbCommand("SELECT * FROM `Buchung_Aktion` WHERE `Buchungsnummer`= ?", connection);                   
                    cmd3.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });
                    
                    var aDR = cmd3.ExecuteReader();

                    if (aDR.HasRows)
                    {
                        OleDbCommand cmd4 = new OleDbCommand("SELECT * FROM Aktion INNER JOIN Buchung_Aktion ON Aktion.Aktionsnummer = Buchung_Aktion.Aktionsnummer WHERE `Kassenbelegnummer` =", connection);
                        cmd4.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                        var ADr = cmd4.ExecuteReader();

                        ADr.Read();
                        Event Event = new Event();
                        Event.EventID = Convert.ToInt32(ADr.GetValue(0));
                        Event.EventName = Convert.ToString(ADr.GetValue(1));
                        Event.DiscountValue = Convert.ToByte(ADr.GetValue(2));
                        Event.From = Convert.ToDateTime(ADr.GetValue(3));
                        Event.To = Convert.ToDateTime(ADr.GetValue(4));

                        booking.Event = Event;
                    }                  

                    SubRoom subRoom = new SubRoom();

                    OleDbCommand cmd5 = new OleDbCommand("SELECT * FROM `Zimmer` INNER JOIN `Buchung_Zimmer` WHERE `Buchungsnummer` = ?", connection);
                    cmd5.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                    var RDr = cmd5.ExecuteReader();

                    while (RDr.Read())
                    {
                        Room room = new Room();
                        room.RoomID = Convert.ToInt32(RDr.GetValue(0));

                        OleDbCommand cmd6 = new OleDbCommand("SELECT * FROM `Zimmer_Betten` INNER JOIN `Zimmer_Bettzuteilung` WHERE `Zimmernummer` = ?", connection);
                        cmd6.Parameters.Add(new OleDbParameter { Value = RDr.GetValue(0) });

                        var Bdr = cmd6.ExecuteReader();

                        Bdr.Read();
                        Bed bed = new Bed();
                        bed.BedID = Convert.ToInt32(Bdr.GetValue(0));
                        bed.Name = Convert.ToString(Bdr.GetValue(1));
                        bed.NumberOfBeds = Convert.ToByte(Bdr.GetValue(2));

                        room.Bed = bed;
                        room.RoomName = Convert.ToString(RDr.GetValue(2));
                        room.Price = Convert.ToByte(RDr.GetValue(3));
                        room.NumberOfRooms = Convert.ToByte(RDr.GetValue(4));
                        room.Positon = Convert.ToString(RDr.GetValue(5));
                        room.Floor = Convert.ToString(RDr.GetValue(6));
                        room.SizeOfShower = Convert.ToByte(RDr.GetValue(7));
                        room.Equipment = Convert.ToString(RDr.GetValue(8));
                        room.Lightning = Convert.ToString(RDr.GetValue(9));
                        room.Size = Convert.ToByte(RDr.GetValue(3));

                        OleDbCommand cmd7 = new OleDbCommand("SELECT * FROM `Ausstatungsgegenstaende` INNER JOIN `Buchung_Zimmer` WHERE `Buchungsnummer` = ?", connection);
                        cmd7.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                        var EDDr = cmd7.ExecuteReader();
                        EDDr.Read();

                        Equipment equipment = new Equipment();
                        equipment.EquipmentID = Convert.ToInt32(EDDr.GetValue(0));
                        equipment.EquipmentName = Convert.ToString(EDDr.GetValue(1));

                        room.equipment = equipment;

                        subRoom.Rooms.Add(room);

                        OleDbCommand cmd8 = new OleDbCommand("SELECT `Zimmerpreis`, `Zimmerrabatt` FROM `Buchung_Zimmer` WHERE `Buchungsnummer` = ?", connection);
                        cmd8.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                        var RPDr = cmd8.ExecuteReader();
                        RPDr.Read();

                        subRoom.AmountPrice = Convert.ToDouble(RPDr.GetValue(0));
                        subRoom.DiscountValue = Convert.ToByte(RPDr.GetValue(1));
                    }

                    booking.Room = subRoom;

                    TotalMealCosts totalMealCost = new TotalMealCosts();

                    OleDbCommand cmd9 = new OleDbCommand("SELECT * FROM `Speisen` INNER JOIN `Buchung_Hotel_Speisen` WHERE `Buchungsnummer` = ?", connection);
                    cmd9.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                    var MDr = cmd9.ExecuteReader();

                    if (MDr.HasRows)
                    {
                        while (MDr.Read())
                        {
                            Meal meal = new Meal();
                            meal.MealID = Convert.ToInt32(MDr.GetValue(0));
                            meal.Name = Convert.ToString(MDr.GetValue(1));

                            OleDbCommand cmd10 = new OleDbCommand("SELECT * FROM `Rabatt` INNE JOIN `Speisen` WHERE `Speisennummer` = ?", connection);
                            cmd10.Parameters.Add(new OleDbParameter { Value = MDr.GetValue(0) });

                            var DDr = cmd10.ExecuteReader();

                            DDr.Read();
                            Discount discount = new Discount();
                            discount.DiscountID = Convert.ToInt32(DDr.GetValue(0));
                            discount.DiscountValue = Convert.ToByte(DDr.GetValue(1));

                            meal.discount = discount;
                            totalMealCost.Meals.Add(meal);
                        }

                        OleDbCommand cmd11 = new OleDbCommand("SELECT `Speisen_Buchungspreis`, `Speisen_Buchungrabatt` FROM `Buchung_Hotel_Speisen` WHERE `Buchungsnummer` = ?", connection);
                        cmd11.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                        var MPDr = cmd11.ExecuteReader();
                        MPDr.Read();

                        totalMealCost.MealCost = Convert.ToDouble(MPDr.GetValue(0));
                        totalMealCost.discount = Convert.ToDouble(MPDr.GetValue(1));

                        booking.TotalMealCosts = totalMealCost;
                    }                   

                    OleDbCommand cmd12 = new OleDbCommand("SELECT * FROM `Behandlung` INNER JOIN `Buchung_Hotel_Behandlung` WHERE `Buchungsnummer` = ?", connection);
                    cmd12.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                    var TDr = cmd12.ExecuteReader();
                    

                    if (TDr.HasRows)
                    {
                        TotalTreatmentCosts totalTreatmentCost = new TotalTreatmentCosts();

                        while (TDr.Read())
                        {
                            Treatment treatment = new Treatment();
                            treatment.TreatmentID = Convert.ToInt32(TDr.GetValue(0));
                            treatment.TreatmentName = Convert.ToString(TDr.GetValue(1));

                            OleDbCommand cmd10 = new OleDbCommand("SELECT * FROM `Rabatt` INNER JOIN `Behandlung` WHERE `Behandlungsnummer` = ?", connection);
                            cmd10.Parameters.Add(new OleDbParameter { Value = TDr.GetValue(0) });

                            var DDr = cmd10.ExecuteReader();

                            DDr.Read();
                            Discount discount = new Discount();
                            discount.DiscountID = Convert.ToInt32(DDr.GetValue(0));
                            discount.DiscountValue = Convert.ToDouble(DDr.GetValue(1));

                            treatment.discount = discount;

                            totalTreatmentCost.Treatments.Add(treatment);
                        }

                        OleDbCommand cmd13 = new OleDbCommand("SELECT `Behandlung_Buchungspreis`, `Behandlung_Buchungrabatt` FROM `Buchung_Hotel_Behandlung` WHERE `Buchungsnummer` = ?", connection);
                        cmd13.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                        var TCDr = cmd13.ExecuteReader();
                        TCDr.Read();

                        totalTreatmentCost.AmountTreatmentCosts = Convert.ToDouble(TCDr.GetValue(0));
                        totalTreatmentCost.Discount = Convert.ToDouble(TCDr.GetValue(1));

                        booking.TotalTreatmentCosts = totalTreatmentCost;
                    }
                    

                    SubEmployee subEmployee = new SubEmployee();

                    OleDbCommand cmd14 = new OleDbCommand("SELECT * FROM `Mitarbeiter` INNER JOIN `Buchung_Mitarbeiter` WHERE `Buchungsnummer` = ?", connection);
                    cmd14.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                    var EDr = cmd14.ExecuteReader();
                    EDr.Read();

                    Employee employee = new Employee();
                    employee.EmployeeID = Convert.ToInt32(EDr.GetValue(0));
                    employee.Name = Convert.ToString(EDr.GetValue(1));
                    employee.Surename = Convert.ToString(EDr.GetValue(2));
                    employee.Street = Convert.ToString(EDr.GetValue(3));
                    employee.Housenumber = Convert.ToInt32(EDr.GetValue(4));
                    employee.PostalCode = Convert.ToInt64(EDr.GetValue(5));
                    employee.City = Convert.ToString(EDr.GetValue(6));
                    employee.PhoneNumber = Convert.ToInt64(EDr.GetValue(7));
                    employee.Email = Convert.ToString(EDr.GetValue(8));
                    employee.Password = Convert.ToString(EDr.GetValue(9));

                    subEmployee.Employee = employee;

                    OleDbCommand cmd15 = new OleDbCommand("SELECT `Mitarbeiter_Datum` FROM `Buchung_Mitarbeiter` WHERE `Buchungsnummer` = ?", connection);
                    cmd15.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                    var EdDr = cmd15.ExecuteReader();
                    EdDr.Read();

                    subEmployee.Date = Convert.ToDateTime(EdDr.GetValue(0));

                    booking.SubEmployee = subEmployee;

                    bookingList.Add(booking);
                }
                return bookingList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Save(Booking obj)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand cmdCheck = new OleDbCommand("SELECT `Buchungsnummer` FROM `Buchung` WHERE `Buchungsnummer` = ?", connection);
                cmdCheck.Parameters.Add(new OleDbParameter { Value = obj.BookingID });
                var edDr = cmdCheck.ExecuteReader();
                edDr.Read();

                if (edDr.HasRows == false)
                {
                    OleDbCommand cmd = new OleDbCommand("INSERT INTO `Buchung` (`Buchungsnummer`, `Kundennummer`, `Frühstücksnummer`, `Buchungsdatum`, `Zahlungsart`, `Anreise`, `Abreise`, `Buchungbeglichen`) VALUES (?, ?, ?, ?, ?, ?, ?, ?)", connection);
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.BookingID });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Customer.CustomerID });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Breakfast.BreakfastID });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.BookingDate });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.MethodOfPayment });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Arrival });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Depature });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.settel });

                    cmd.ExecuteNonQuery();

                    OleDbCommand cmd6 = new OleDbCommand("INSERT INTO `Buchung_Mitarbeiter` (`Buchungsnummer`, `Mitarbeiternummer`, `Mitarbeiter_Datum`) VALUES (?, ?, ?)", connection);
                    cmd6.Parameters.Add(new OleDbParameter { Value = obj.BookingID });
                    cmd6.Parameters.Add(new OleDbParameter { Value = obj.SubEmployee.Employee.EmployeeID });
                    cmd6.Parameters.Add(new OleDbParameter { Value = obj.SubEmployee.Date });

                    cmd6.ExecuteNonQuery();

                    foreach (Room room in obj.Room.Rooms)
                    {
                        OleDbCommand cmd2 = new OleDbCommand("INSERT INTO `Buchung_Zimmer` (`Buchungsnummer`, `Zimmernummer`, `Ausstatungsnummer`, `ZimmerPreis`, `Zimmerrabatt`) VALUES (?, ?, ?, ?, ?)", connection);
                        cmd2.Parameters.Add(new OleDbParameter { Value = obj.BookingID });
                        cmd2.Parameters.Add(new OleDbParameter { Value = room.RoomID });
                        cmd2.Parameters.Add(new OleDbParameter { Value = room.equipment.EquipmentID });
                        cmd2.Parameters.Add(new OleDbParameter { Value = obj.Room.AmountPrice });
                        cmd2.Parameters.Add(new OleDbParameter { Value = obj.Room.DiscountValue });

                        cmd2.ExecuteNonQuery();
                    }

                    if (obj.TotalMealCosts != null)
                    {
                        foreach (Meal meal in obj.TotalMealCosts.Meals)
                        {
                            OleDbCommand cmd2 = new OleDbCommand("INSERT INTO `Buchung_Hotel_Speisen` (`Speisennummer`, `Speisen_Buchungspreis`, `Speisen_Buchungrabatt`) VALUES (?, ?, ?)", connection);
                            cmd2.Parameters.Add(new OleDbParameter { Value = meal.MealID });
                            cmd2.Parameters.Add(new OleDbParameter { Value = obj.TotalMealCosts.MealCost });
                            cmd2.Parameters.Add(new OleDbParameter { Value = obj.TotalMealCosts.discount });

                            cmd2.ExecuteNonQuery();
                        }
                    }

                    if (obj.TotalTreatmentCosts != null)
                    {
                        foreach (Treatment treatment in obj.TotalTreatmentCosts.Treatments)
                        {
                            OleDbCommand cmd3 = new OleDbCommand("INSERT INTO `Buchung_Hotel_Behandlung` (`Behandlungsnummer`, `Behandlung_Buchungspreis`, `Behandlung_Buchungrabatt`) VALUES (?, ?, ?) ON EXIST UPDATE `Buchung_Zimmer` SET `Behandlungsnummer`= ?, `Behandlung_Buchungspreis`= ?, `Behandlung_Buchungrabatt`= ? WHERE `Buchungsnummer`= ?", connection);
                            cmd3.Parameters.Add(new OleDbParameter { Value = treatment.TreatmentID });
                            cmd3.Parameters.Add(new OleDbParameter { Value = obj.TotalTreatmentCosts.AmountTreatmentCosts });
                            cmd3.Parameters.Add(new OleDbParameter { Value = obj.TotalTreatmentCosts.Discount });

                            cmd3.Parameters.Add(new OleDbParameter { Value = treatment.TreatmentID });
                            cmd3.Parameters.Add(new OleDbParameter { Value = obj.TotalTreatmentCosts.AmountTreatmentCosts });
                            cmd3.Parameters.Add(new OleDbParameter { Value = obj.TotalTreatmentCosts.Discount });
                            cmd3.Parameters.Add(new OleDbParameter { Value = obj.BookingID });
                            
                            cmd3.ExecuteNonQuery();
                        }
                    }

                    if (obj.Event != null)
                    {
                        OleDbCommand cmd4 = new OleDbCommand("INSERT INTO `Buchung_Aktion` (`Buchungsnummer`, `Aktionsnummer`) VALUES (?, ?)", connection);
                        cmd4.Parameters.Add(new OleDbParameter { Value = obj.BookingID });
                        cmd4.Parameters.Add(new OleDbParameter { Value = obj.Event.EventID });

                        cmd4.ExecuteNonQuery();
                    }                

                    return true;
                }
                else
                {
                    OleDbCommand cmd = new OleDbCommand("UPDATE `Buchung` SET `Kundennummer`= ?, `Frühstücksnummer`= ?, `Buchungsdatum`= ?, `Zahlungsart`= ?, `Anreise`= ?, `Abreise`= ?, `Buchungbeglichen`= ? WHERE `Buchungsnummer`= ?", connection);
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Customer.CustomerID });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Breakfast.BreakfastID });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.BookingDate });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.MethodOfPayment });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Arrival });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Depature });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.settel });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.BookingID });
                    
                    cmd.ExecuteNonQuery();

                    foreach (Room room in obj.Room.Rooms)
                    {
                        OleDbCommand cmd2 = new OleDbCommand("UPDATE `Buchung_Zimmer` SET `Zimmernummer`= ?, `Ausstatungsnummer`= ?, `ZimmerPreis`= ?, `Zimmerrabatt`= ? WHERE `Buchungsnummer`= ?", connection);
                        cmd2.Parameters.Add(new OleDbParameter { Value = room.RoomID });
                        cmd2.Parameters.Add(new OleDbParameter { Value = room.equipment.EquipmentID });
                        cmd2.Parameters.Add(new OleDbParameter { Value = obj.Amount });
                        cmd2.Parameters.Add(new OleDbParameter { Value = obj.Room.DiscountValue });
                        cmd2.Parameters.Add(new OleDbParameter { Value = obj.BookingID });
                        
                        cmd2.ExecuteNonQuery();
                    }

                    if (obj.TotalMealCosts != null)
                    {
                        foreach (Meal meal in obj.TotalMealCosts.Meals)
                        {
                            OleDbCommand cmd2 = new OleDbCommand("UPDATE `Buchung_Hotel_Speisen` SET `Speisennummer`= ?, `Speisen_Buchungspreis`= ?, `Speisen_Buchungrabatt`= ? WHERE `Buchungsnummer`= ?", connection);
                            cmd2.Parameters.Add(new OleDbParameter { Value = meal.MealID });
                            cmd2.Parameters.Add(new OleDbParameter { Value = obj.TotalMealCosts.MealCost });
                            cmd2.Parameters.Add(new OleDbParameter { Value = obj.TotalMealCosts.discount });
                            cmd2.Parameters.Add(new OleDbParameter { Value = obj.BookingID });
                            
                            cmd2.ExecuteNonQuery();
                        }
                    }

                    if (obj.TotalTreatmentCosts != null)
                    {
                        foreach (Treatment treatment in obj.TotalTreatmentCosts.Treatments)
                        {
                            OleDbCommand cmd3 = new OleDbCommand("UPDATE `Buchung_Behandlung` SET `Behandlungsnummer`= ?, `Behandlung_Buchungspreis`= ?, `Behandlung_Buchungrabatt`= ? WHERE `Buchungsnummer`= ?", connection);
                            cmd3.Parameters.Add(new OleDbParameter { Value = treatment.TreatmentID });
                            cmd3.Parameters.Add(new OleDbParameter { Value = obj.TotalTreatmentCosts.AmountTreatmentCosts });
                            cmd3.Parameters.Add(new OleDbParameter { Value = obj.TotalTreatmentCosts.Discount });
                            cmd3.Parameters.Add(new OleDbParameter { Value = obj.BookingID });
                            
                            cmd3.ExecuteNonQuery();
                        }
                    }

                    if (obj.Event != null)
                    {
                        OleDbCommand cmd4 = new OleDbCommand("UPDATE `Buchung_Aktion` SET `Aktionsnummer`= ? WHERE `Buchungsnummer`= ?", connection);
                        cmd4.Parameters.Add(new OleDbParameter { Value = obj.Event.EventID });
                        cmd4.Parameters.Add(new OleDbParameter { Value = obj.BookingID });
                        
                        cmd4.ExecuteNonQuery();
                    }

                    OleDbCommand cmd5 = new OleDbCommand("UPDATE `Buchung_Mitarbeiter` SET `Mitarbeiternummer`= ?, `Mitarbeiter_Datum`= ? WHERE `Buchungsnummer`= ?", connection);
                    cmd5.Parameters.Add(new OleDbParameter { Value = obj.SubEmployee.Employee.EmployeeID });
                    cmd5.Parameters.Add(new OleDbParameter { Value = obj.SubEmployee.Date });
                    cmd5.Parameters.Add(new OleDbParameter { Value = obj.BookingID });

                    cmd5.ExecuteNonQuery();
                    return true;
                }

                
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }
    }
}
