using hotel_managment_system;
using hotel_managment_system.Models;
using hotel_managment_system.Repositories;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.managment.system.Data.DB
{
    public class ReceiptRepository : IReceiptRepository
    {
        public bool Delete(Receipt obj)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand CheckCmd = new OleDbCommand("SELECT * FROM `Kassenbeleg` WHERE `Kassenbelegnummer`= ?", connection);
                CheckCmd.Parameters.Add(new OleDbParameter { Value = obj.ReceiptID });

                var CheckDr = CheckCmd.ExecuteReader();

                if (CheckDr.HasRows != false)
                {
                    OleDbCommand cmd1 = new OleDbCommand("DELETE FROM `Kassenbeleg` WHERE `Kassenbelegnummer`= ?", connection);
                    cmd1.Parameters.Add(new OleDbParameter { Value = obj.ReceiptID });

                    cmd1.ExecuteNonQuery();

                    OleDbCommand cmd2 = new OleDbCommand("DELETE FROM `Kassenbeleg` WHERE `Kassenbelegnummer`= ?", connection);
                    cmd2.Parameters.Add(new OleDbParameter { Value = obj.ReceiptID });

                    cmd2.ExecuteNonQuery();

                    return true;
                }
                else
                {
                    return false;
                }
                
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

                OleDbCommand CheckCmd = new OleDbCommand("SELECT * FROM `Kassenbeleg` WHERE `Kassenbelegnummer`= ?", connection);
                CheckCmd.Parameters.Add(new OleDbParameter { Value = id });

                var CheckDr = CheckCmd.ExecuteReader();

                if (CheckDr.HasRows != false)
                {
                    OleDbCommand cmd1 = new OleDbCommand("DELETE FROM `Kassenbeleg` WHERE `Kassenbelegnummer`= ?", connection);
                    cmd1.Parameters.Add(new OleDbParameter { Value = id });

                    cmd1.ExecuteNonQuery();

                    OleDbCommand cmd2 = new OleDbCommand("DELETE FROM `Kassenbeleg` WHERE `Kassenbelegnummer`= ?", connection);
                    cmd2.Parameters.Add(new OleDbParameter { Value = id });

                    cmd2.ExecuteNonQuery();

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public Receipt Get(int TId)
        { 
            try
            {
                Receipt receipt = new Receipt();

                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand CheckCmd = new OleDbCommand("SELECT * FROM `Kassenbeleg` WHERE `Kassenbelegnummer` = ?", connection);
                CheckCmd.Parameters.Add(new OleDbParameter { Value = TId });

                var CheckDr = CheckCmd.ExecuteReader();

                if (CheckDr.HasRows != false)
                {
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM `Kassenbeleg` WHERE `Kassenbelegnummer` = ?", connection);
                    cmd.Parameters.Add(new OleDbParameter { Value = TId });

                    var dr = cmd.ExecuteReader();

                    dr.Read();
                    receipt.ReceiptID = Convert.ToInt32(dr.GetValue(0));
                    receipt.PaymentDate = Convert.ToDateTime(dr.GetValue(2));
                    receipt.MethodOfPayment = Convert.ToString(dr.GetValue(3));
                    receipt.CashAmount = Convert.ToDouble(dr.GetValue(4));
                    receipt.settel = Convert.ToBoolean(dr.GetValue(5));

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

                    receipt.Customer = customer;

                    OleDbCommand cmd3 = new OleDbCommand("SELECT * FROM `Kassenbeleg_Aktion` WHERE `Kassenbelegnummer`= ?", connection);
                    cmd3.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                    var aDR = cmd3.ExecuteReader();

                    if (aDR.HasRows)
                    {
                        OleDbCommand cmd4 = new OleDbCommand("SELECT * FROM Aktion INNER JOIN Kassenbeleg_Aktion ON Aktion.Aktionsnummer = Kassenbeleg_Aktion.Aktionsnummer WHERE `Kassenbelegnummer` = ?", connection);
                        cmd4.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                        var ADr = cmd4.ExecuteReader();

                        ADr.Read();
                        Event Event = new Event();
                        Event.EventID = Convert.ToInt32(ADr.GetValue(0));
                        Event.EventName = Convert.ToString(ADr.GetValue(1));
                        Event.DiscountValue = Convert.ToByte(ADr.GetValue(2));
                        Event.From = Convert.ToDateTime(ADr.GetValue(3));
                        Event.To = Convert.ToDateTime(ADr.GetValue(4));

                        receipt.Event = Event;
                    }

                    TotalMealCosts totalMealCost = new TotalMealCosts();

                    OleDbCommand cmd9 = new OleDbCommand("SELECT * FROM Rechnung_Speisen INNER JOIN Speisen ON Rechnung_Speisen.Speisennummer = Speisen.Speisennummer WHERE Kassenbelegnummer = ?", connection);
                    cmd9.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                    var MDr = cmd9.ExecuteReader();

                    if (MDr.HasRows)
                    {
                        while (MDr.Read())
                        {
                            Meal meal = new Meal();
                            meal.MealID = Convert.ToInt32(MDr.GetValue(4));
                            meal.Name = Convert.ToString(MDr.GetValue(5));

                            OleDbCommand cmd10 = new OleDbCommand("SELECT * FROM Rabatt INNER JOIN Speisen ON Rabatt.Rabattnummer = Speisen.Rabattnummer", connection);

                            var DDr = cmd10.ExecuteReader();

                            DDr.Read();
                            Discount discount = new Discount();
                            discount.DiscountID = Convert.ToInt32(DDr.GetValue(0));
                            discount.DiscountValue = Convert.ToByte(DDr.GetValue(1));

                            meal.discount = discount;
                            totalMealCost.Meals.Add(meal);
                        }

                        OleDbCommand cmd11 = new OleDbCommand("SELECT `Speisen_Rechnungspreis`, `Speisen_Rechnungrabatt` FROM `Rechnung_Speisen` WHERE `Kassenbelegnummer` = ?", connection);
                        cmd11.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                        var MPDr = cmd11.ExecuteReader();
                        MPDr.Read();

                        totalMealCost.MealCost = Convert.ToDouble(MPDr.GetValue(0));
                        totalMealCost.discount = Convert.ToDouble(MPDr.GetValue(1));

                        receipt.TotalMealCosts = totalMealCost;
                    }

                    OleDbCommand cmd12 = new OleDbCommand("SELECT * FROM Behandlung INNER JOIN Rechnung_Behandlung ON Behandlung.Behandlungsnummer = Rechnung_Behandlung.Behandlungsnummer WHERE Kassenbelegnummer = ?", connection);
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

                            OleDbCommand cmd10 = new OleDbCommand("SELECT * FROM Rabatt INNER JOIN Speisen ON Rabatt.Rabattnummer = Speisen.Rabattnummer", connection);
                            cmd10.Parameters.Add(new OleDbParameter { Value = TDr.GetValue(0) });

                            var DDr = cmd10.ExecuteReader();

                            DDr.Read();
                            Discount discount = new Discount();
                            discount.DiscountID = Convert.ToInt32(DDr.GetValue(0));
                            discount.DiscountValue = Convert.ToDouble(DDr.GetValue(1));

                            treatment.discount = discount;

                            totalTreatmentCost.Treatments.Add(treatment);
                        }

                        OleDbCommand cmd13 = new OleDbCommand("SELECT * FROM `Rechnung_Behandlung` WHERE `Kassenbelegnummer` = ?", connection);
                        cmd13.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                        var TCDr = cmd13.ExecuteReader();
                        TCDr.Read();

                        totalTreatmentCost.AmountTreatmentCosts = Convert.ToDouble(TCDr.GetValue(2));
                        totalTreatmentCost.Discount = Convert.ToDouble(TCDr.GetValue(3));

                        receipt.TotalTreatmentCosts = totalTreatmentCost;
                    }

                    SubEmployee subEmployee = new SubEmployee();

                    OleDbCommand cmd14 = new OleDbCommand("SELECT * FROM Mitarbeiter INNER JOIN Kassenbeleg_Mitarbeiter ON Mitarbeiter.Mitarbeiternummer = Kassenbeleg_Mitarbeiter.Mitarbeiternummer WHERE Kassenbelegnummer = ?", connection);
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

                    OleDbCommand cmd15 = new OleDbCommand("SELECT `Mitarbeiter_Datum_KB` FROM `Kassenbeleg_Mitarbeiter` WHERE `Kassenbelegnummer` = ?", connection);
                    cmd15.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                    var EdDr = cmd15.ExecuteReader();
                    EdDr.Read();

                    subEmployee.Date = Convert.ToDateTime(EdDr.GetValue(0));

                    receipt.SubEmployee = subEmployee;

                    return receipt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Receipt> GetAll()
        {
            try
            {
                List<Receipt> receiptList = new List<Receipt> ();
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM `Kassenbeleg`", connection);

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Receipt receipt = new Receipt();
                    receipt.ReceiptID = Convert.ToInt32(dr.GetValue(0));
                    receipt.PaymentDate = Convert.ToDateTime(dr.GetValue(2));
                    receipt.MethodOfPayment = Convert.ToString(dr.GetValue(3));
                    receipt.CashAmount = Convert.ToDouble(dr.GetValue(4));
                    receipt.settel = Convert.ToBoolean(dr.GetValue(5));

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

                    receipt.Customer = customer;

                    OleDbCommand cmd3 = new OleDbCommand("SELECT * FROM `Kassenbeleg_Aktion` WHERE `Kassenbelegnummer`= ?", connection);
                    cmd3.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                    var aDR = cmd3.ExecuteReader();

                    if (aDR.HasRows)
                    {
                        OleDbCommand cmd4 = new OleDbCommand("SELECT * FROM Aktion INNER JOIN Kassenbeleg_Aktion ON Aktion.Aktionsnummer = Kassenbeleg_Aktion.Aktionsnummer WHERE `Kassenbelegnummer` = ?", connection);
                        cmd4.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                        var ADr = cmd4.ExecuteReader();

                        ADr.Read();
                        Event Event = new Event();
                        Event.EventID = Convert.ToInt32(ADr.GetValue(0));
                        Event.EventName = Convert.ToString(ADr.GetValue(1));
                        Event.DiscountValue = Convert.ToByte(ADr.GetValue(2));
                        Event.From = Convert.ToDateTime(ADr.GetValue(3));
                        Event.To = Convert.ToDateTime(ADr.GetValue(4));

                        receipt.Event = Event;
                    }

                    TotalMealCosts totalMealCost = new TotalMealCosts();

                    OleDbCommand cmd9 = new OleDbCommand("SELECT * FROM Rechnung_Speisen INNER JOIN Speisen ON Rechnung_Speisen.Speisennummer = Speisen.Speisennummer WHERE Kassenbelegnummer = ?", connection);
                    cmd9.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                    var MDr = cmd9.ExecuteReader();

                    if (MDr.HasRows)
                    {
                        while (MDr.Read())
                        {
                            Meal meal = new Meal();
                            meal.MealID = Convert.ToInt32(MDr.GetValue(4));
                            meal.Name = Convert.ToString(MDr.GetValue(5));

                            OleDbCommand cmd10 = new OleDbCommand("SELECT * FROM Rabatt INNER JOIN Speisen ON Rabatt.Rabattnummer = Speisen.Rabattnummer", connection);

                            var DDr = cmd10.ExecuteReader();

                            DDr.Read();
                            Discount discount = new Discount();
                            discount.DiscountID = Convert.ToInt32(DDr.GetValue(0));
                            discount.DiscountValue = Convert.ToByte(DDr.GetValue(1));

                            meal.discount = discount;
                            totalMealCost.Meals.Add(meal);
                        }

                        OleDbCommand cmd11 = new OleDbCommand("SELECT `Speisen_Rechnungspreis`, `Speisen_Rechnungrabatt` FROM `Rechnung_Speisen` WHERE `Kassenbelegnummer` = ?", connection);
                        cmd11.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                        var MPDr = cmd11.ExecuteReader();
                        MPDr.Read();

                        totalMealCost.MealCost = Convert.ToDouble(MPDr.GetValue(0));
                        totalMealCost.discount = Convert.ToDouble(MPDr.GetValue(1));

                        receipt.TotalMealCosts = totalMealCost;
                    }

                    OleDbCommand cmd12 = new OleDbCommand("SELECT * FROM Behandlung INNER JOIN Rechnung_Behandlung ON Behandlung.Behandlungsnummer = Rechnung_Behandlung.Behandlungsnummer WHERE Kassenbelegnummer = ?", connection);
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

                            OleDbCommand cmd10 = new OleDbCommand("SELECT * FROM Rabatt INNER JOIN Speisen ON Rabatt.Rabattnummer = Speisen.Rabattnummer", connection);
                            cmd10.Parameters.Add(new OleDbParameter { Value = TDr.GetValue(0) });

                            var DDr = cmd10.ExecuteReader();

                            DDr.Read();
                            Discount discount = new Discount();
                            discount.DiscountID = Convert.ToInt32(DDr.GetValue(0));
                            discount.DiscountValue = Convert.ToDouble(DDr.GetValue(1));

                            treatment.discount = discount;

                            totalTreatmentCost.Treatments.Add(treatment);
                        }

                        OleDbCommand cmd13 = new OleDbCommand("SELECT * FROM `Rechnung_Behandlung` WHERE `Kassenbelegnummer` = ?", connection);
                        cmd13.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                        var TCDr = cmd13.ExecuteReader();
                        TCDr.Read();

                        totalTreatmentCost.AmountTreatmentCosts = Convert.ToDouble(TCDr.GetValue(2));
                        totalTreatmentCost.Discount = Convert.ToDouble(TCDr.GetValue(3));

                        receipt.TotalTreatmentCosts = totalTreatmentCost;
                    }

                    SubEmployee subEmployee = new SubEmployee();

                    OleDbCommand cmd14 = new OleDbCommand("SELECT * FROM Mitarbeiter INNER JOIN Kassenbeleg_Mitarbeiter ON Mitarbeiter.Mitarbeiternummer = Kassenbeleg_Mitarbeiter.Mitarbeiternummer WHERE Kassenbelegnummer = ?", connection);
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

                    OleDbCommand cmd15 = new OleDbCommand("SELECT `Mitarbeiter_Datum_KB` FROM `Kassenbeleg_Mitarbeiter` WHERE `Kassenbelegnummer` = ?", connection);
                    cmd15.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                    var EdDr = cmd15.ExecuteReader();
                    EdDr.Read();

                    subEmployee.Date = Convert.ToDateTime(EdDr.GetValue(0));

                    receipt.SubEmployee = subEmployee;

                    receiptList.Add(receipt);
                }
                return receiptList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Save(Receipt obj)
        {
            OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
            connection.Open();

            try
            {
                OleDbCommand cmdCheck = new OleDbCommand("SELECT `Kassenbelegnummer` FROM `Kassenbeleg` WHERE `Kassenbelegnummer` = ?", connection);
                cmdCheck.Parameters.Add(new OleDbParameter { Value = obj.ReceiptID });
                var edDr = cmdCheck.ExecuteReader();
                edDr.Read();

                if (edDr.HasRows == false)
                {
                    OleDbCommand cmd = new OleDbCommand("INSERT INTO `Kassenbeleg` (`Kassenbelegnummer`, `Kundennummer`, `Zahldatum`, `Zahlungsart`, `Kassenbetrag`, `Rechnungbeglichen`) VALUES (?, ?, ?, ?, ?, ?)", connection);
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.ReceiptID });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Customer.CustomerID });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.PaymentDate });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.MethodOfPayment });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.CashAmount });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.settel });

                    cmd.ExecuteNonQuery();

                    OleDbCommand cmd6 = new OleDbCommand("INSERT INTO `Kassenbeleg_Mitarbeiter` (`Kassenbelegnummer`, `Mitarbeiternummer`, `Mitarbeiter_Datum_KB`) VALUES (?, ?, ?)", connection);
                    cmd6.Parameters.Add(new OleDbParameter { Value = obj.ReceiptID });
                    cmd6.Parameters.Add(new OleDbParameter { Value = obj.SubEmployee.Employee.EmployeeID });
                    cmd6.Parameters.Add(new OleDbParameter { Value = obj.SubEmployee.Date });

                    cmd6.ExecuteNonQuery();

                    if (obj.TotalMealCosts != null)
                    {
                        foreach (Meal meal in obj.TotalMealCosts.Meals)
                        {
                            OleDbCommand cmd2 = new OleDbCommand("INSERT INTO `Rechnung_Speisen` (`Kassenbelegnummer`, `Speisennummer`, `Speisen_Rechnungspreis`, `Speisen_Rechnungrabatt`) VALUES (?, ?, ?, ?)", connection);
                            cmd2.Parameters.Add(new OleDbParameter { Value = obj.ReceiptID });
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
                            OleDbCommand cmd3 = new OleDbCommand("INSERT INTO `Rechnung_Behandlung` (`Kassenbelegnummer`, `Behandlungsnummer`, `Behandlung_Rechnungspreis`, `Behandlung_Rechnungrabatt`) VALUES (?, ?, ?, ?)", connection);
                            cmd3.Parameters.Add(new OleDbParameter { Value = obj.ReceiptID });
                            cmd3.Parameters.Add(new OleDbParameter { Value = treatment.TreatmentID });
                            cmd3.Parameters.Add(new OleDbParameter { Value = obj.TotalTreatmentCosts.AmountTreatmentCosts });
                            cmd3.Parameters.Add(new OleDbParameter { Value = obj.TotalTreatmentCosts.Discount });

                            cmd3.ExecuteNonQuery();
                        }
                    }

                    if (obj.Event != null)
                    {
                        OleDbCommand cmd4 = new OleDbCommand("INSERT INTO `Kassenbeleg_Aktion` (`Kassenbelegnummer`, `Aktionsnummer`) VALUES (?, ?)", connection);
                        cmd4.Parameters.Add(new OleDbParameter { Value = obj.ReceiptID });
                        cmd4.Parameters.Add(new OleDbParameter { Value = obj.Event.EventID });

                        cmd4.ExecuteNonQuery();
                    }                  

                    return true;
                }
                else
                {
                    OleDbCommand cmd = new OleDbCommand("UPDATE `Kassenbeleg` SET `Kundennummer`= ?, `Zahldatum`= ?, `Zahlungsart`= ?, `Rechnungbeglichen`= ? WHERE `Kassenbelegnummer`= ?", connection);                   
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Customer.CustomerID });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.PaymentDate });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.MethodOfPayment });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.CashAmount });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.settel });

                    cmd.ExecuteNonQuery();

                    if (obj.TotalMealCosts != null)
                    {
                        foreach(Meal meal in obj.TotalMealCosts.Meals)
                        {
                            OleDbCommand cmd2 = new OleDbCommand("UPDATE `Rechnung_Speisen` SET `Speisennummer`= ?, `Speisen_Rechnungspreis`= ?, `Speisen_Rechnungrabatt`= ? WHERE `Kassenbelegnummer`= ?", connection);
                            cmd2.Parameters.Add(new OleDbParameter { Value = meal.MealID });
                            cmd2.Parameters.Add(new OleDbParameter { Value = obj.TotalMealCosts.MealCost });
                            cmd2.Parameters.Add(new OleDbParameter { Value = obj.TotalMealCosts.discount });
                            cmd2.Parameters.Add(new OleDbParameter { Value = obj.ReceiptID });

                            cmd2.ExecuteNonQuery();
                        }
                    }

                    if (obj.TotalTreatmentCosts != null)
                    {
                        foreach (Treatment treatment in obj.TotalTreatmentCosts.Treatments)
                        {
                            OleDbCommand cmd3 = new OleDbCommand("UPDATE `Rechnung_Behandlung` SET `Behandlungsnummer`= ?, `Behandlung_Rechnungspreis`= ?, `Behandlung_Rechnungrabatt`= ? WHERE `Kassenbelegnummer`= ?", connection);
                            cmd3.Parameters.Add(new OleDbParameter { Value = treatment.TreatmentID });
                            cmd3.Parameters.Add(new OleDbParameter { Value = obj.TotalTreatmentCosts.AmountTreatmentCosts });
                            cmd3.Parameters.Add(new OleDbParameter { Value = obj.TotalTreatmentCosts.Discount });
                            cmd3.Parameters.Add(new OleDbParameter { Value = obj.ReceiptID });

                            cmd3.ExecuteNonQuery();
                        }
                    }

                    if (obj.Event != null)
                    {
                        OleDbCommand cmd4 = new OleDbCommand("UPDATE `Kassenbeleg_Aktion` SET `Aktionsnummer`= ? WHERE `Kassenbelegnummer`= ?", connection);
                        cmd4.Parameters.Add(new OleDbParameter { Value = obj.Event.EventID });
                        cmd4.Parameters.Add(new OleDbParameter { Value = obj.ReceiptID });

                        cmd4.ExecuteNonQuery();
                    }

                    OleDbCommand cmd5 = new OleDbCommand("UPDATE `Kassenbeleg_Mitarbeiter` SET `Mitarbeiternummer`= ?, `Mitarbeiter_Datum`= ? WHERE `Kassenbelegnummer`= ?", connection);
                    cmd5.Parameters.Add(new OleDbParameter { Value = obj.SubEmployee.Employee.EmployeeID });
                    cmd5.Parameters.Add(new OleDbParameter { Value = obj.SubEmployee.Date });
                    cmd5.Parameters.Add(new OleDbParameter { Value = obj.ReceiptID });
                    
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
