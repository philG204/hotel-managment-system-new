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
            OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
            connection.Open();
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
            connection.Open();
            throw new NotImplementedException();
        }

        public Receipt Get(int TId)
        {
            OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
            connection.Open();
            throw new NotImplementedException();
        }

        public List<Receipt> GetAll()
        {
            OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
            connection.Open();
            throw new NotImplementedException();
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

                    OleDbCommand cmd6 = new OleDbCommand("INSERT INTO `Kassenbeleg_Mitarbeiter` (`Kassenbelegnummer`, `Mitarbeiternummer`, `Mitarbeiter_Datum_KB`) VALUES (?, ?, ?)", connection);
                    cmd6.Parameters.Add(new OleDbParameter { Value = obj.ReceiptID });
                    cmd6.Parameters.Add(new OleDbParameter { Value = obj.SubEmployee.Employee.EmployeeID });
                    cmd6.Parameters.Add(new OleDbParameter { Value = obj.SubEmployee.Date });

                    cmd6.ExecuteNonQuery();

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
